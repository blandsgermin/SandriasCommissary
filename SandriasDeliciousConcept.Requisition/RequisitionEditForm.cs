using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using SandriasDeliciousConcept.Contracts;

namespace SandriasDeliciousConcept.Requisition;

public partial class RequisitionEditForm : Form
{
    private readonly IRequisitionService _svc;
    private readonly IItemCatalog _itemCatalog;
    private readonly CurrentUser _user;
    private readonly RequisitionDto? _existing;
    private readonly List<DishDto> _dishes;
    private readonly BindingList<ItemDto> _items;

    public RequisitionEditForm(IRequisitionService svc, IItemCatalog itemCatalog, IDishCatalog dishCatalog,
        CurrentUser user, RequisitionDto? existing = null)
    {
        InitializeComponent();
        _svc = svc; _itemCatalog = itemCatalog; _user = user; _existing = existing;
        _dishes = dishCatalog.GetAll().ToList();
        _items = new BindingList<ItemDto>(itemCatalog.GetAll().ToList());

        Text = existing is null ? "New Requisition" : $"Edit {existing.RfNumber}";

        cboOrderType.Items.AddRange(new object[] { "Packed meal", "Catering" });
        cboOrderType.SelectedIndex = 1;

        cboDish.DisplayMember = "Text";
        cboDish.ValueMember = "DishId";
        cboDish.DataSource = _dishes.Select(d => new { d.DishId, Text = $"{d.Category}: {d.DishName}" }).ToList();

        colItem.DataSource = _items;
        colItem.DisplayMember = nameof(ItemDto.ItemName);
        colItem.ValueMember = nameof(ItemDto.ItemId);

        if (existing is not null) LoadExisting(existing);
        ApplyOrderType();
    }

    private bool IsPacked => cboOrderType.SelectedIndex == 0;

    private void LoadExisting(RequisitionDto rf)
    {
        cboOrderType.SelectedIndex = rf.OrderType == OrderType.PackedMeal ? 0 : 1;
        txtCustomer.Text = rf.CustomerName ?? "";
        if (rf.EventDate.HasValue) dtpEventDate.Value = rf.EventDate.Value;
        txtVenue.Text = rf.Venue ?? "";
        nudPax.Value = rf.Pax ?? 0;
        txtPurpose.Text = rf.Purpose;
        if (rf.RequiredDate.HasValue) dtpRequired.Value = rf.RequiredDate.Value;
        foreach (var d in rf.Dishes) AddDishRow(d.DishId, d.DishName, d.Category ?? "Custom", d.Packs);
        foreach (var it in rf.Items) dgvItems.Rows.Add(it.ItemId, it.Unit, it.Quantity, it.Notes);
    }

    private void ApplyOrderType()
    {
        colPacks.Visible = IsPacked;
        nudPax.Enabled = !IsPacked;
        lblPaxNote.Text = IsPacked ? "Total boxes (from the dishes below)" : "Number of guests";
        lblPackageNote.Text = IsPacked
            ? "Packed meal: 1 main dish per box. Steamed rice and 1 drink (bottled water or iced tea) come with every box. You can split the order across dishes."
            : "Catering: 5 main dishes of the customer's choice, from any category. Steamed rice, dessert, and drinks are included.";
        UpdateTotalPacks();
    }

    private void UpdateTotalPacks()
    {
        if (!IsPacked) return;
        int total = 0;
        foreach (DataGridViewRow r in dgvDishes.Rows)
            if (int.TryParse(Convert.ToString(r.Cells[colPacks.Index].Value), out var p) && p > 0) total += p;
        nudPax.Value = Math.Min(total, (int)nudPax.Maximum);
    }

    private void AddDishRow(int? dishId, string name, string? category, int? packs)
    {
        foreach (DataGridViewRow r in dgvDishes.Rows)
            if (string.Equals(Convert.ToString(r.Cells[colDish.Index].Value), name, StringComparison.OrdinalIgnoreCase))
            {
                Warn("That dish is already in the list.");
                return;
            }
        int i = dgvDishes.Rows.Add(name, category, packs);
        dgvDishes.Rows[i].Tag = dishId;
        UpdateTotalPacks();
    }

    private void cboOrderType_SelectedIndexChanged(object? sender, EventArgs e) => ApplyOrderType();

