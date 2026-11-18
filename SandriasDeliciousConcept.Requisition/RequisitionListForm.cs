using System;
using System.Collections.Generic;
using System.Text;
using SandriasDeliciousConcept.Contracts;

namespace SandriasDeliciousConcept.Requisition;

public class RequisitionListForm : Form
{
    private readonly IRequisitionService _svc;
    private readonly IItemCatalog _catalog;
    private readonly CurrentUser _user;

    private readonly DataGridView _grid = new()
    {
        Dock = DockStyle.Fill,
        ReadOnly = true,
        AllowUserToAddRows = false,
        AllowUserToDeleteRows = false,
        MultiSelect = false,
        SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    };
    private readonly ComboBox _status = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 150 };
    private readonly Button _new = new() { Text = "New", AutoSize = true };
    private readonly Button _edit = new() { Text = "Edit", AutoSize = true };
    private readonly Button _approve = new() { Text = "Approve", AutoSize = true };
    private readonly Button _return = new() { Text = "Return", AutoSize = true };
    private readonly Button _cancel = new() { Text = "Cancel request", AutoSize = true };

    public RequisitionListForm(IRequisitionService svc, IItemCatalog catalog, CurrentUser user)
    {
        _svc = svc; _catalog = catalog; _user = user;

        Text = "Requisitions";
        Size = new Size(1000, 560);
        StartPosition = FormStartPosition.CenterScreen;

        _status.Items.Add("All");
        foreach (var s in Enum.GetNames<RequisitionStatus>()) _status.Items.Add(s);
        _status.SelectedIndex = 0;

        bool chef = user.Role == "Chef", owner = user.Role == "Owner";
        _new.Enabled = _edit.Enabled = chef;
        _approve.Enabled = _return.Enabled = owner;
        _cancel.Enabled = chef || owner;

        var refresh = new Button { Text = "Refresh", AutoSize = true };
        var top = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(8) };
        top.Controls.Add(new Label
        {
            Text = $"Logged in as: {user.FullName} ({user.Role})   Status:",
            AutoSize = true,
            Margin = new Padding(0, 8, 8, 0)
        });
        top.Controls.AddRange(new Control[] { _status, _new, _edit, _approve, _return, _cancel, refresh });

        Controls.Add(_grid);
        Controls.Add(top);

        _status.SelectedIndexChanged += (s, e) => LoadData();
        refresh.Click += (s, e) => LoadData();
        _new.Click += (s, e) => NewRequest();
        _edit.Click += (s, e) => EditRequest();
        _approve.Click += (s, e) => Approve();
        _return.Click += (s, e) => ReturnRequest();
        _cancel.Click += (s, e) => CancelRequest();

        LoadData();
    }

    private int? SelectedId() =>
        _grid.CurrentRow?.Cells["RfId"].Value is int id ? id : null;

    private void LoadData()
    {
        RequisitionStatus? filter = _status.SelectedIndex > 0
            ? Enum.Parse<RequisitionStatus>(_status.SelectedItem!.ToString()!) : null;

        _grid.DataSource = _svc.GetAll(filter).Select(r => new
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

        if (_grid.Columns.Contains("RfId")) _grid.Columns["RfId"]!.Visible = false;
    }

    private void NewRequest()
    {
        using var form = new RequisitionEditForm(_svc, _catalog.GetAll(), _user);
        if (form.ShowDialog(this) == DialogResult.OK) LoadData();
    }

    private void EditRequest()
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

    private void Approve()
    {
        if (SelectedId() is not int id) return;
        if (MessageBox.Show("Approve this requisition?", "Approve", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
        Try(() => _svc.Approve(id, _user.FullName));
    }

    private void ReturnRequest()
    {
        if (SelectedId() is not int id) return;
        var reason = Prompt.Show(this, "Return requisition", "Reason for returning:");
        if (reason is null) return;
        Try(() => _svc.Return(id, reason));
    }

    private void CancelRequest()
    {
        if (SelectedId() is not int id) return;
        var reason = Prompt.Show(this, "Cancel requisition", "Reason for cancelling:");
        if (reason is null) return;
        Try(() => _svc.Cancel(id, reason));
    }

    private void Try(Action action)
    {
        try { action(); LoadData(); }
        catch (Exception ex) { MessageBox.Show(ex.Message, "Requisition", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
    }
}
