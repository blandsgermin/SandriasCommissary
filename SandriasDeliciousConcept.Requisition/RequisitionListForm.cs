using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SandriasDeliciousConcept.Contracts;

namespace SandriasDeliciousConcept.Requisition;

public partial class RequisitionListForm : Form
{
    private readonly IRequisitionService _svc;
    private readonly IItemCatalog _catalog;
    private readonly CurrentUser _user;
    private bool _loading;

    public RequisitionListForm(IRequisitionService svc, IItemCatalog catalog, CurrentUser user)
    {
        InitializeComponent();
        _svc = svc; _catalog = catalog; _user = user;

        lblUser.Text = $"Logged in as: {user.FullName} ({user.Role})";

        _loading = true;
        cboStatus.Items.Add("All");
        foreach (var s in Enum.GetNames<RequisitionStatus>()) cboStatus.Items.Add(s);
        cboStatus.SelectedIndex = 0;
        _loading = false;

        bool chef = user.Role == "Chef", owner = user.Role == "Owner";
        btnNew.Enabled = btnEdit.Enabled = chef;
        btnApprove.Enabled = btnReturn.Enabled = owner;
        btnCancel.Enabled = chef || owner;

        LoadData();
    }

    private int? SelectedId() =>
        dgvRequisitions.CurrentRow?.Cells["RfId"].Value is int id ? id : null;

    private void LoadData()
    {
        RequisitionStatus? filter = cboStatus.SelectedIndex > 0
            ? Enum.Parse<RequisitionStatus>(cboStatus.SelectedItem!.ToString()!) : null;

        dgvRequisitions.DataSource = _svc.GetAll(filter).Select(r => new
        {
            r.RfId,
            RF = r.RfNumber,
            Date = r.RequestDate.ToString("yyyy-MM-dd"),
            r.Requester,
            Customer = r.CustomerName,
            Event = r.EventDate?.ToString("yyyy-MM-dd"),
            r.Pax,
            r.Menu,
            Status = r.Status.ToString()
        }).ToList();

        if (dgvRequisitions.Columns.Contains("RfId")) dgvRequisitions.Columns["RfId"]!.Visible = false;
    }

    private void cboStatus_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (!_loading) LoadData();
    }

    private void btnRefresh_Click(object? sender, EventArgs e) => LoadData();

    private void btnNew_Click(object? sender, EventArgs e)
    {
        using var form = new RequisitionEditForm(_svc, _catalog.GetAll(), _user);
        if (form.ShowDialog(this) == DialogResult.OK) LoadData();
    }

    private void btnEdit_Click(object? sender, EventArgs e)
    {
        if (SelectedId() is not int id) return;
        var rf = _svc.GetById(id);
        if (rf is null) return;
        if (rf.Status is not (RequisitionStatus.Pending or RequisitionStatus.Returned))
        {
            MessageBox.Show("Only a pending or returned requisition can be edited.");
            return;
        }
        using var form = new RequisitionEditForm(_svc, _catalog.GetAll(), _user, rf);
        if (form.ShowDialog(this) == DialogResult.OK) LoadData();
    }

    private void btnApprove_Click(object? sender, EventArgs e)
    {
        if (SelectedId() is not int id) return;
        if (MessageBox.Show("Approve this requisition?", "Approve", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
        Try(() => _svc.Approve(id, _user.FullName));
    }

    private void btnReturn_Click(object? sender, EventArgs e)
    {
        if (SelectedId() is not int id) return;
        var reason = ReasonPromptForm.Ask(this, "Return requisition", "Reason for returning:");
        if (reason is null) return;
        Try(() => _svc.Return(id, reason));
    }

    private void btnCancel_Click(object? sender, EventArgs e)
    {
        if (SelectedId() is not int id) return;
        var reason = ReasonPromptForm.Ask(this, "Cancel requisition", "Reason for cancelling:");
        if (reason is null) return;
        Try(() => _svc.Cancel(id, reason));
    }

    private void Try(Action action)
    {
        try { action(); LoadData(); }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Requisition", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
