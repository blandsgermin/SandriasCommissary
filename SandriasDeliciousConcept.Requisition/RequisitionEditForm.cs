using System;
using System.Collections.Generic;
using System.Text;
using SandriasDeliciousConcept.Contracts;

namespace SandriasDeliciousConcept.Requisition;

public class RequisitionEditForm : Form
{
    private readonly IRequisitionService _svc;
    private readonly IReadOnlyList<ItemDto> _items;
    private readonly CurrentUser _user;
    private readonly RequisitionDto? _existing;

    private readonly TextBox _customer = new() { Width = 280 };
    private readonly DateTimePicker _eventDate = new() { Width = 280, Format = DateTimePickerFormat.Short };
    private readonly TextBox _venue = new() { Width = 280 };
    private readonly NumericUpDown _pax = new() { Width = 120, Maximum = 100000 };
    private readonly ComboBox _menu = new() { Width = 280, DropDownStyle = ComboBoxStyle.DropDown };
    private readonly TextBox _purpose = new() { Width = 280 };
    private readonly DateTimePicker _required = new() { Width = 280, Format = DateTimePickerFormat.Short };
    private readonly DataGridView _grid = new()
    {
        Dock = DockStyle.Fill,
        AllowUserToAddRows = true,
        AllowUserToDeleteRows = true
    };

    public RequisitionEditForm(IRequisitionService svc, IReadOnlyList<ItemDto> items,
        CurrentUser user, RequisitionDto? existing = null)
    {
        _svc = svc; _items = items; _user = user; _existing = existing;

        Text = existing is null ? "New Requisition" : $"Edit {existing.RfNumber}";
        Size = new Size(640, 680);
        StartPosition = FormStartPosition.CenterParent;

        _menu.Items.AddRange(new object[] { "Pork", "Beef", "Chicken", "Pancit", "Vegetables" });

        var table = new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            ColumnCount = 2,
            Padding = new Padding(12)
        };
        void Row(string label, Control c)
        {
            table.Controls.Add(new Label
            {
                Text = label,
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                Margin = new Padding(0, 6, 12, 6)
            });
            table.Controls.Add(c);
        }
        Row("Customer name", _customer);
        Row("Event date", _eventDate);
        Row("Venue", _venue);
        Row("Number of pax", _pax);
        Row("Menu (main course)", _menu);
        Row("Purpose", _purpose);
        Row("Required date", _required);

        _grid.Columns.Add(new DataGridViewComboBoxColumn
        {
            HeaderText = "Item",
            Width = 240,
            DataSource = _items.ToList(),
            DisplayMember = nameof(ItemDto.ItemName),
            ValueMember = nameof(ItemDto.ItemId)
        });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Unit", ReadOnly = true, Width = 80 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Quantity", Width = 100 });

        _grid.CurrentCellDirtyStateChanged += (s, e) =>
        {
            if (_grid.IsCurrentCellDirty) _grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        };
        _grid.CellValueChanged += (s, e) =>
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0) return;
            var row = _grid.Rows[e.RowIndex];
            if (row.Cells[0].Value is int id)
                row.Cells[1].Value = _items.FirstOrDefault(i => i.ItemId == id)?.Unit;
        };

        var save = new Button { Text = "Save", Width = 90 };
        var cancel = new Button { Text = "Cancel", Width = 90, DialogResult = DialogResult.Cancel };
        save.Click += (s, e) => Save();
        var buttons = new FlowLayoutPanel
        {
            Dock = DockStyle.Bottom,
            FlowDirection = FlowDirection.RightToLeft,
            Height = 48,
            Padding = new Padding(8)
        };
        buttons.Controls.Add(cancel);
        buttons.Controls.Add(save);
        CancelButton = cancel;

        Controls.Add(_grid);
        Controls.Add(table);
        Controls.Add(buttons);

        if (existing is not null) Load(existing);
    }

    private void Load(RequisitionDto rf)
    {
        _customer.Text = rf.CustomerName ?? "";
        if (rf.EventDate.HasValue) _eventDate.Value = rf.EventDate.Value;
        _venue.Text = rf.Venue ?? "";
        _pax.Value = rf.Pax ?? 0;
        _menu.Text = rf.Menu ?? "";
        _purpose.Text = rf.Purpose;
        if (rf.RequiredDate.HasValue) _required.Value = rf.RequiredDate.Value;
        foreach (var it in rf.Items) _grid.Rows.Add(it.ItemId, it.Unit, it.Quantity);
    }

    private void Save()
    {
        if (string.IsNullOrWhiteSpace(_customer.Text)) { Warn("Enter the customer name."); return; }
        if (string.IsNullOrWhiteSpace(_purpose.Text)) { Warn("Enter the purpose."); return; }

        var lines = new List<RequisitionItemDto>();
        foreach (DataGridViewRow row in _grid.Rows)
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
            _customer.Text.Trim(), _eventDate.Value.Date, _venue.Text.Trim(),
            _pax.Value > 0 ? (int?)_pax.Value : null,
            string.IsNullOrWhiteSpace(_menu.Text) ? null : _menu.Text.Trim(),
            _purpose.Text.Trim(), _required.Value.Date, RequisitionStatus.Pending, lines);

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
