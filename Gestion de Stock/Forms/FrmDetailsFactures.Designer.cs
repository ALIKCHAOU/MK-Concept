namespace Gestion_de_Stock.Forms
{
    partial class FrmDetailsFactures
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
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.ligneFactureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrixHT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemise = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalLigneHT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalLigneTTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ligneFactureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(905, 487);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.ligneFactureBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gridControl1.Location = new System.Drawing.Point(16, 16);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(873, 455);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // ligneFactureBindingSource
            // 
            this.ligneFactureBindingSource.DataSource = typeof(Gestion_de_Stock.Model.ligneFacture);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDescription,
            this.colPrixHT,
            this.colQty,
            this.colRemise,
            this.colTVA,
            this.colTotalLigneHT,
            this.colTotalLigneTTC});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescription.AppearanceHeader.Options.UseFont = true;
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 0;
            // 
            // colPrixHT
            // 
            this.colPrixHT.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPrixHT.AppearanceHeader.Options.UseFont = true;
            this.colPrixHT.DisplayFormat.FormatString = "f3";
            this.colPrixHT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrixHT.FieldName = "PrixHT";
            this.colPrixHT.Name = "colPrixHT";
            this.colPrixHT.OptionsColumn.AllowEdit = false;
            this.colPrixHT.Visible = true;
            this.colPrixHT.VisibleIndex = 1;
            // 
            // colQty
            // 
            this.colQty.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colQty.AppearanceHeader.Options.UseFont = true;
            this.colQty.Caption = "Quantité";
            this.colQty.DisplayFormat.FormatString = "f0";
            this.colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.OptionsColumn.AllowEdit = false;
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 2;
            // 
            // colRemise
            // 
            this.colRemise.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colRemise.AppearanceHeader.Options.UseFont = true;
            this.colRemise.FieldName = "Remise";
            this.colRemise.Name = "colRemise";
            this.colRemise.OptionsColumn.AllowEdit = false;
            this.colRemise.Visible = true;
            this.colRemise.VisibleIndex = 3;
            // 
            // colTVA
            // 
            this.colTVA.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTVA.AppearanceHeader.Options.UseFont = true;
            this.colTVA.DisplayFormat.FormatString = "f0";
            this.colTVA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTVA.FieldName = "TVA";
            this.colTVA.Name = "colTVA";
            this.colTVA.OptionsColumn.AllowEdit = false;
            this.colTVA.Visible = true;
            this.colTVA.VisibleIndex = 5;
            // 
            // colTotalLigneHT
            // 
            this.colTotalLigneHT.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTotalLigneHT.AppearanceHeader.Options.UseFont = true;
            this.colTotalLigneHT.Caption = "Total HT";
            this.colTotalLigneHT.DisplayFormat.FormatString = "n3";
            this.colTotalLigneHT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalLigneHT.FieldName = "TotalLigneHT";
            this.colTotalLigneHT.Name = "colTotalLigneHT";
            this.colTotalLigneHT.OptionsColumn.AllowEdit = false;
            this.colTotalLigneHT.OptionsColumn.ReadOnly = true;
            this.colTotalLigneHT.Visible = true;
            this.colTotalLigneHT.VisibleIndex = 4;
            // 
            // colTotalLigneTTC
            // 
            this.colTotalLigneTTC.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTotalLigneTTC.AppearanceHeader.Options.UseFont = true;
            this.colTotalLigneTTC.Caption = "Total TTC";
            this.colTotalLigneTTC.DisplayFormat.FormatString = "n3";
            this.colTotalLigneTTC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalLigneTTC.FieldName = "TotalLigneTTC";
            this.colTotalLigneTTC.Name = "colTotalLigneTTC";
            this.colTotalLigneTTC.OptionsColumn.AllowEdit = false;
            this.colTotalLigneTTC.OptionsColumn.ReadOnly = true;
            this.colTotalLigneTTC.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalLigneTTC", "={0:n3}")});
            this.colTotalLigneTTC.Visible = true;
            this.colTotalLigneTTC.VisibleIndex = 6;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(905, 487);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(879, 461);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // FrmDetailsFactures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 487);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmDetailsFactures";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Détails de  Factures";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDetaisFactures_FormClosed);
            this.Load += new System.EventHandler(this.FrmDetaisFactures_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ligneFactureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colPrixHT;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colRemise;
        private DevExpress.XtraGrid.Columns.GridColumn colTVA;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalLigneHT;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalLigneTTC;
        public System.Windows.Forms.BindingSource ligneFactureBindingSource;
    }
}