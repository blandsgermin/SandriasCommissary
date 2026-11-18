using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace SandriasDeliciousConcept.Purchasing
{
    public partial class PurchasingDashboard : Form
    {
        public PurchasingDashboard()
        {
            InitializeComponent();

            Load += PurchasingDashboard_Load;
        }

        private void PurchasingDashboard_Load(object sender, EventArgs e)
        {
            dgvInventoryOverview.AutoGenerateColumns = true;
            dgvRecentActivities.AutoGenerateColumns = true;
            dgvRequisitionMonitoring.AutoGenerateColumns = true;
        }

        private void PurchasingDashboard_Load_1(object sender, EventArgs e)
        {

        }
    }
}
