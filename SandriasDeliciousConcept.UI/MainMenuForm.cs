using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SandriasDeliciousConcept.Contracts;
using SandriasDeliciousConcept.Requisition;

namespace SandriasDeliciousConcept.UI;

public partial class MainMenuForm : Form
{
    private readonly CurrentUser _user;
    private readonly AppServices _services;

    public bool LoggedOut { get; private set; }

    public MainMenuForm(CurrentUser user, AppServices services)
    {
        InitializeComponent();
        _user = user;
        _services = services;

        lblWelcome.Text = $"Welcome, {user.FullName}";
        lblRole.Text = $"Role: {user.Role}";

        bool owner = user.Role == "Owner";
        btnRequisition.Enabled = owner || user.Role == "Chef";
        btnInventory.Enabled = owner || user.Role == "InventoryClerk";
        btnPurchasing.Enabled = owner || user.Role == "Purchaser";
        btnDelivery.Enabled = owner || user.Role is "InventoryClerk" or "Purchaser";
    }

    private void btnRequisition_Click(object? sender, EventArgs e)
    {
        using var form = new RequisitionListForm(_services.Requisition, _services.Catalog, _user);
        form.ShowDialog(this);
    }

    // TODO (Inventory owner): replace the message with your own form, like the Requisition button above.
    private void btnInventory_Click(object? sender, EventArgs e) => ComingSoon("Inventory");

    // TODO (Purchasing owner)
    private void btnPurchasing_Click(object? sender, EventArgs e) => ComingSoon("Purchasing");

    // TODO (Delivery owner)
    private void btnDelivery_Click(object? sender, EventArgs e) => ComingSoon("Delivery");

    private void btnLogout_Click(object? sender, EventArgs e)
    {
        LoggedOut = true;
        Close();
    }

    private static void ComingSoon(string module) =>
        MessageBox.Show($"The {module} module is not available yet.", "Coming soon",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
}