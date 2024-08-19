namespace Gestion_de_Stock.Forms
{
    partial class FrmListeDevis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListeDevis));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.BtnExportPdF = new DevExpress.XtraEditors.SimpleButton();
            this.BtnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnConvertToFacture = new DevExpress.XtraEditors.SimpleButton();
            this.DateFin = new DevExpress.XtraEditors.DateEdit();
            this.BtnConvertToVente = new DevExpress.XtraEditors.SimpleButton();
            this.DateDebut = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.devisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateCreation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal_DevisHT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal_DevisTTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColImprimer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ImprimerItem = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.ColDetais = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonDetaisDevis = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Supprimer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSupprimer = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.DateDebutItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.devisBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImprimerItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonDetaisDevis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSupprimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDebutItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
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
            this.layoutControl1.Size = new System.Drawing.Size(965, 487);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(941, 463);
            this.groupControl1.TabIndex = 4;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.BtnExportPdF);
            this.layoutControl2.Controls.Add(this.BtnExportExcel);
            this.layoutControl2.Controls.Add(this.BtnConvertToFacture);
            this.layoutControl2.Controls.Add(this.DateFin);
            this.layoutControl2.Controls.Add(this.BtnConvertToVente);
            this.layoutControl2.Controls.Add(this.DateDebut);
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 20);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(937, 441);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // BtnExportPdF
            // 
            this.BtnExportPdF.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportPdF.Appearance.Options.UseFont = true;
            this.BtnExportPdF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnExportPdF.ImageOptions.Image")));
            this.BtnExportPdF.Location = new System.Drawing.Point(703, 36);
            this.BtnExportPdF.Name = "BtnExportPdF";
            this.BtnExportPdF.Size = new System.Drawing.Size(222, 22);
            this.BtnExportPdF.StyleController = this.layoutControl2;
            this.BtnExportPdF.TabIndex = 12;
            this.BtnExportPdF.Text = "Export PdF";
            this.BtnExportPdF.Click += new System.EventHandler(this.BtnExportPdF_Click);
            // 
            // BtnExportExcel
            // 
            this.BtnExportExcel.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportExcel.Appearance.Options.UseFont = true;
            this.BtnExportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnExportExcel.ImageOptions.Image")));
            this.BtnExportExcel.Location = new System.Drawing.Point(477, 36);
            this.BtnExportExcel.Name = "BtnExportExcel";
            this.BtnExportExcel.Size = new System.Drawing.Size(222, 22);
            this.BtnExportExcel.StyleController = this.layoutControl2;
            this.BtnExportExcel.TabIndex = 11;
            this.BtnExportExcel.Text = "Export Excel";
            this.BtnExportExcel.Click += new System.EventHandler(this.BtnExportExcel_Click);
            // 
            // BtnConvertToFacture
            // 
            this.BtnConvertToFacture.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConvertToFacture.Appearance.Options.UseFont = true;
            this.BtnConvertToFacture.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnConvertToFacture.ImageOptions.Image")));
            this.BtnConvertToFacture.Location = new System.Drawing.Point(703, 62);
            this.BtnConvertToFacture.Name = "BtnConvertToFacture";
            this.BtnConvertToFacture.Size = new System.Drawing.Size(222, 22);
            this.BtnConvertToFacture.StyleController = this.layoutControl2;
            this.BtnConvertToFacture.TabIndex = 10;
            this.BtnConvertToFacture.Text = "Convertir en Facture";
            this.BtnConvertToFacture.Click += new System.EventHandler(this.BtnConvertToFacture_Click);
            // 
            // DateFin
            // 
            this.DateFin.EditValue = null;
            this.DateFin.Location = new System.Drawing.Point(540, 12);
            this.DateFin.Name = "DateFin";
            this.DateFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateFin.Size = new System.Drawing.Size(385, 20);
            this.DateFin.StyleController = this.layoutControl2;
            this.DateFin.TabIndex = 7;
            this.DateFin.EditValueChanged += new System.EventHandler(this.DateFin_EditValueChanged);
            // 
            // BtnConvertToVente
            // 
            this.BtnConvertToVente.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConvertToVente.Appearance.Options.UseFont = true;
            this.BtnConvertToVente.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnConvertToVente.ImageOptions.Image")));
            this.BtnConvertToVente.Location = new System.Drawing.Point(477, 62);
            this.BtnConvertToVente.Name = "BtnConvertToVente";
            this.BtnConvertToVente.Size = new System.Drawing.Size(222, 22);
            this.BtnConvertToVente.StyleController = this.layoutControl2;
            this.BtnConvertToVente.TabIndex = 9;
            this.BtnConvertToVente.Text = "Convertir en Vente";
            this.BtnConvertToVente.Click += new System.EventHandler(this.BtnConvertToVente_Click);
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
            this.DateDebut.Size = new System.Drawing.Size(398, 20);
            this.DateDebut.StyleController = this.layoutControl2;
            this.DateDebut.TabIndex = 5;
            this.DateDebut.EditValueChanged += new System.EventHandler(this.DateDebut_EditValueChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.devisBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 88);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ImprimerItem,
            this.repositoryItemButtonDetaisDevis,
            this.repositoryItemSupprimer});
            this.gridControl1.Size = new System.Drawing.Size(913, 341);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // devisBindingSource
            // 
            this.devisBindingSource.DataSource = typeof(Gestion_de_Stock.Model.Devis);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colDateCreation,
            this.colTVA,
            this.colTotal_DevisHT,
            this.colTotal_DevisTTC,
            this.colClient,
            this.ColImprimer,
            this.ColDetais,
            this.gridColumn1,
            this.Supprimer});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            // 
            // colCode
            // 
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            // 
            // colDateCreation
            // 
            this.colDateCreation.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDateCreation.AppearanceHeader.Options.UseFont = true;
            this.colDateCreation.Caption = "Date Devis";
            this.colDateCreation.FieldName = "DateDevis";
            this.colDateCreation.Name = "colDateCreation";
            this.colDateCreation.OptionsColumn.AllowEdit = false;
            this.colDateCreation.Visible = true;
            this.colDateCreation.VisibleIndex = 3;
            // 
            // colTVA
            // 
            this.colTVA.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTVA.AppearanceHeader.Options.UseFont = true;
            this.colTVA.FieldName = "TVA";
            this.colTVA.Name = "colTVA";
            this.colTVA.OptionsColumn.AllowEdit = false;
            this.colTVA.Visible = true;
            this.colTVA.VisibleIndex = 6;
            // 
            // colTotal_DevisHT
            // 
            this.colTotal_DevisHT.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTotal_DevisHT.AppearanceHeader.Options.UseFont = true;
            this.colTotal_DevisHT.Caption = "Total HT";
            this.colTotal_DevisHT.FieldName = "Total_DevisHT";
            this.colTotal_DevisHT.GroupFormat.FormatString = "N3";
            this.colTotal_DevisHT.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal_DevisHT.Name = "colTotal_DevisHT";
            this.colTotal_DevisHT.OptionsColumn.AllowEdit = false;
            this.colTotal_DevisHT.Visible = true;
            this.colTotal_DevisHT.VisibleIndex = 5;
            // 
            // colTotal_DevisTTC
            // 
            this.colTotal_DevisTTC.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTotal_DevisTTC.AppearanceHeader.Options.UseFont = true;
            this.colTotal_DevisTTC.Caption = "Total TTC";
            this.colTotal_DevisTTC.FieldName = "Total_DevisTTC";
            this.colTotal_DevisTTC.GroupFormat.FormatString = "N3";
            this.colTotal_DevisTTC.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal_DevisTTC.Name = "colTotal_DevisTTC";
            this.colTotal_DevisTTC.OptionsColumn.AllowEdit = false;
            this.colTotal_DevisTTC.Visible = true;
            this.colTotal_DevisTTC.VisibleIndex = 7;
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
            // 
            // ColImprimer
            // 
            this.ColImprimer.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColImprimer.AppearanceHeader.Options.UseFont = true;
            this.ColImprimer.Caption = "Imprimer";
            this.ColImprimer.ColumnEdit = this.ImprimerItem;
            this.ColImprimer.Image = ((System.Drawing.Image)(resources.GetObject("ColImprimer.Image")));
            this.ColImprimer.Name = "ColImprimer";
            this.ColImprimer.Visible = true;
            this.ColImprimer.VisibleIndex = 9;
            // 
            // ImprimerItem
            // 
            this.ImprimerItem.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.ImprimerItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions1, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.ImprimerItem.Name = "ImprimerItem";
            this.ImprimerItem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.ImprimerItem.Click += new System.EventHandler(this.ImprimerItem_Click);
            // 
            // ColDetais
            // 
            this.ColDetais.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColDetais.AppearanceHeader.Options.UseFont = true;
            this.ColDetais.Caption = "Détails Devis";
            this.ColDetais.ColumnEdit = this.repositoryItemButtonDetaisDevis;
            this.ColDetais.Name = "ColDetais";
            this.ColDetais.Visible = true;
            this.ColDetais.VisibleIndex = 8;
            // 
            // repositoryItemButtonDetaisDevis
            // 
            this.repositoryItemButtonDetaisDevis.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.repositoryItemButtonDetaisDevis.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions2, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.repositoryItemButtonDetaisDevis.Name = "repositoryItemButtonDetaisDevis";
            this.repositoryItemButtonDetaisDevis.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonDetaisDevis.Click += new System.EventHandler(this.repositoryItemButtonDetaisDevis_Click);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "Date livraison";
            this.gridColumn1.FieldName = "Datelivraison";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            // 
            // Supprimer
            // 
            this.Supprimer.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Supprimer.AppearanceHeader.Options.UseFont = true;
            this.Supprimer.Caption = "Supprimer";
            this.Supprimer.ColumnEdit = this.repositoryItemSupprimer;
            this.Supprimer.Name = "Supprimer";
            this.Supprimer.Visible = true;
            this.Supprimer.VisibleIndex = 10;
            // 
            // repositoryItemSupprimer
            // 
            this.repositoryItemSupprimer.AutoHeight = false;
            editorButtonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions3.Image")));
            this.repositoryItemSupprimer.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions3, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.repositoryItemSupprimer.Name = "repositoryItemSupprimer";
            this.repositoryItemSupprimer.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemSupprimer.Click += new System.EventHandler(this.repositoryItemSupprimer_Click);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.DateDebutItem,
            this.layoutControlItem5,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(937, 441);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 76);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(917, 345);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // DateDebutItem
            // 
            this.DateDebutItem.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateDebutItem.AppearanceItemCaption.Options.UseFont = true;
            this.DateDebutItem.Control = this.DateDebut;
            this.DateDebutItem.Location = new System.Drawing.Point(0, 0);
            this.DateDebutItem.Name = "DateDebutItem";
            this.DateDebutItem.Size = new System.Drawing.Size(465, 24);
            this.DateDebutItem.Text = "Date Debut";
            this.DateDebutItem.TextSize = new System.Drawing.Size(60, 15);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.DateFin;
            this.layoutControlItem5.Location = new System.Drawing.Point(465, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(452, 24);
            this.layoutControlItem5.Text = " Date Fin";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(60, 15);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(465, 52);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.BtnConvertToVente;
            this.layoutControlItem3.Location = new System.Drawing.Point(465, 50);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(226, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.BtnConvertToFacture;
            this.layoutControlItem4.Location = new System.Drawing.Point(691, 50);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(226, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.BtnExportExcel;
            this.layoutControlItem6.Location = new System.Drawing.Point(465, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(226, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.BtnExportPdF;
            this.layoutControlItem7.Location = new System.Drawing.Point(691, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(226, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(965, 487);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(945, 467);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // FrmListeDevis
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 487);
            this.Controls.Add(this.layoutControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmListeDevis";
            this.Text = "Liste des Devis";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmListeDevis_FormClosed);
            this.Load += new System.EventHandler(this.FrmListeDevis_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.devisBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImprimerItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonDetaisDevis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSupprimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDebutItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
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
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDateCreation;
        private DevExpress.XtraGrid.Columns.GridColumn colTVA;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal_DevisHT;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal_DevisTTC;
        private DevExpress.XtraGrid.Columns.GridColumn colClient;
        private DevExpress.XtraEditors.DateEdit DateFin;
        private DevExpress.XtraEditors.DateEdit DateDebut;
        private DevExpress.XtraLayout.LayoutControlItem DateDebutItem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn ColImprimer;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ImprimerItem;
        private DevExpress.XtraGrid.Columns.GridColumn ColDetais;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonDetaisDevis;
        public System.Windows.Forms.BindingSource devisBindingSource;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton BtnConvertToVente;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton BtnConvertToFacture;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn Supprimer;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemSupprimer;
        private DevExpress.XtraEditors.SimpleButton BtnExportPdF;
        private DevExpress.XtraEditors.SimpleButton BtnExportExcel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}