namespace TopmanIdManagementAndInventorycontrol
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlNavbar = new System.Windows.Forms.Panel();
            this.pnlStoreMgt = new System.Windows.Forms.Panel();
            this.btnSalesHistory = new System.Windows.Forms.Button();
            this.btnStoreList = new System.Windows.Forms.Button();
            this.btnStoreMgt = new System.Windows.Forms.Button();
            this.pnlPriceMgt = new System.Windows.Forms.Panel();
            this.btnPriceCategory = new System.Windows.Forms.Button();
            this.btnPriceList = new System.Windows.Forms.Button();
            this.btnPriceMgt = new System.Windows.Forms.Button();
            this.pnlStockMgt = new System.Windows.Forms.Panel();
            this.btnStockTransferHistory = new System.Windows.Forms.Button();
            this.btnStockTransfer = new System.Windows.Forms.Button();
            this.btnStockList = new System.Windows.Forms.Button();
            this.btnStockMgt = new System.Windows.Forms.Button();
            this.pnlProductMgt = new System.Windows.Forms.Panel();
            this.btnSeason = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnDepartment = new System.Windows.Forms.Button();
            this.btnItem = new System.Windows.Forms.Button();
            this.btnArticleSeason = new System.Windows.Forms.Button();
            this.btnArticle = new System.Windows.Forms.Button();
            this.btnProductMgt = new System.Windows.Forms.Button();
            this.pnlStaffMgt = new System.Windows.Forms.Panel();
            this.btnMutation = new System.Windows.Forms.Button();
            this.btnPosition = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.btnStaffMgt = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.ucWelcome1 = new TopmanIdManagementAndInventorycontrol.UCWelcome();
            this.ucSalesHistory1 = new TopmanIdManagementAndInventorycontrol.UCSalesHistory();
            this.ucStoreList1 = new TopmanIdManagementAndInventorycontrol.UCStoreList();
            this.ucPriceCategory1 = new TopmanIdManagementAndInventorycontrol.UCPriceCategory();
            this.ucPriceList1 = new TopmanIdManagementAndInventorycontrol.UCPriceList();
            this.ucStockTransferHistory1 = new TopmanIdManagementAndInventorycontrol.UCStockTransferHistory();
            this.ucStockList1 = new TopmanIdManagementAndInventorycontrol.UCStockList();
            this.ucSeason1 = new TopmanIdManagementAndInventorycontrol.UCSeason();
            this.ucCategory1 = new TopmanIdManagementAndInventorycontrol.UCCategory();
            this.ucDepartment1 = new TopmanIdManagementAndInventorycontrol.UCDepartment();
            this.ucItem1 = new TopmanIdManagementAndInventorycontrol.UCItem();
            this.ucMutation1 = new TopmanIdManagementAndInventorycontrol.UCMutation();
            this.ucPosition1 = new TopmanIdManagementAndInventorycontrol.UCPosition();
            this.ucStaffData1 = new TopmanIdManagementAndInventorycontrol.UCStaffData();
            this.ucArticle1 = new TopmanIdManagementAndInventorycontrol.UCArticle();
            this.ucArticleSeason1 = new TopmanIdManagementAndInventorycontrol.UCArticleSeason();
            this.ucStockTransfer1 = new TopmanIdManagementAndInventorycontrol.UCStockTransfer();
            this.pnlNavbar.SuspendLayout();
            this.pnlStoreMgt.SuspendLayout();
            this.pnlPriceMgt.SuspendLayout();
            this.pnlStockMgt.SuspendLayout();
            this.pnlProductMgt.SuspendLayout();
            this.pnlStaffMgt.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(639, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(33, 33);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlNavbar
            // 
            this.pnlNavbar.AutoScroll = true;
            this.pnlNavbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.pnlNavbar.Controls.Add(this.pnlStoreMgt);
            this.pnlNavbar.Controls.Add(this.btnStoreMgt);
            this.pnlNavbar.Controls.Add(this.pnlPriceMgt);
            this.pnlNavbar.Controls.Add(this.btnPriceMgt);
            this.pnlNavbar.Controls.Add(this.pnlStockMgt);
            this.pnlNavbar.Controls.Add(this.btnStockMgt);
            this.pnlNavbar.Controls.Add(this.pnlProductMgt);
            this.pnlNavbar.Controls.Add(this.btnProductMgt);
            this.pnlNavbar.Controls.Add(this.pnlStaffMgt);
            this.pnlNavbar.Controls.Add(this.btnStaffMgt);
            this.pnlNavbar.Controls.Add(this.panel3);
            this.pnlNavbar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavbar.Location = new System.Drawing.Point(0, 0);
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.Size = new System.Drawing.Size(200, 782);
            this.pnlNavbar.TabIndex = 2;
            // 
            // pnlStoreMgt
            // 
            this.pnlStoreMgt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlStoreMgt.Controls.Add(this.btnSalesHistory);
            this.pnlStoreMgt.Controls.Add(this.btnStoreList);
            this.pnlStoreMgt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStoreMgt.Location = new System.Drawing.Point(0, 740);
            this.pnlStoreMgt.Name = "pnlStoreMgt";
            this.pnlStoreMgt.Size = new System.Drawing.Size(183, 57);
            this.pnlStoreMgt.TabIndex = 19;
            // 
            // btnSalesHistory
            // 
            this.btnSalesHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalesHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSalesHistory.FlatAppearance.BorderSize = 0;
            this.btnSalesHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesHistory.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesHistory.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSalesHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalesHistory.Location = new System.Drawing.Point(0, 25);
            this.btnSalesHistory.Name = "btnSalesHistory";
            this.btnSalesHistory.Size = new System.Drawing.Size(183, 25);
            this.btnSalesHistory.TabIndex = 19;
            this.btnSalesHistory.Text = "          Sales History";
            this.btnSalesHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalesHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalesHistory.UseVisualStyleBackColor = true;
            this.btnSalesHistory.Click += new System.EventHandler(this.btnSalesHistory_Click);
            // 
            // btnStoreList
            // 
            this.btnStoreList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStoreList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStoreList.FlatAppearance.BorderSize = 0;
            this.btnStoreList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStoreList.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStoreList.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStoreList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStoreList.Location = new System.Drawing.Point(0, 0);
            this.btnStoreList.Name = "btnStoreList";
            this.btnStoreList.Size = new System.Drawing.Size(183, 25);
            this.btnStoreList.TabIndex = 18;
            this.btnStoreList.Text = "          Store List";
            this.btnStoreList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStoreList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStoreList.UseVisualStyleBackColor = true;
            this.btnStoreList.Click += new System.EventHandler(this.btnStoreList_Click);
            // 
            // btnStoreMgt
            // 
            this.btnStoreMgt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStoreMgt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStoreMgt.FlatAppearance.BorderSize = 0;
            this.btnStoreMgt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStoreMgt.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStoreMgt.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStoreMgt.Image = ((System.Drawing.Image)(resources.GetObject("btnStoreMgt.Image")));
            this.btnStoreMgt.Location = new System.Drawing.Point(0, 686);
            this.btnStoreMgt.Name = "btnStoreMgt";
            this.btnStoreMgt.Size = new System.Drawing.Size(183, 54);
            this.btnStoreMgt.TabIndex = 5;
            this.btnStoreMgt.Text = "  Store Management";
            this.btnStoreMgt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStoreMgt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStoreMgt.UseVisualStyleBackColor = true;
            this.btnStoreMgt.Click += new System.EventHandler(this.btnStoreMgt_Click);
            // 
            // pnlPriceMgt
            // 
            this.pnlPriceMgt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlPriceMgt.Controls.Add(this.btnPriceCategory);
            this.pnlPriceMgt.Controls.Add(this.btnPriceList);
            this.pnlPriceMgt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPriceMgt.Location = new System.Drawing.Point(0, 630);
            this.pnlPriceMgt.Name = "pnlPriceMgt";
            this.pnlPriceMgt.Size = new System.Drawing.Size(183, 56);
            this.pnlPriceMgt.TabIndex = 17;
            // 
            // btnPriceCategory
            // 
            this.btnPriceCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPriceCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPriceCategory.FlatAppearance.BorderSize = 0;
            this.btnPriceCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPriceCategory.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriceCategory.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPriceCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPriceCategory.Location = new System.Drawing.Point(0, 25);
            this.btnPriceCategory.Name = "btnPriceCategory";
            this.btnPriceCategory.Size = new System.Drawing.Size(183, 25);
            this.btnPriceCategory.TabIndex = 18;
            this.btnPriceCategory.Text = "          Price Category";
            this.btnPriceCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPriceCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPriceCategory.UseVisualStyleBackColor = true;
            this.btnPriceCategory.Click += new System.EventHandler(this.btnPriceCategory_Click);
            // 
            // btnPriceList
            // 
            this.btnPriceList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPriceList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPriceList.FlatAppearance.BorderSize = 0;
            this.btnPriceList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPriceList.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriceList.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPriceList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPriceList.Location = new System.Drawing.Point(0, 0);
            this.btnPriceList.Name = "btnPriceList";
            this.btnPriceList.Size = new System.Drawing.Size(183, 25);
            this.btnPriceList.TabIndex = 17;
            this.btnPriceList.Text = "          Price List";
            this.btnPriceList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPriceList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPriceList.UseVisualStyleBackColor = true;
            this.btnPriceList.Click += new System.EventHandler(this.btnPriceList_Click);
            // 
            // btnPriceMgt
            // 
            this.btnPriceMgt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPriceMgt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPriceMgt.FlatAppearance.BorderSize = 0;
            this.btnPriceMgt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPriceMgt.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriceMgt.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPriceMgt.Image = ((System.Drawing.Image)(resources.GetObject("btnPriceMgt.Image")));
            this.btnPriceMgt.Location = new System.Drawing.Point(0, 576);
            this.btnPriceMgt.Name = "btnPriceMgt";
            this.btnPriceMgt.Size = new System.Drawing.Size(183, 54);
            this.btnPriceMgt.TabIndex = 4;
            this.btnPriceMgt.Text = "  Price Management";
            this.btnPriceMgt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPriceMgt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPriceMgt.UseVisualStyleBackColor = true;
            this.btnPriceMgt.Click += new System.EventHandler(this.btnPriceMgt_Click);
            // 
            // pnlStockMgt
            // 
            this.pnlStockMgt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlStockMgt.Controls.Add(this.btnStockTransferHistory);
            this.pnlStockMgt.Controls.Add(this.btnStockTransfer);
            this.pnlStockMgt.Controls.Add(this.btnStockList);
            this.pnlStockMgt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStockMgt.Location = new System.Drawing.Point(0, 493);
            this.pnlStockMgt.Name = "pnlStockMgt";
            this.pnlStockMgt.Size = new System.Drawing.Size(183, 83);
            this.pnlStockMgt.TabIndex = 15;
            // 
            // btnStockTransferHistory
            // 
            this.btnStockTransferHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStockTransferHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockTransferHistory.FlatAppearance.BorderSize = 0;
            this.btnStockTransferHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockTransferHistory.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockTransferHistory.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStockTransferHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockTransferHistory.Location = new System.Drawing.Point(0, 50);
            this.btnStockTransferHistory.Name = "btnStockTransferHistory";
            this.btnStockTransferHistory.Size = new System.Drawing.Size(183, 25);
            this.btnStockTransferHistory.TabIndex = 19;
            this.btnStockTransferHistory.Text = "          Stock Transfer History";
            this.btnStockTransferHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockTransferHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStockTransferHistory.UseVisualStyleBackColor = true;
            this.btnStockTransferHistory.Click += new System.EventHandler(this.btnStockTransferHistory_Click_1);
            // 
            // btnStockTransfer
            // 
            this.btnStockTransfer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStockTransfer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockTransfer.FlatAppearance.BorderSize = 0;
            this.btnStockTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockTransfer.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockTransfer.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStockTransfer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockTransfer.Location = new System.Drawing.Point(0, 25);
            this.btnStockTransfer.Name = "btnStockTransfer";
            this.btnStockTransfer.Size = new System.Drawing.Size(183, 25);
            this.btnStockTransfer.TabIndex = 17;
            this.btnStockTransfer.Text = "          Stock Transfer";
            this.btnStockTransfer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockTransfer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStockTransfer.UseVisualStyleBackColor = true;
            this.btnStockTransfer.Click += new System.EventHandler(this.btnStockTransferHistory_Click);
            // 
            // btnStockList
            // 
            this.btnStockList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStockList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockList.FlatAppearance.BorderSize = 0;
            this.btnStockList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockList.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockList.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStockList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockList.Location = new System.Drawing.Point(0, 0);
            this.btnStockList.Name = "btnStockList";
            this.btnStockList.Size = new System.Drawing.Size(183, 25);
            this.btnStockList.TabIndex = 16;
            this.btnStockList.Text = "          Stock List";
            this.btnStockList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStockList.UseVisualStyleBackColor = true;
            this.btnStockList.Click += new System.EventHandler(this.btnStockList_Click);
            // 
            // btnStockMgt
            // 
            this.btnStockMgt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStockMgt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockMgt.FlatAppearance.BorderSize = 0;
            this.btnStockMgt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockMgt.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockMgt.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStockMgt.Image = ((System.Drawing.Image)(resources.GetObject("btnStockMgt.Image")));
            this.btnStockMgt.Location = new System.Drawing.Point(0, 439);
            this.btnStockMgt.Name = "btnStockMgt";
            this.btnStockMgt.Size = new System.Drawing.Size(183, 54);
            this.btnStockMgt.TabIndex = 3;
            this.btnStockMgt.Text = "  Stock Management";
            this.btnStockMgt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStockMgt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStockMgt.UseVisualStyleBackColor = true;
            this.btnStockMgt.Click += new System.EventHandler(this.btnStockMgt_Click);
            // 
            // pnlProductMgt
            // 
            this.pnlProductMgt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlProductMgt.Controls.Add(this.btnSeason);
            this.pnlProductMgt.Controls.Add(this.btnCategory);
            this.pnlProductMgt.Controls.Add(this.btnDepartment);
            this.pnlProductMgt.Controls.Add(this.btnItem);
            this.pnlProductMgt.Controls.Add(this.btnArticleSeason);
            this.pnlProductMgt.Controls.Add(this.btnArticle);
            this.pnlProductMgt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProductMgt.Location = new System.Drawing.Point(0, 279);
            this.pnlProductMgt.Name = "pnlProductMgt";
            this.pnlProductMgt.Size = new System.Drawing.Size(183, 160);
            this.pnlProductMgt.TabIndex = 13;
            // 
            // btnSeason
            // 
            this.btnSeason.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeason.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSeason.FlatAppearance.BorderSize = 0;
            this.btnSeason.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeason.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeason.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSeason.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeason.Location = new System.Drawing.Point(0, 125);
            this.btnSeason.Name = "btnSeason";
            this.btnSeason.Size = new System.Drawing.Size(183, 25);
            this.btnSeason.TabIndex = 22;
            this.btnSeason.Text = "          Season";
            this.btnSeason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeason.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSeason.UseVisualStyleBackColor = true;
            this.btnSeason.Click += new System.EventHandler(this.btnSeason_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategory.FlatAppearance.BorderSize = 0;
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.Location = new System.Drawing.Point(0, 100);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(183, 25);
            this.btnCategory.TabIndex = 21;
            this.btnCategory.Text = "          Category";
            this.btnCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnDepartment
            // 
            this.btnDepartment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDepartment.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDepartment.FlatAppearance.BorderSize = 0;
            this.btnDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepartment.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepartment.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDepartment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepartment.Location = new System.Drawing.Point(0, 75);
            this.btnDepartment.Name = "btnDepartment";
            this.btnDepartment.Size = new System.Drawing.Size(183, 25);
            this.btnDepartment.TabIndex = 20;
            this.btnDepartment.Text = "          Department";
            this.btnDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepartment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDepartment.UseVisualStyleBackColor = true;
            this.btnDepartment.Click += new System.EventHandler(this.btnDepartment_Click);
            // 
            // btnItem
            // 
            this.btnItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnItem.FlatAppearance.BorderSize = 0;
            this.btnItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItem.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItem.ForeColor = System.Drawing.SystemColors.Control;
            this.btnItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnItem.Location = new System.Drawing.Point(0, 50);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(183, 25);
            this.btnItem.TabIndex = 19;
            this.btnItem.Text = "          Item";
            this.btnItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnItem.UseVisualStyleBackColor = true;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // btnArticleSeason
            // 
            this.btnArticleSeason.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArticleSeason.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnArticleSeason.FlatAppearance.BorderSize = 0;
            this.btnArticleSeason.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArticleSeason.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArticleSeason.ForeColor = System.Drawing.SystemColors.Control;
            this.btnArticleSeason.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArticleSeason.Location = new System.Drawing.Point(0, 25);
            this.btnArticleSeason.Name = "btnArticleSeason";
            this.btnArticleSeason.Size = new System.Drawing.Size(183, 25);
            this.btnArticleSeason.TabIndex = 18;
            this.btnArticleSeason.Text = "          Article Season";
            this.btnArticleSeason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArticleSeason.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnArticleSeason.UseVisualStyleBackColor = true;
            this.btnArticleSeason.Click += new System.EventHandler(this.btnArticleSeason_Click);
            // 
            // btnArticle
            // 
            this.btnArticle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArticle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnArticle.FlatAppearance.BorderSize = 0;
            this.btnArticle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArticle.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArticle.ForeColor = System.Drawing.SystemColors.Control;
            this.btnArticle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArticle.Location = new System.Drawing.Point(0, 0);
            this.btnArticle.Name = "btnArticle";
            this.btnArticle.Size = new System.Drawing.Size(183, 25);
            this.btnArticle.TabIndex = 9;
            this.btnArticle.Text = "          Article";
            this.btnArticle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArticle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnArticle.UseVisualStyleBackColor = true;
            this.btnArticle.Click += new System.EventHandler(this.btnArticle_Click);
            // 
            // btnProductMgt
            // 
            this.btnProductMgt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductMgt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductMgt.FlatAppearance.BorderSize = 0;
            this.btnProductMgt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductMgt.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductMgt.ForeColor = System.Drawing.SystemColors.Control;
            this.btnProductMgt.Image = ((System.Drawing.Image)(resources.GetObject("btnProductMgt.Image")));
            this.btnProductMgt.Location = new System.Drawing.Point(0, 225);
            this.btnProductMgt.Name = "btnProductMgt";
            this.btnProductMgt.Size = new System.Drawing.Size(183, 54);
            this.btnProductMgt.TabIndex = 2;
            this.btnProductMgt.Text = "  Product Management";
            this.btnProductMgt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductMgt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProductMgt.UseVisualStyleBackColor = true;
            this.btnProductMgt.Click += new System.EventHandler(this.btnProductMgt_Click);
            // 
            // pnlStaffMgt
            // 
            this.pnlStaffMgt.AutoScroll = true;
            this.pnlStaffMgt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlStaffMgt.Controls.Add(this.btnMutation);
            this.pnlStaffMgt.Controls.Add(this.btnPosition);
            this.pnlStaffMgt.Controls.Add(this.btnStaff);
            this.pnlStaffMgt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStaffMgt.Location = new System.Drawing.Point(0, 146);
            this.pnlStaffMgt.Name = "pnlStaffMgt";
            this.pnlStaffMgt.Size = new System.Drawing.Size(183, 79);
            this.pnlStaffMgt.TabIndex = 11;
            // 
            // btnMutation
            // 
            this.btnMutation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMutation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMutation.FlatAppearance.BorderSize = 0;
            this.btnMutation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMutation.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMutation.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMutation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMutation.Location = new System.Drawing.Point(0, 50);
            this.btnMutation.Name = "btnMutation";
            this.btnMutation.Size = new System.Drawing.Size(183, 25);
            this.btnMutation.TabIndex = 8;
            this.btnMutation.Text = "          Mutation";
            this.btnMutation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMutation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMutation.UseVisualStyleBackColor = true;
            this.btnMutation.Click += new System.EventHandler(this.btnMutation_Click);
            // 
            // btnPosition
            // 
            this.btnPosition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPosition.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPosition.FlatAppearance.BorderSize = 0;
            this.btnPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPosition.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPosition.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPosition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPosition.Location = new System.Drawing.Point(0, 25);
            this.btnPosition.Name = "btnPosition";
            this.btnPosition.Size = new System.Drawing.Size(183, 25);
            this.btnPosition.TabIndex = 7;
            this.btnPosition.Text = "          Position";
            this.btnPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPosition.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPosition.UseVisualStyleBackColor = true;
            this.btnPosition.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStaff.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStaff.FlatAppearance.BorderSize = 0;
            this.btnStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaff.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaff.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStaff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff.Location = new System.Drawing.Point(0, 0);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(183, 25);
            this.btnStaff.TabIndex = 6;
            this.btnStaff.Text = "          Staff";
            this.btnStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStaff.UseVisualStyleBackColor = true;
            this.btnStaff.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStaffMgt
            // 
            this.btnStaffMgt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStaffMgt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStaffMgt.FlatAppearance.BorderSize = 0;
            this.btnStaffMgt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaffMgt.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaffMgt.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStaffMgt.Image = ((System.Drawing.Image)(resources.GetObject("btnStaffMgt.Image")));
            this.btnStaffMgt.Location = new System.Drawing.Point(0, 92);
            this.btnStaffMgt.Name = "btnStaffMgt";
            this.btnStaffMgt.Size = new System.Drawing.Size(183, 54);
            this.btnStaffMgt.TabIndex = 1;
            this.btnStaffMgt.Text = "      Staff Management";
            this.btnStaffMgt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStaffMgt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStaffMgt.UseVisualStyleBackColor = true;
            this.btnStaffMgt.Click += new System.EventHandler(this.btnStaffMgt_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(183, 92);
            this.panel3.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(25, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnMinimize);
            this.pnlTop.Controls.Add(this.btnMaximize);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(200, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(684, 60);
            this.pnlTop.TabIndex = 1;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinimize.BackgroundImage")));
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.Color.Black;
            this.btnMinimize.Location = new System.Drawing.Point(561, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(33, 33);
            this.btnMinimize.TabIndex = 8;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMaximize.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMaximize.BackgroundImage")));
            this.btnMaximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.ForeColor = System.Drawing.Color.Black;
            this.btnMaximize.Location = new System.Drawing.Point(600, 12);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(33, 33);
            this.btnMaximize.TabIndex = 7;
            this.btnMaximize.UseVisualStyleBackColor = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Raleway", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(14, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(371, 18);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Topman Indonesia Management && Inventory Control";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(200, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(684, 5);
            this.panel2.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.Controls.Add(this.lblWelcome);
            this.panel4.Controls.Add(this.btnLogout);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(200, 65);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(684, 27);
            this.panel4.TabIndex = 5;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblWelcome.Font = new System.Drawing.Font("Raleway", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(535, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Padding = new System.Windows.Forms.Padding(0, 6, 10, 0);
            this.lblWelcome.Size = new System.Drawing.Size(77, 20);
            this.lblWelcome.TabIndex = 15;
            this.lblWelcome.Text = "Welcome, ";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Raleway", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(612, 0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(72, 27);
            this.btnLogout.TabIndex = 15;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.ucWelcome1);
            this.pnlContent.Controls.Add(this.ucSalesHistory1);
            this.pnlContent.Controls.Add(this.ucStoreList1);
            this.pnlContent.Controls.Add(this.ucPriceCategory1);
            this.pnlContent.Controls.Add(this.ucPriceList1);
            this.pnlContent.Controls.Add(this.ucStockTransferHistory1);
            this.pnlContent.Controls.Add(this.ucStockList1);
            this.pnlContent.Controls.Add(this.ucSeason1);
            this.pnlContent.Controls.Add(this.ucCategory1);
            this.pnlContent.Controls.Add(this.ucDepartment1);
            this.pnlContent.Controls.Add(this.ucItem1);
            this.pnlContent.Controls.Add(this.ucMutation1);
            this.pnlContent.Controls.Add(this.ucPosition1);
            this.pnlContent.Controls.Add(this.ucStaffData1);
            this.pnlContent.Controls.Add(this.ucArticle1);
            this.pnlContent.Controls.Add(this.ucArticleSeason1);
            this.pnlContent.Controls.Add(this.ucStockTransfer1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(200, 92);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(684, 690);
            this.pnlContent.TabIndex = 6;
            // 
            // ucWelcome1
            // 
            this.ucWelcome1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWelcome1.Location = new System.Drawing.Point(0, 0);
            this.ucWelcome1.Name = "ucWelcome1";
            this.ucWelcome1.Size = new System.Drawing.Size(684, 690);
            this.ucWelcome1.TabIndex = 0;
            // 
            // ucSalesHistory1
            // 
            this.ucSalesHistory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSalesHistory1.Location = new System.Drawing.Point(0, 0);
            this.ucSalesHistory1.Name = "ucSalesHistory1";
            this.ucSalesHistory1.Size = new System.Drawing.Size(684, 690);
            this.ucSalesHistory1.TabIndex = 14;
            // 
            // ucStoreList1
            // 
            this.ucStoreList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStoreList1.Location = new System.Drawing.Point(0, 0);
            this.ucStoreList1.Name = "ucStoreList1";
            this.ucStoreList1.Size = new System.Drawing.Size(684, 690);
            this.ucStoreList1.TabIndex = 13;
            // 
            // ucPriceCategory1
            // 
            this.ucPriceCategory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPriceCategory1.Location = new System.Drawing.Point(0, 0);
            this.ucPriceCategory1.Name = "ucPriceCategory1";
            this.ucPriceCategory1.Size = new System.Drawing.Size(684, 690);
            this.ucPriceCategory1.TabIndex = 12;
            // 
            // ucPriceList1
            // 
            this.ucPriceList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPriceList1.Location = new System.Drawing.Point(0, 0);
            this.ucPriceList1.Name = "ucPriceList1";
            this.ucPriceList1.Size = new System.Drawing.Size(684, 690);
            this.ucPriceList1.TabIndex = 11;
            // 
            // ucStockTransferHistory1
            // 
            this.ucStockTransferHistory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStockTransferHistory1.Location = new System.Drawing.Point(0, 0);
            this.ucStockTransferHistory1.Name = "ucStockTransferHistory1";
            this.ucStockTransferHistory1.Size = new System.Drawing.Size(684, 690);
            this.ucStockTransferHistory1.TabIndex = 10;
            // 
            // ucStockList1
            // 
            this.ucStockList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStockList1.Location = new System.Drawing.Point(0, 0);
            this.ucStockList1.Name = "ucStockList1";
            this.ucStockList1.Size = new System.Drawing.Size(684, 690);
            this.ucStockList1.TabIndex = 9;
            // 
            // ucSeason1
            // 
            this.ucSeason1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSeason1.Location = new System.Drawing.Point(0, 0);
            this.ucSeason1.Name = "ucSeason1";
            this.ucSeason1.Size = new System.Drawing.Size(684, 690);
            this.ucSeason1.TabIndex = 8;
            // 
            // ucCategory1
            // 
            this.ucCategory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCategory1.Location = new System.Drawing.Point(0, 0);
            this.ucCategory1.Name = "ucCategory1";
            this.ucCategory1.Size = new System.Drawing.Size(684, 690);
            this.ucCategory1.TabIndex = 7;
            // 
            // ucDepartment1
            // 
            this.ucDepartment1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDepartment1.Location = new System.Drawing.Point(0, 0);
            this.ucDepartment1.Name = "ucDepartment1";
            this.ucDepartment1.Size = new System.Drawing.Size(684, 690);
            this.ucDepartment1.TabIndex = 6;
            // 
            // ucItem1
            // 
            this.ucItem1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucItem1.Location = new System.Drawing.Point(0, 0);
            this.ucItem1.Name = "ucItem1";
            this.ucItem1.Size = new System.Drawing.Size(684, 690);
            this.ucItem1.TabIndex = 5;
            // 
            // ucMutation1
            // 
            this.ucMutation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMutation1.Location = new System.Drawing.Point(0, 0);
            this.ucMutation1.Name = "ucMutation1";
            this.ucMutation1.Size = new System.Drawing.Size(684, 690);
            this.ucMutation1.TabIndex = 4;
            // 
            // ucPosition1
            // 
            this.ucPosition1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPosition1.Location = new System.Drawing.Point(0, 0);
            this.ucPosition1.Name = "ucPosition1";
            this.ucPosition1.Size = new System.Drawing.Size(684, 690);
            this.ucPosition1.TabIndex = 3;
            // 
            // ucStaffData1
            // 
            this.ucStaffData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStaffData1.Location = new System.Drawing.Point(0, 0);
            this.ucStaffData1.Name = "ucStaffData1";
            this.ucStaffData1.Size = new System.Drawing.Size(684, 690);
            this.ucStaffData1.TabIndex = 2;
            // 
            // ucArticle1
            // 
            this.ucArticle1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucArticle1.Location = new System.Drawing.Point(0, 0);
            this.ucArticle1.Name = "ucArticle1";
            this.ucArticle1.Size = new System.Drawing.Size(684, 690);
            this.ucArticle1.TabIndex = 15;
            // 
            // ucArticleSeason1
            // 
            this.ucArticleSeason1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucArticleSeason1.Location = new System.Drawing.Point(0, 0);
            this.ucArticleSeason1.Name = "ucArticleSeason1";
            this.ucArticleSeason1.Size = new System.Drawing.Size(684, 690);
            this.ucArticleSeason1.TabIndex = 16;
            // 
            // ucStockTransfer1
            // 
            this.ucStockTransfer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStockTransfer1.Location = new System.Drawing.Point(0, 0);
            this.ucStockTransfer1.Name = "ucStockTransfer1";
            this.ucStockTransfer1.Size = new System.Drawing.Size(684, 690);
            this.ucStockTransfer1.TabIndex = 17;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 782);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlNavbar);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.pnlNavbar.ResumeLayout(false);
            this.pnlStoreMgt.ResumeLayout(false);
            this.pnlPriceMgt.ResumeLayout(false);
            this.pnlStockMgt.ResumeLayout(false);
            this.pnlProductMgt.ResumeLayout(false);
            this.pnlStaffMgt.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlNavbar;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnStaffMgt;
        private System.Windows.Forms.Panel pnlContent;
        public UCWelcome ucWelcome1;
        public UCStaffData ucStaffData1;
        private System.Windows.Forms.Panel pnlStaffMgt;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnMutation;
        private System.Windows.Forms.Button btnPosition;
        private System.Windows.Forms.Button btnProductMgt;
        private System.Windows.Forms.Panel pnlProductMgt;
        private System.Windows.Forms.Button btnStockMgt;
        private System.Windows.Forms.Panel pnlStockMgt;
        private System.Windows.Forms.Button btnStockTransfer;
        private System.Windows.Forms.Button btnStockList;
        private System.Windows.Forms.Button btnPriceMgt;
        private System.Windows.Forms.Panel pnlPriceMgt;
        private System.Windows.Forms.Button btnPriceCategory;
        private System.Windows.Forms.Button btnPriceList;
        private System.Windows.Forms.Panel pnlStoreMgt;
        private System.Windows.Forms.Button btnSalesHistory;
        private System.Windows.Forms.Button btnStoreList;
        private System.Windows.Forms.Button btnStoreMgt;
        private UCPosition ucPosition1;
        private UCMutation ucMutation1;
        private UCItem ucItem1;
        private UCDepartment ucDepartment1;
        private UCCategory ucCategory1;
        private UCSeason ucSeason1;
        private UCStockList ucStockList1;
        private UCStockTransferHistory ucStockTransferHistory1;
        private UCPriceList ucPriceList1;
        private UCPriceCategory ucPriceCategory1;
        private UCStoreList ucStoreList1;
        private UCSalesHistory ucSalesHistory1;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnArticle;
        private UCArticle ucArticle1;
        private UCArticleSeason ucArticleSeason1;
        private System.Windows.Forms.Button btnArticleSeason;
        private System.Windows.Forms.Button btnSeason;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnDepartment;
        private System.Windows.Forms.Button btnItem;
        private UCStockTransfer ucStockTransfer1;
        private System.Windows.Forms.Button btnStockTransferHistory;



    }
}