    private void btnAddDish_Click(object? sender, EventArgs e)
    {
        if (cboDish.SelectedValue is not int id) return;
        var dish = _dishes.First(d => d.DishId == id);
        AddDishRow(dish.DishId, dish.DishName, dish.Category, IsPacked ? 1 : null);
    }

    private void btnAddCustom_Click(object? sender, EventArgs e)
    {
        var name = txtCustomDish.Text.Trim();
        if (name.Length == 0) { Warn("Type the name of the custom dish."); return; }
        AddDishRow(null, name, "Custom", IsPacked ? 1 : null);
        txtCustomDish.Clear();
    }

    private void btnRemoveDish_Click(object? sender, EventArgs e)
    {
        if (dgvDishes.CurrentRow is null) return;
        dgvDishes.Rows.Remove(dgvDishes.CurrentRow);
        UpdateTotalPacks();
    }

    private void dgvDishes_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex == colPacks.Index) UpdateTotalPacks();
    }

    private void btnNewItem_Click(object? sender, EventArgs e)
    {
        using var form = new NewItemForm();
        if (form.ShowDialog(this) != DialogResult.OK) return;
        try
        {
            var item = _itemCatalog.Add(form.ItemName, form.Unit);
            if (!_items.Any(i => i.ItemId == item.ItemId)) _items.Add(item);
        }
        catch (Exception ex) { Warn("Could not add the item: " + ex.Message); }
    }

    private void dgvItems_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
    {
        if (dgvItems.IsCurrentCellDirty) dgvItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }

    private void dgvItems_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex != colItem.Index) return;
        var row = dgvItems.Rows[e.RowIndex];
        if (row.Cells[colItem.Index].Value is int id)
            row.Cells[colUnit.Index].Value = _items.FirstOrDefault(i => i.ItemId == id)?.Unit;
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtCustomer.Text)) { Warn("Enter the customer name."); return; }
        if (string.IsNullOrWhiteSpace(txtPurpose.Text)) { Warn("Enter the purpose."); return; }

        var dishLines = new List<RequisitionDishDto>();
        foreach (DataGridViewRow row in dgvDishes.Rows)
        {
            int? packs = null;
            if (IsPacked)
            {
                if (!int.TryParse(Convert.ToString(row.Cells[colPacks.Index].Value), out var p) || p <= 0)
                { Warn("Enter the number of boxes (more than zero) for every dish."); return; }
                packs = p;
            }
            dishLines.Add(new RequisitionDishDto(
                row.Tag as int?,
                Convert.ToString(row.Cells[colDish.Index].Value) ?? "",
                Convert.ToString(row.Cells[colCategory.Index].Value),
                packs));
        }
        if (dishLines.Count == 0) { Warn("Add at least one main dish."); return; }

        if (!IsPacked)
        {
            if (nudPax.Value <= 0) { Warn("Enter the number of guests (pax)."); return; }
            if (dishLines.Count != 5 && MessageBox.Show(
                    $"A catering package normally has 5 main dishes, and this order has {dishLines.Count}. Continue?",
                    "Catering", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        }

        var lines = new List<RequisitionItemDto>();
        foreach (DataGridViewRow row in dgvItems.Rows)
        {
            if (row.IsNewRow) continue;
            if (row.Cells[colItem.Index].Value is not int itemId) { Warn("Choose an item on every row."); return; }
            if (!decimal.TryParse(Convert.ToString(row.Cells[colQuantity.Index].Value), out var qty) || qty <= 0)
            { Warn("Enter a quantity greater than zero on every row."); return; }
            var item = _items.First(i => i.ItemId == itemId);
            var notes = Convert.ToString(row.Cells[colNotes.Index].Value)?.Trim();
            lines.Add(new RequisitionItemDto(item.ItemId, item.ItemName, item.Unit, qty,
                string.IsNullOrEmpty(notes) ? null : notes));
        }
        if (lines.Count == 0) { Warn("Add at least one item."); return; }

        var rf = new RequisitionDto(
            _existing?.RfId ?? 0, _existing?.RfNumber ?? "", DateTime.Now, _user.FullName,
            IsPacked ? OrderType.PackedMeal : OrderType.Catering,
            txtCustomer.Text.Trim(), dtpEventDate.Value.Date, txtVenue.Text.Trim(),
            nudPax.Value > 0 ? (int?)nudPax.Value : null,
            txtPurpose.Text.Trim(), dtpRequired.Value.Date, RequisitionStatus.Pending, dishLines, lines);

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