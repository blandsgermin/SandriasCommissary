using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SandriasDeliciousConcept.Requisition;

public partial class NewItemForm : Form
{
    public NewItemForm()
    {
        InitializeComponent();
        cboUnit.Items.AddRange(new object[] { "kg", "L", "pcs", "pack", "can", "jar", "bottle", "tray", "roll", "box" });
        cboUnit.SelectedIndex = 0;
    }

    public string ItemName => txtItemName.Text.Trim();
    public string Unit => cboUnit.Text;

    private void btnOk_Click(object? sender, EventArgs e)
    {
        if (ItemName.Length == 0)
        {
            MessageBox.Show("Enter the item name.", "New item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        DialogResult = DialogResult.OK;
    }
}