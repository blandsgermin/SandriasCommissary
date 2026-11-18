using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace SandriasDeliciousConcept.Purchasing
{
    partial class PurchasingDashboard : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPurchaseHistory = new System.Windows.Forms.Button();
            this.btnPurchaseOrders = new System.Windows.Forms.Button();
            this.btnQuotations = new System.Windows.Forms.Button();
            this.btnPurchaseRequests = new System.Windows.Forms.Button();
            this.btnSuppliers = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.Panel();
            this.dgvRecentActivities = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.pnlInventoryShortages = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlPendingRequisitions = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlActivePO = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlAwaitingDeliveries = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvInventoryOverview = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dgvRequisitionMonitoring = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivities)).BeginInit();
            this.pnlInventoryShortages.SuspendLayout();
            this.pnlPendingRequisitions.SuspendLayout();
            this.pnlActivePO.SuspendLayout();
            this.pnlAwaitingDeliveries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryOverview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequisitionMonitoring)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.btnPurchaseHistory);
            this.panel1.Controls.Add(this.btnPurchaseOrders);
            this.panel1.Controls.Add(this.btnQuotations);
            this.panel1.Controls.Add(this.btnPurchaseRequests);
            this.panel1.Controls.Add(this.btnSuppliers);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 797);
            this.panel1.TabIndex = 0;
            // 
            // btnPurchaseHistory
            // 
            this.btnPurchaseHistory.FlatAppearance.BorderSize = 0;
            this.btnPurchaseHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPurchaseHistory.ForeColor = System.Drawing.Color.White;
            this.btnPurchaseHistory.Location = new System.Drawing.Point(0, 447);
            this.btnPurchaseHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPurchaseHistory.Name = "btnPurchaseHistory";
            this.btnPurchaseHistory.Size = new System.Drawing.Size(227, 36);
            this.btnPurchaseHistory.TabIndex = 7;
            this.btnPurchaseHistory.Text = "Purchase History";
            this.btnPurchaseHistory.UseVisualStyleBackColor = true;
            // 
            // btnPurchaseOrders
            // 
            this.btnPurchaseOrders.FlatAppearance.BorderSize = 0;
            this.btnPurchaseOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseOrders.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPurchaseOrders.ForeColor = System.Drawing.Color.White;
            this.btnPurchaseOrders.Location = new System.Drawing.Point(0, 406);
            this.btnPurchaseOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPurchaseOrders.Name = "btnPurchaseOrders";
            this.btnPurchaseOrders.Size = new System.Drawing.Size(227, 36);
            this.btnPurchaseOrders.TabIndex = 6;
            this.btnPurchaseOrders.Text = "Purchase Order";
            this.btnPurchaseOrders.UseVisualStyleBackColor = true;
            // 
            // btnQuotations
            // 
            this.btnQuotations.FlatAppearance.BorderSize = 0;
            this.btnQuotations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuotations.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnQuotations.ForeColor = System.Drawing.Color.White;
            this.btnQuotations.Location = new System.Drawing.Point(0, 366);
            this.btnQuotations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuotations.Name = "btnQuotations";
            this.btnQuotations.Size = new System.Drawing.Size(227, 36);
            this.btnQuotations.TabIndex = 5;
            this.btnQuotations.Text = "Quotations";
            this.btnQuotations.UseVisualStyleBackColor = true;
            // 
            // btnPurchaseRequests
            // 
            this.btnPurchaseRequests.FlatAppearance.BorderSize = 0;
            this.btnPurchaseRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseRequests.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPurchaseRequests.ForeColor = System.Drawing.Color.White;
            this.btnPurchaseRequests.Location = new System.Drawing.Point(3, 326);
            this.btnPurchaseRequests.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPurchaseRequests.Name = "btnPurchaseRequests";
            this.btnPurchaseRequests.Size = new System.Drawing.Size(227, 36);
            this.btnPurchaseRequests.TabIndex = 4;
            this.btnPurchaseRequests.Text = "Purchase Request";
            this.btnPurchaseRequests.UseVisualStyleBackColor = true;
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.FlatAppearance.BorderSize = 0;
            this.btnSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuppliers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSuppliers.ForeColor = System.Drawing.Color.White;
            this.btnSuppliers.Location = new System.Drawing.Point(0, 286);
            this.btnSuppliers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(227, 36);
            this.btnSuppliers.TabIndex = 3;
            this.btnSuppliers.Text = "Suppliers";
            this.btnSuppliers.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDashboard.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 246);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(227, 36);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(50, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Delicious Concept";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(30, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sandrias";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(230, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1337, 60);
            this.panel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(15, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(345, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Monitor purchasing, inventory, requisitions and deliveries.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(6, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 45);
            this.label3.TabIndex = 0;
            this.label3.Text = "Dashboard";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.dgvRequisitionMonitoring);
            this.flowLayoutPanel1.Controls.Add(this.label16);
            this.flowLayoutPanel1.Controls.Add(this.dgvRecentActivities);
            this.flowLayoutPanel1.Controls.Add(this.label15);
            this.flowLayoutPanel1.Controls.Add(this.pnlInventoryShortages);
            this.flowLayoutPanel1.Controls.Add(this.pnlPendingRequisitions);
            this.flowLayoutPanel1.Controls.Add(this.pnlActivePO);
            this.flowLayoutPanel1.Controls.Add(this.pnlAwaitingDeliveries);
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.dgvInventoryOverview);
            this.flowLayoutPanel1.Controls.Add(this.label14);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.flowLayoutPanel1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(230, 60);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1337, 737);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // dgvRecentActivities
            // 
            this.dgvRecentActivities.AllowUserToAddRows = false;
            this.dgvRecentActivities.AllowUserToDeleteRows = false;
            this.dgvRecentActivities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentActivities.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentActivities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentActivities.Location = new System.Drawing.Point(18, 454);
            this.dgvRecentActivities.Name = "dgvRecentActivities";
            this.dgvRecentActivities.ReadOnly = true;
            this.dgvRecentActivities.RowHeadersVisible = false;
            this.dgvRecentActivities.RowHeadersWidth = 51;
            this.dgvRecentActivities.RowTemplate.Height = 24;
            this.dgvRecentActivities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentActivities.Size = new System.Drawing.Size(903, 188);
            this.dgvRecentActivities.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 416);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(328, 35);
            this.label15.TabIndex = 7;
            this.label15.Text = "Recent Purchasing Activity";
            // 
            // pnlInventoryShortages
            // 
            this.pnlInventoryShortages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInventoryShortages.Controls.Add(this.label6);
            this.pnlInventoryShortages.Controls.Add(this.label11);
            this.pnlInventoryShortages.Location = new System.Drawing.Point(19, 22);
            this.pnlInventoryShortages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlInventoryShortages.Name = "pnlInventoryShortages";
            this.pnlInventoryShortages.Size = new System.Drawing.Size(220, 104);
            this.pnlInventoryShortages.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "Inventory Shortages";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(72, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 57);
            this.label11.TabIndex = 1;
            this.label11.Text = "05";
            // 
            // pnlPendingRequisitions
            // 
            this.pnlPendingRequisitions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPendingRequisitions.Controls.Add(this.label10);
            this.pnlPendingRequisitions.Controls.Add(this.label5);
            this.pnlPendingRequisitions.Location = new System.Drawing.Point(245, 22);
            this.pnlPendingRequisitions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPendingRequisitions.Name = "pnlPendingRequisitions";
            this.pnlPendingRequisitions.Size = new System.Drawing.Size(220, 104);
            this.pnlPendingRequisitions.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(84, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 57);
            this.label10.TabIndex = 1;
            this.label10.Text = "08";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Pending Requisitions";
            // 
            // pnlActivePO
            // 
            this.pnlActivePO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlActivePO.Controls.Add(this.label12);
            this.pnlActivePO.Controls.Add(this.label7);
            this.pnlActivePO.Location = new System.Drawing.Point(471, 22);
            this.pnlActivePO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlActivePO.Name = "pnlActivePO";
            this.pnlActivePO.Size = new System.Drawing.Size(220, 104);
            this.pnlActivePO.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(73, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 57);
            this.label12.TabIndex = 1;
            this.label12.Text = "06";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Active Purchase Orders";
            // 
            // pnlAwaitingDeliveries
            // 
            this.pnlAwaitingDeliveries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAwaitingDeliveries.Controls.Add(this.label13);
            this.pnlAwaitingDeliveries.Controls.Add(this.label8);
            this.pnlAwaitingDeliveries.Location = new System.Drawing.Point(697, 22);
            this.pnlAwaitingDeliveries.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlAwaitingDeliveries.Name = "pnlAwaitingDeliveries";
            this.pnlAwaitingDeliveries.Size = new System.Drawing.Size(220, 104);
            this.pnlAwaitingDeliveries.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(72, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 57);
            this.label13.TabIndex = 1;
            this.label13.Text = "03";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "Awaiting Deliveries";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(250, 35);
            this.label9.TabIndex = 4;
            this.label9.Text = "Inventory Overview";
            // 
            // dgvInventoryOverview
            // 
            this.dgvInventoryOverview.AllowUserToAddRows = false;
            this.dgvInventoryOverview.AllowUserToDeleteRows = false;
            this.dgvInventoryOverview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventoryOverview.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventoryOverview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventoryOverview.Location = new System.Drawing.Point(18, 172);
            this.dgvInventoryOverview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvInventoryOverview.MultiSelect = false;
            this.dgvInventoryOverview.Name = "dgvInventoryOverview";
            this.dgvInventoryOverview.ReadOnly = true;
            this.dgvInventoryOverview.RowHeadersVisible = false;
            this.dgvInventoryOverview.RowHeadersWidth = 51;
            this.dgvInventoryOverview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventoryOverview.Size = new System.Drawing.Size(903, 192);
            this.dgvInventoryOverview.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 23);
            this.label14.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(23, 839);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(249, 35);
            this.label16.TabIndex = 10;
            this.label16.Text = "Request Monitoring";
            // 
            // dgvRequisitionMonitoring
            // 
            this.dgvRequisitionMonitoring.AllowUserToAddRows = false;
            this.dgvRequisitionMonitoring.AllowUserToDeleteRows = false;
            this.dgvRequisitionMonitoring.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequisitionMonitoring.BackgroundColor = System.Drawing.Color.White;
            this.dgvRequisitionMonitoring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequisitionMonitoring.Location = new System.Drawing.Point(23, 877);
            this.dgvRequisitionMonitoring.Name = "dgvRequisitionMonitoring";
            this.dgvRequisitionMonitoring.ReadOnly = true;
            this.dgvRequisitionMonitoring.RowHeadersVisible = false;
            this.dgvRequisitionMonitoring.RowHeadersWidth = 51;
            this.dgvRequisitionMonitoring.RowTemplate.Height = 24;
            this.dgvRequisitionMonitoring.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequisitionMonitoring.Size = new System.Drawing.Size(898, 218);
            this.dgvRequisitionMonitoring.TabIndex = 11;
            // 
            // PurchasingDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1567, 797);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PurchasingDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchasing Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivities)).EndInit();
            this.pnlInventoryShortages.ResumeLayout(false);
            this.pnlInventoryShortages.PerformLayout();
            this.pnlPendingRequisitions.ResumeLayout(false);
            this.pnlPendingRequisitions.PerformLayout();
            this.pnlActivePO.ResumeLayout(false);
            this.pnlActivePO.PerformLayout();
            this.pnlAwaitingDeliveries.ResumeLayout(false);
            this.pnlAwaitingDeliveries.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryOverview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequisitionMonitoring)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel flowLayoutPanel1;
        private Label label1;
        private Button btnSuppliers;
        private Button btnDashboard;
        private Label label2;
        private Button btnPurchaseHistory;
        private Button btnPurchaseOrders;
        private Button btnQuotations;
        private Button btnPurchaseRequests;
        private Label label4;
        private Label label3;
        private Panel pnlPendingRequisitions;
        private Label label5;
        private Panel pnlInventoryShortages;
        private Label label6;
        private Panel pnlActivePO;
        private Label label7;
        private Panel pnlAwaitingDeliveries;
        private Label label8;
        private Label label10;
        private Label label9;
        private DataGridView dgvInventoryOverview;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private DataGridView dgvRecentActivities;
        private DataGridView dgvRequisitionMonitoring;
        private Label label16;
    }
}