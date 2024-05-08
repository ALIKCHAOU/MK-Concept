namespace Gestion_de_Stock.Forms
{
    partial class FrmListeFactures
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListeFactures));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions4 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.BtnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnExportPdF = new DevExpress.XtraEditors.SimpleButton();
            this.DateFin = new DevExpress.XtraEditors.DateEdit();
            this.DateDebut = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.factureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GCNdevis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateFacture = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal_FactureHT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal_FactureTTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCertificateRS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtoncolCertificateRS = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.GCViewDocuement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEditViewDocument = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.GcLIgnefacture = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryLignefacture = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.GvImprimer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEditImprimer = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDebut.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDebut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.factureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtoncolCertificateRS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditViewDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryLignefacture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditImprimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
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
            this.layoutControl1.Size = new System.Drawing.Size(977, 422);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(953, 398);
            this.groupControl1.TabIndex = 4;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.BtnExportExcel);
            this.layoutControl2.Controls.Add(this.BtnExportPdF);
            this.layoutControl2.Controls.Add(this.DateFin);
            this.layoutControl2.Controls.Add(this.DateDebut);
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 20);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(949, 376);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // BtnExportExcel
            // 
            this.BtnExportExcel.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportExcel.Appearance.Options.UseFont = true;
            this.BtnExportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnExportExcel.ImageOptions.Image")));
            this.BtnExportExcel.Location = new System.Drawing.Point(475, 36);
            this.BtnExportExcel.Name = "BtnExportExcel";
            this.BtnExportExcel.Size = new System.Drawing.Size(229, 22);
            this.BtnExportExcel.StyleController = this.layoutControl2;
            this.BtnExportExcel.TabIndex = 8;
            this.BtnExportExcel.Text = "Export Excel";
            this.BtnExportExcel.Click += new System.EventHandler(this.BtnExportExcel_Click);
            // 
            // BtnExportPdF
            // 
            this.BtnExportPdF.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportPdF.Appearance.Options.UseFont = true;
            this.BtnExportPdF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnExportPdF.ImageOptions.Image")));
            this.BtnExportPdF.Location = new System.Drawing.Point(708, 36);
            this.BtnExportPdF.Name = "BtnExportPdF";
            this.BtnExportPdF.Size = new System.Drawing.Size(229, 22);
            this.BtnExportPdF.StyleController = this.layoutControl2;
            this.BtnExportPdF.TabIndex = 7;
            this.BtnExportPdF.Text = "Export PDF";
            this.BtnExportPdF.Click += new System.EventHandler(this.BtnExportPdF_Click);
            // 
            // DateFin
            // 
            this.DateFin.EditValue = null;
            this.DateFin.Location = new System.Drawing.Point(538, 12);
            this.DateFin.Name = "DateFin";
            this.DateFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateFin.Size = new System.Drawing.Size(399, 20);
            this.DateFin.StyleController = this.layoutControl2;
            this.DateFin.TabIndex = 6;
            this.DateFin.EditValueChanged += new System.EventHandler(this.DateFin_EditValueChanged);
            // 
            // DateDebut
            // 
            this.DateDebut.EditValue = null;
            this.DateDebut.Location = new System.Drawing.Point(75, 12);
            this.DateDebut.Name = "DateDebut";
            this.DateDebut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateDebut.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateDebut.Size = new System.Drawing.Size(396, 20);
            this.DateDebut.StyleController = this.layoutControl2;
            this.DateDebut.TabIndex = 5;
            this.DateDebut.EditValueChanged += new System.EventHandler(this.DateDebut_EditValueChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.factureBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 62);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtoncolCertificateRS,
            this.repositoryItemButtonEditViewDocument,
            this.repositoryLignefacture,
            this.repositoryItemButtonEditImprimer});
            this.gridControl1.Size = new System.Drawing.Size(925, 302);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // factureBindingSource
            // 
            this.factureBindingSource.DataSource = typeof(Gestion_de_Stock.Model.Facture);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GCNdevis,
            this.colCode,
            this.colReference,
            this.colDateFacture,
            this.colTVA,
            this.colTotal_FactureHT,
            this.colTotal_FactureTTC,
            this.colClient,
            this.colCertificateRS,
            this.GCViewDocuement,
            this.GcLIgnefacture,
            this.GvImprimer});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // GCNdevis
            // 
            this.GCNdevis.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GCNdevis.AppearanceHeader.Options.UseFont = true;
            this.GCNdevis.Caption = "N° Doc Origine";
            this.GCNdevis.FieldName = "NumeoDocument";
            this.GCNdevis.Name = "GCNdevis";
            this.GCNdevis.OptionsColumn.AllowEdit = false;
            this.GCNdevis.Visible = true;
            this.GCNdevis.VisibleIndex = 1;
            this.GCNdevis.Width = 96;
            // 
            // colCode
            // 
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            // 
            // colReference
            // 
            this.colReference.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colReference.AppearanceHeader.Options.UseFont = true;
            this.colReference.FieldName = "Reference";
            this.colReference.Name = "colReference";
            this.colReference.OptionsColumn.AllowEdit = false;
            this.colReference.Visible = true;
            this.colReference.VisibleIndex = 3;
            this.colReference.Width = 72;
            // 
            // colDateFacture
            // 
            this.colDateFacture.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDateFacture.AppearanceHeader.Options.UseFont = true;
            this.colDateFacture.Caption = "Date";
            this.colDateFacture.FieldName = "DateFacture";
            this.colDateFacture.Name = "colDateFacture";
            this.colDateFacture.OptionsColumn.AllowEdit = false;
            this.colDateFacture.Visible = true;
            this.colDateFacture.VisibleIndex = 4;
            this.colDateFacture.Width = 72;
            // 
            // colTVA
            // 
            this.colTVA.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTVA.AppearanceHeader.Options.UseFont = true;
            this.colTVA.FieldName = "TVA";
            this.colTVA.Name = "colTVA";
            this.colTVA.OptionsColumn.AllowEdit = false;
            this.colTVA.Visible = true;
            this.colTVA.VisibleIndex = 5;
            this.colTVA.Width = 72;
            // 
            // colTotal_FactureHT
            // 
            this.colTotal_FactureHT.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTotal_FactureHT.AppearanceHeader.Options.UseFont = true;
            this.colTotal_FactureHT.Caption = "Total HT";
            this.colTotal_FactureHT.FieldName = "Total_FactureHT";
            this.colTotal_FactureHT.Name = "colTotal_FactureHT";
            this.colTotal_FactureHT.OptionsColumn.AllowEdit = false;
            this.colTotal_FactureHT.Visible = true;
            this.colTotal_FactureHT.VisibleIndex = 6;
            this.colTotal_FactureHT.Width = 72;
            // 
            // colTotal_FactureTTC
            // 
            this.colTotal_FactureTTC.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTotal_FactureTTC.AppearanceHeader.Options.UseFont = true;
            this.colTotal_FactureTTC.Caption = "Total TTC";
            this.colTotal_FactureTTC.FieldName = "Total_FactureTTC";
            this.colTotal_FactureTTC.Name = "colTotal_FactureTTC";
            this.colTotal_FactureTTC.OptionsColumn.AllowEdit = false;
            this.colTotal_FactureTTC.Visible = true;
            this.colTotal_FactureTTC.VisibleIndex = 7;
            this.colTotal_FactureTTC.Width = 72;
            // 
            // colClient
            // 
            this.colClient.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colClient.AppearanceHeader.Options.UseFont = true;
            this.colClient.Caption = "Raison Sociale";
            this.colClient.FieldName = "Client.RaisonSociale";
            this.colClient.Name = "colClient";
            this.colClient.OptionsColumn.AllowEdit = false;
            this.colClient.Visible = true;
            this.colClient.VisibleIndex = 2;
            this.colClient.Width = 72;
            // 
            // colCertificateRS
            // 
            this.colCertificateRS.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCertificateRS.AppearanceHeader.Options.UseFont = true;
            this.colCertificateRS.Caption = "Certificate RS";
            this.colCertificateRS.ColumnEdit = this.repositoryItemButtoncolCertificateRS;
            this.colCertificateRS.Name = "colCertificateRS";
            this.colCertificateRS.Visible = true;
            this.colCertificateRS.VisibleIndex = 8;
            this.colCertificateRS.Width = 72;
            // 
            // repositoryItemButtoncolCertificateRS
            // 
            this.repositoryItemButtoncolCertificateRS.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repositoryItemButtoncolCertificateRS.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions1, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.repositoryItemButtoncolCertificateRS.Name = "repositoryItemButtoncolCertificateRS";
            this.repositoryItemButtoncolCertificateRS.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtoncolCertificateRS.Click += new System.EventHandler(this.repositoryItemButtoncolCertificateRS_Click);
            // 
            // GCViewDocuement
            // 
            this.GCViewDocuement.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GCViewDocuement.AppearanceHeader.Options.UseFont = true;
            this.GCViewDocuement.Caption = "View Docuement";
            this.GCViewDocuement.ColumnEdit = this.repositoryItemButtonEditViewDocument;
            this.GCViewDocuement.Name = "GCViewDocuement";
            this.GCViewDocuement.Visible = true;
            this.GCViewDocuement.VisibleIndex = 9;
            this.GCViewDocuement.Width = 72;
            // 
            // repositoryItemButtonEditViewDocument
            // 
            this.repositoryItemButtonEditViewDocument.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.repositoryItemButtonEditViewDocument.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions2, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.repositoryItemButtonEditViewDocument.Name = "repositoryItemButtonEditViewDocument";
            this.repositoryItemButtonEditViewDocument.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // GcLIgnefacture
            // 
            this.GcLIgnefacture.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GcLIgnefacture.AppearanceHeader.Options.UseFont = true;
            this.GcLIgnefacture.Caption = "Details Facture";
            this.GcLIgnefacture.ColumnEdit = this.repositoryLignefacture;
            this.GcLIgnefacture.Name = "GcLIgnefacture";
            this.GcLIgnefacture.Visible = true;
            this.GcLIgnefacture.VisibleIndex = 10;
            this.GcLIgnefacture.Width = 72;
            // 
            // repositoryLignefacture
            // 
            this.repositoryLignefacture.AutoHeight = false;
            editorButtonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions3.Image")));
            this.repositoryLignefacture.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions3, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.repositoryLignefacture.Name = "repositoryLignefacture";
            this.repositoryLignefacture.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryLignefacture.Click += new System.EventHandler(this.repositoryLignefacture_Click);
            // 
            // GvImprimer
            // 
            this.GvImprimer.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GvImprimer.AppearanceHeader.Options.UseFont = true;
            this.GvImprimer.Caption = "Imprimer";
            this.GvImprimer.ColumnEdit = this.repositoryItemButtonEditImprimer;
            this.GvImprimer.Name = "GvImprimer";
            this.GvImprimer.Visible = true;
            this.GvImprimer.VisibleIndex = 11;
            this.GvImprimer.Width = 88;
            // 
            // repositoryItemButtonEditImprimer
            // 
            this.repositoryItemButtonEditImprimer.AutoHeight = false;
            editorButtonImageOptions4.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions4.Image")));
            this.repositoryItemButtonEditImprimer.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions4, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.repositoryItemButtonEditImprimer.Name = "repositoryItemButtonEditImprimer";
            this.repositoryItemButtonEditImprimer.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEditImprimer.Click += new System.EventHandler(this.repositoryItemButtonEditImprimer_Click);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(949, 376);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(929, 306);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.DateDebut;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(463, 50);
            this.layoutControlItem3.Text = "Date Debut";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 15);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.DateFin;
            this.layoutControlItem4.Location = new System.Drawing.Point(463, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(466, 24);
            this.layoutControlItem4.Text = " Date Fin";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 15);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.BtnExportPdF;
            this.layoutControlItem5.Location = new System.Drawing.Point(696, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(233, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.BtnExportExcel;
            this.layoutControlItem6.Location = new System.Drawing.Point(463, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(233, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(977, 422);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(957, 402);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // FrmListeFactures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 422);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmListeFactures";
            this.Text = "Liste des Factures";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmListeFactures_FormClosing);
            this.Load += new System.EventHandler(this.FrmListeFactures_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DateFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDebut.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDebut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.factureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtoncolCertificateRS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditViewDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryLignefacture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditImprimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.DateEdit DateFin;
        private DevExpress.XtraEditors.DateEdit DateDebut;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colReference;
        private DevExpress.XtraGrid.Columns.GridColumn colDateFacture;
        private DevExpress.XtraGrid.Columns.GridColumn colTVA;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal_FactureHT;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal_FactureTTC;
        private DevExpress.XtraGrid.Columns.GridColumn colClient;
        private DevExpress.XtraGrid.Columns.GridColumn colCertificateRS;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtoncolCertificateRS;
        private DevExpress.XtraEditors.SimpleButton BtnExportExcel;
        private DevExpress.XtraEditors.SimpleButton BtnExportPdF;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.Columns.GridColumn GCViewDocuement;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditViewDocument;
        private DevExpress.XtraGrid.Columns.GridColumn GcLIgnefacture;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryLignefacture;
        private DevExpress.XtraGrid.Columns.GridColumn GvImprimer;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditImprimer;
        public System.Windows.Forms.BindingSource factureBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn GCNdevis;
    }
}