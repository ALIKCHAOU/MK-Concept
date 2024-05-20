namespace Gestion_de_Stock.Forms
{
    partial class FrmFournisseur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFournisseur));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.BtnAjouter = new DevExpress.XtraEditors.SimpleButton();
            this.BtnExportXLS = new DevExpress.XtraEditors.SimpleButton();
            this.BtnExportPDF = new DevExpress.XtraEditors.SimpleButton();
            this.BtnModifier = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSupprimer = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.fournisseurBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RaisonSociale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Prenom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdresse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVille = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelephone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colemail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GcMF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GCActivitee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEditViewBattante = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemButtonEditViewRegistredecommerce = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemButtonEditviewAttestationexoneration = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fournisseurBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditViewBattante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditViewRegistredecommerce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditviewAttestationexoneration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.BtnAjouter);
            this.layoutControl1.Controls.Add(this.BtnExportXLS);
            this.layoutControl1.Controls.Add(this.BtnExportPDF);
            this.layoutControl1.Controls.Add(this.BtnModifier);
            this.layoutControl1.Controls.Add(this.BtnSupprimer);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(576, 112, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(931, 525);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // BtnAjouter
            // 
            this.BtnAjouter.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAjouter.Appearance.Options.UseFont = true;
            this.BtnAjouter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnAjouter.ImageOptions.Image")));
            this.BtnAjouter.Location = new System.Drawing.Point(594, 491);
            this.BtnAjouter.Name = "BtnAjouter";
            this.BtnAjouter.Size = new System.Drawing.Size(91, 22);
            this.BtnAjouter.StyleController = this.layoutControl1;
            this.BtnAjouter.TabIndex = 13;
            this.BtnAjouter.Text = "Ajouter";
            this.BtnAjouter.Click += new System.EventHandler(this.BtnAjouter_Click);
            // 
            // BtnExportXLS
            // 
            this.BtnExportXLS.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportXLS.Appearance.Options.UseFont = true;
            this.BtnExportXLS.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnExportXLS.ImageOptions.Image")));
            this.BtnExportXLS.Location = new System.Drawing.Point(627, 12);
            this.BtnExportXLS.Name = "BtnExportXLS";
            this.BtnExportXLS.Size = new System.Drawing.Size(148, 22);
            this.BtnExportXLS.StyleController = this.layoutControl1;
            this.BtnExportXLS.TabIndex = 0;
            this.BtnExportXLS.Text = "Export XLS";
            this.BtnExportXLS.Click += new System.EventHandler(this.BtnExportXLS_Click);
            // 
            // BtnExportPDF
            // 
            this.BtnExportPDF.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportPDF.Appearance.Options.UseFont = true;
            this.BtnExportPDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnExportPDF.ImageOptions.Image")));
            this.BtnExportPDF.Location = new System.Drawing.Point(779, 12);
            this.BtnExportPDF.Name = "BtnExportPDF";
            this.BtnExportPDF.Size = new System.Drawing.Size(140, 22);
            this.BtnExportPDF.StyleController = this.layoutControl1;
            this.BtnExportPDF.TabIndex = 2;
            this.BtnExportPDF.Text = "Export PDF";
            this.BtnExportPDF.Click += new System.EventHandler(this.BtnExportPDF_Click);
            // 
            // BtnModifier
            // 
            this.BtnModifier.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModifier.Appearance.Options.UseFont = true;
            this.BtnModifier.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnModifier.ImageOptions.Image")));
            this.BtnModifier.Location = new System.Drawing.Point(689, 491);
            this.BtnModifier.Name = "BtnModifier";
            this.BtnModifier.Size = new System.Drawing.Size(114, 22);
            this.BtnModifier.StyleController = this.layoutControl1;
            this.BtnModifier.TabIndex = 11;
            this.BtnModifier.Text = "Modifier";
            this.BtnModifier.Click += new System.EventHandler(this.BtnEnregister_Click);
            // 
            // BtnSupprimer
            // 
            this.BtnSupprimer.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSupprimer.Appearance.Options.UseFont = true;
            this.BtnSupprimer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnSupprimer.ImageOptions.Image")));
            this.BtnSupprimer.Location = new System.Drawing.Point(807, 491);
            this.BtnSupprimer.Name = "BtnSupprimer";
            this.BtnSupprimer.Size = new System.Drawing.Size(112, 22);
            this.BtnSupprimer.StyleController = this.layoutControl1;
            this.BtnSupprimer.TabIndex = 12;
            this.BtnSupprimer.Text = "Supprimer";
            this.BtnSupprimer.Click += new System.EventHandler(this.BtnSupprimerTout_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.fournisseurBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 38);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEditViewBattante,
            this.repositoryItemButtonEditViewRegistredecommerce,
            this.repositoryItemButtonEditviewAttestationexoneration});
            this.gridControl1.Size = new System.Drawing.Size(907, 449);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // fournisseurBindingSource
            // 
            this.fournisseurBindingSource.DataSource = typeof(Gestion_de_Stock.Model.Fournisseur);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.RaisonSociale,
            this.colNom,
            this.Prenom,
            this.colAdresse,
            this.colVille,
            this.colTelephone,
            this.colemail,
            this.GcMF,
            this.GCActivitee});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // colCode
            // 
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            // 
            // RaisonSociale
            // 
            this.RaisonSociale.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RaisonSociale.AppearanceHeader.Options.UseFont = true;
            this.RaisonSociale.Caption = "Raison Sociale";
            this.RaisonSociale.FieldName = "RaisonSociale";
            this.RaisonSociale.Name = "RaisonSociale";
            this.RaisonSociale.OptionsColumn.AllowEdit = false;
            this.RaisonSociale.Visible = true;
            this.RaisonSociale.VisibleIndex = 1;
            // 
            // colNom
            // 
            this.colNom.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNom.AppearanceHeader.Options.UseFont = true;
            this.colNom.Caption = "Nom";
            this.colNom.FieldName = "NomResponsable";
            this.colNom.Name = "colNom";
            this.colNom.OptionsColumn.AllowEdit = false;
            this.colNom.Visible = true;
            this.colNom.VisibleIndex = 3;
            // 
            // Prenom
            // 
            this.Prenom.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Prenom.AppearanceHeader.Options.UseFont = true;
            this.Prenom.Caption = "Prénom";
            this.Prenom.FieldName = "PrenomResponsable";
            this.Prenom.Name = "Prenom";
            this.Prenom.OptionsColumn.AllowEdit = false;
            this.Prenom.Visible = true;
            this.Prenom.VisibleIndex = 2;
            // 
            // colAdresse
            // 
            this.colAdresse.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAdresse.AppearanceHeader.Options.UseFont = true;
            this.colAdresse.Caption = "Adresse";
            this.colAdresse.FieldName = "Adresse";
            this.colAdresse.Name = "colAdresse";
            this.colAdresse.OptionsColumn.AllowEdit = false;
            this.colAdresse.Visible = true;
            this.colAdresse.VisibleIndex = 6;
            // 
            // colVille
            // 
            this.colVille.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colVille.AppearanceHeader.Options.UseFont = true;
            this.colVille.Caption = "Ville";
            this.colVille.FieldName = "Ville";
            this.colVille.Name = "colVille";
            this.colVille.OptionsColumn.AllowEdit = false;
            this.colVille.Visible = true;
            this.colVille.VisibleIndex = 7;
            // 
            // colTelephone
            // 
            this.colTelephone.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTelephone.AppearanceHeader.Options.UseFont = true;
            this.colTelephone.Caption = "Téléphone";
            this.colTelephone.FieldName = "TelResponsable";
            this.colTelephone.Name = "colTelephone";
            this.colTelephone.OptionsColumn.AllowEdit = false;
            this.colTelephone.Visible = true;
            this.colTelephone.VisibleIndex = 8;
            // 
            // colemail
            // 
            this.colemail.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colemail.AppearanceHeader.Options.UseFont = true;
            this.colemail.Caption = "Email";
            this.colemail.FieldName = "EmailResponsable";
            this.colemail.Name = "colemail";
            this.colemail.OptionsColumn.AllowEdit = false;
            this.colemail.Visible = true;
            this.colemail.VisibleIndex = 9;
            // 
            // GcMF
            // 
            this.GcMF.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GcMF.AppearanceHeader.Options.UseFont = true;
            this.GcMF.Caption = "M.F";
            this.GcMF.FieldName = "MatriculeFiscale";
            this.GcMF.Name = "GcMF";
            this.GcMF.OptionsColumn.AllowEdit = false;
            this.GcMF.Visible = true;
            this.GcMF.VisibleIndex = 4;
            // 
            // GCActivitee
            // 
            this.GCActivitee.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GCActivitee.AppearanceHeader.Options.UseFont = true;
            this.GCActivitee.Caption = "Activité";
            this.GCActivitee.FieldName = "Activite";
            this.GCActivitee.Name = "GCActivitee";
            this.GCActivitee.OptionsColumn.AllowEdit = false;
            this.GCActivitee.Visible = true;
            this.GCActivitee.VisibleIndex = 5;
            // 
            // repositoryItemButtonEditViewBattante
            // 
            this.repositoryItemButtonEditViewBattante.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repositoryItemButtonEditViewBattante.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions1, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.repositoryItemButtonEditViewBattante.Name = "repositoryItemButtonEditViewBattante";
            this.repositoryItemButtonEditViewBattante.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEditViewBattante.Click += new System.EventHandler(this.repositoryItemButtonEditViewBattante_Click);
            // 
            // repositoryItemButtonEditViewRegistredecommerce
            // 
            this.repositoryItemButtonEditViewRegistredecommerce.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.repositoryItemButtonEditViewRegistredecommerce.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions2, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.repositoryItemButtonEditViewRegistredecommerce.Name = "repositoryItemButtonEditViewRegistredecommerce";
            this.repositoryItemButtonEditViewRegistredecommerce.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEditViewRegistredecommerce.Click += new System.EventHandler(this.repositoryItemButtonEditViewRegistredecommerce_Click);
            // 
            // repositoryItemButtonEditviewAttestationexoneration
            // 
            this.repositoryItemButtonEditviewAttestationexoneration.AutoHeight = false;
            editorButtonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions3.Image")));
            this.repositoryItemButtonEditviewAttestationexoneration.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions3, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.repositoryItemButtonEditviewAttestationexoneration.Name = "repositoryItemButtonEditviewAttestationexoneration";
            this.repositoryItemButtonEditviewAttestationexoneration.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEditviewAttestationexoneration.Click += new System.EventHandler(this.repositoryItemButtonEditviewAttestationexoneration_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem11,
            this.layoutControlItem13,
            this.layoutControlItem15,
            this.emptySpaceItem1,
            this.layoutControlItem12,
            this.emptySpaceItem2,
            this.layoutControlItem8});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(931, 525);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(911, 453);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.BtnSupprimer;
            this.layoutControlItem11.Location = new System.Drawing.Point(795, 479);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(116, 26);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.BtnExportPDF;
            this.layoutControlItem13.Location = new System.Drawing.Point(767, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(144, 26);
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.BtnExportXLS;
            this.layoutControlItem15.Location = new System.Drawing.Point(615, 0);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(152, 26);
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(615, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.BtnModifier;
            this.layoutControlItem12.Location = new System.Drawing.Point(677, 479);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(118, 26);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 479);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(582, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.BtnAjouter;
            this.layoutControlItem8.Location = new System.Drawing.Point(582, 479);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(95, 26);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // FrmFournisseur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 525);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmFournisseur";
            this.Text = "Liste des Fournisseurs";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmFournisseur_FormClosed);
            this.Load += new System.EventHandler(this.FrmFournisseur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fournisseurBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditViewBattante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditViewRegistredecommerce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditviewAttestationexoneration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colNom;
        private DevExpress.XtraGrid.Columns.GridColumn colAdresse;
        private DevExpress.XtraGrid.Columns.GridColumn colVille;
        private DevExpress.XtraGrid.Columns.GridColumn colTelephone;
        private DevExpress.XtraGrid.Columns.GridColumn colemail;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton BtnModifier;
        private DevExpress.XtraEditors.SimpleButton BtnSupprimer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        public System.Windows.Forms.BindingSource fournisseurBindingSource;
        private DevExpress.XtraEditors.SimpleButton BtnExportXLS;
        private DevExpress.XtraEditors.SimpleButton BtnExportPDF;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.SimpleButton BtnAjouter;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraGrid.Columns.GridColumn Prenom;
        private DevExpress.XtraGrid.Columns.GridColumn RaisonSociale;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditViewBattante;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditViewRegistredecommerce;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditviewAttestationexoneration;
        private DevExpress.XtraGrid.Columns.GridColumn GcMF;
        private DevExpress.XtraGrid.Columns.GridColumn GCActivitee;
    }
}