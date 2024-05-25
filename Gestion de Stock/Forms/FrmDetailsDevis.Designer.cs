namespace Gestion_de_Stock.Forms
{
    partial class FrmDetailsDevis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetailsDevis));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.TxtCodeDevis = new DevExpress.XtraEditors.TextEdit();
            this.TxtClient = new DevExpress.XtraEditors.TextEdit();
            this.BtnEnregister = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.ligneDevisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColSupprimer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colLibelleServices = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SearchLookUpPack = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.packBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPrixHT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBoxListePrice = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemise = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalLigneHt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.TotalLigneTTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TVA = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCodeDevis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtClient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ligneDevisBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookUpPack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxListePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(913, 370);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(889, 346);
            this.groupControl1.TabIndex = 4;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.TxtCodeDevis);
            this.layoutControl2.Controls.Add(this.TxtClient);
            this.layoutControl2.Controls.Add(this.BtnEnregister);
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 20);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(885, 324);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // TxtCodeDevis
            // 
            this.TxtCodeDevis.Location = new System.Drawing.Point(49, 12);
            this.TxtCodeDevis.Name = "TxtCodeDevis";
            this.TxtCodeDevis.Properties.ReadOnly = true;
            this.TxtCodeDevis.Size = new System.Drawing.Size(391, 20);
            this.TxtCodeDevis.StyleController = this.layoutControl2;
            this.TxtCodeDevis.TabIndex = 7;
            // 
            // TxtClient
            // 
            this.TxtClient.Location = new System.Drawing.Point(481, 12);
            this.TxtClient.Name = "TxtClient";
            this.TxtClient.Properties.ReadOnly = true;
            this.TxtClient.Size = new System.Drawing.Size(392, 20);
            this.TxtClient.StyleController = this.layoutControl2;
            this.TxtClient.TabIndex = 6;
            // 
            // BtnEnregister
            // 
            this.BtnEnregister.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnregister.Appearance.Options.UseFont = true;
            this.BtnEnregister.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnEnregister.ImageOptions.Image")));
            this.BtnEnregister.Location = new System.Drawing.Point(773, 290);
            this.BtnEnregister.Name = "BtnEnregister";
            this.BtnEnregister.Size = new System.Drawing.Size(100, 22);
            this.BtnEnregister.StyleController = this.layoutControl2;
            this.BtnEnregister.TabIndex = 5;
            this.BtnEnregister.Text = "Enregister";
            this.BtnEnregister.Click += new System.EventHandler(this.BtnEnregister_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.ligneDevisBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 36);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.SearchLookUpPack,
            this.repositoryItemComboBoxListePrice,
            this.repositoryItemButtonDelete});
            this.gridControl1.Size = new System.Drawing.Size(861, 250);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // ligneDevisBindingSource
            // 
            this.ligneDevisBindingSource.DataSource = typeof(Gestion_de_Stock.Model.ligneDevis);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TotalLigneTTC,
            this.ColSupprimer,
            this.colLibelleServices,
            this.colPrixHT,
            this.colQty,
            this.colRemise,
            this.colTotalLigneHt,
            this.TVA});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ColSupprimer
            // 
            this.ColSupprimer.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColSupprimer.AppearanceHeader.Options.UseFont = true;
            this.ColSupprimer.Caption = "Supprimer";
            this.ColSupprimer.ColumnEdit = this.repositoryItemButtonDelete;
            this.ColSupprimer.Name = "ColSupprimer";
            this.ColSupprimer.Visible = true;
            this.ColSupprimer.VisibleIndex = 7;
            // 
            // repositoryItemButtonDelete
            // 
            this.repositoryItemButtonDelete.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.repositoryItemButtonDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions2, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.repositoryItemButtonDelete.Name = "repositoryItemButtonDelete";
            this.repositoryItemButtonDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonDelete.Click += new System.EventHandler(this.repositoryItemButtonDelete_Click);
            // 
            // colLibelleServices
            // 
            this.colLibelleServices.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colLibelleServices.AppearanceHeader.Options.UseFont = true;
            this.colLibelleServices.FieldName = "Description";
            this.colLibelleServices.Name = "colLibelleServices";
            this.colLibelleServices.Visible = true;
            this.colLibelleServices.VisibleIndex = 0;
            this.colLibelleServices.Width = 73;
            // 
            // SearchLookUpPack
            // 
            this.SearchLookUpPack.AutoHeight = false;
            this.SearchLookUpPack.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookUpPack.DataSource = this.packBindingSource;
            this.SearchLookUpPack.DisplayMember = "Designation";
            this.SearchLookUpPack.Name = "SearchLookUpPack";
            this.SearchLookUpPack.NullText = "Sélectionner Pack";
            this.SearchLookUpPack.ValueMember = "Designation";
            this.SearchLookUpPack.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // packBindingSource
            // 
            this.packBindingSource.DataSource = typeof(Gestion_de_Stock.Model.Article);
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colPrixHT
            // 
            this.colPrixHT.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPrixHT.AppearanceHeader.Options.UseFont = true;
            this.colPrixHT.ColumnEdit = this.repositoryItemComboBoxListePrice;
            this.colPrixHT.DisplayFormat.FormatString = "f3";
            this.colPrixHT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrixHT.FieldName = "PrixHT";
            this.colPrixHT.Name = "colPrixHT";
            this.colPrixHT.Visible = true;
            this.colPrixHT.VisibleIndex = 1;
            // 
            // repositoryItemComboBoxListePrice
            // 
            this.repositoryItemComboBoxListePrice.AutoHeight = false;
            this.repositoryItemComboBoxListePrice.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBoxListePrice.Name = "repositoryItemComboBoxListePrice";
            // 
            // colQty
            // 
            this.colQty.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colQty.AppearanceHeader.Options.UseFont = true;
            this.colQty.Caption = "Quantité";
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 2;
            // 
            // colRemise
            // 
            this.colRemise.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colRemise.AppearanceHeader.Options.UseFont = true;
            this.colRemise.FieldName = "Remise";
            this.colRemise.Name = "colRemise";
            this.colRemise.Visible = true;
            this.colRemise.VisibleIndex = 4;
            // 
            // colTotalLigneHt
            // 
            this.colTotalLigneHt.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTotalLigneHt.AppearanceHeader.Options.UseFont = true;
            this.colTotalLigneHt.Caption = "Total HT";
            this.colTotalLigneHt.DisplayFormat.FormatString = "f3";
            this.colTotalLigneHt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalLigneHt.FieldName = "TotalLigneHT";
            this.colTotalLigneHt.Name = "colTotalLigneHt";
            this.colTotalLigneHt.OptionsColumn.ReadOnly = true;
            this.colTotalLigneHt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalLigneHT", "={0:n3}")});
            this.colTotalLigneHt.Visible = true;
            this.colTotalLigneHt.VisibleIndex = 5;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(885, 324);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(865, 254);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.BtnEnregister;
            this.layoutControlItem3.Location = new System.Drawing.Point(761, 278);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(104, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 278);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(761, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.TxtClient;
            this.layoutControlItem4.Location = new System.Drawing.Point(432, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(433, 24);
            this.layoutControlItem4.Text = "Client";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(34, 15);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.TxtCodeDevis;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(432, 24);
            this.layoutControlItem5.Text = "Code";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(34, 15);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(913, 370);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(893, 350);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // TotalLigneTTC
            // 
            this.TotalLigneTTC.Caption = "Total TTC";
            this.TotalLigneTTC.DisplayFormat.FormatString = "n3";
            this.TotalLigneTTC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TotalLigneTTC.FieldName = "TotalLigneTTC";
            this.TotalLigneTTC.Name = "TotalLigneTTC";
            this.TotalLigneTTC.Visible = true;
            this.TotalLigneTTC.VisibleIndex = 6;
            // 
            // TVA
            // 
            this.TVA.Caption = "TVA";
            this.TVA.FieldName = "TVA";
            this.TVA.Name = "TVA";
            this.TVA.Visible = true;
            this.TVA.VisibleIndex = 3;
            // 
            // FrmDetailsDevis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 370);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmDetailsDevis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Détails de  Devis";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDetaisDevis_FormClosed);
            this.Load += new System.EventHandler(this.FrmDetaisDevis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TxtCodeDevis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtClient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ligneDevisBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookUpPack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxListePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colLibelleServices;
        private DevExpress.XtraGrid.Columns.GridColumn colPrixHT;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colRemise;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalLigneHt;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        public System.Windows.Forms.BindingSource ligneDevisBindingSource;
        private DevExpress.XtraEditors.SimpleButton BtnEnregister;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        public DevExpress.XtraEditors.TextEdit TxtCodeDevis;
        public DevExpress.XtraEditors.TextEdit TxtClient;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit SearchLookUpPack;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private System.Windows.Forms.BindingSource packBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxListePrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonDelete;
        private DevExpress.XtraGrid.Columns.GridColumn ColSupprimer;
        private DevExpress.XtraGrid.Columns.GridColumn TotalLigneTTC;
        private DevExpress.XtraGrid.Columns.GridColumn TVA;
    }
}