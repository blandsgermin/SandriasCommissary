using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SandriasDeliciousConcept.Contracts;

namespace SandriasDeliciousConcept.Requisition;

public partial class RequisitionEditForm : Form
{
    private readonly IRequisitionService _svc;
    private readonly IReadOnlyList<ItemDto> _items;
    private readonly CurrentUser _user;
    private readonly RequisitionDto? _existing;

    public RequisitionEditForm(IRequisitionService svc, IReadOnlyList<ItemDto> items,
        CurrentUser user, RequisitionDto? existing = null)
    {
        InitializeComponent();
        _svc = svc; _items = items; _user = user; _existing = existing;

        Text = existing is null ? "New Requisition" : $"Edit {existing.RfNumber}";

        colItem.DataSource = _items.ToList();
        colItem.DisplayMember = nameof(ItemDto.ItemName);
        colItem.ValueMember = nameof(ItemDto.ItemId);

        if (existing is not null) LoadExisting(existing);
    }

    private void LoadExisting(RequisitionDto rf)
    {
        txtCustomer.Text = rf.CustomerName ?? "";
        if (rf.EventDate.HasValue) dtpEventDate.Value = rf.EventDate.Value;
        txtVenue.Text = rf.Venue ?? "";
        nudPax.Value = rf.Pax ?? 0;
        cboMenu.Text = rf.Menu ?? "";
        txtPurpose.Text = rf.Purpose;
        if (rf.RequiredDate.HasValue) dtpRequired.Value = rf.RequiredDate.Value;
        foreach (var it in rf.Items) dgvItems.Rows.Add(it.ItemId, it.Unit, it.Quantity);
    }

    private void dgvItems_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
    {
        if (dgvItems.IsCurrentCellDirty) dgvItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }

    private void dgvItems_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex != 0) return;
        var row = dgvItems.Rows[e.RowIndex];
        if (row.Cells[0].Value is int id)
            row.Cells[1].Value = _items.FirstOrDefault(i => i.ItemId == id)?.Unit;
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtCustomer.Text)) { Warn("Enter the customer name."); return; }
        if (string.IsNullOrWhiteSpace(txtPurpose.Text)) { Warn("Enter the purpose."); return; }

        var lines = new List<RequisitionItemDto>();
        foreach (DataGridViewRow row in dgvItems.Rows)
        {
            if (row.IsNewRow) continue;
            if (row.Cells[0].Value is not int itemId) { Warn("Choose an item on every row."); return; }
            if (!decimal.TryParse(Convert.ToString(row.Cells[2].Value), out var qty) || qty <= 0)
            { Warn("Enter a quantity greater than zero on every row."); return; }
            var item = _items.First(i => i.ItemId == itemId);
            lines.Add(new RequisitionItemDto(item.ItemId, item.ItemName, item.Unit, qty));
        }
        if (lines.Count == 0) { Warn("Add at least one item."); return; }

        var rf = new RequisitionDto(
            _existing?.RfId ?? 0, _existing?.RfNumber ?? "", DateTime.Now, _user.FullName,
            txtCustomer.Text.Trim(), dtpEventDate.Value.Date, txtVenue.Text.Trim(),
            nudPax.Value > 0 ? (int?)nudPax.Value : null,
            string.IsNullOrWhiteSpace(cboMenu.Text) ? null : cboMenu.Text.Trim(),
            txtPurpose.Text.Trim(), dtpRequired.Value.Date, RequisitionStatus.Pending, lines);

        try
        {
            if (_existing is null) _svc.Create(rf); else _svc.Update(rf);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex) { Warn("Could not save: " + ex.Message); }
    }

    private static void Warn(string message) =>
        MessageBox.Show(message, "Requisition", MessageBoxButtons.OK, MessageBoxIcon.Warning);
}
