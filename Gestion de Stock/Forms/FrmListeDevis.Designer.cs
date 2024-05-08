﻿namespace Gestion_de_Stock.Forms
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions6 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListeDevis));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions7 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions8 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions10 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions9 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.DateFin = new DevExpress.XtraEditors.DateEdit();
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
            this.ColViewDocument = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ViewDocument = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.ColImprimer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ImprimerItem = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.ColDetais = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonDetaisDevis = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositorySendEmail = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryModifierDevis = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.DateDebutItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.ViewDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImprimerItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonDetaisDevis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorySendEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryModifierDevis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDebutItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
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
            this.layoutControl2.Controls.Add(this.DateFin);
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
            this.gridControl1.Location = new System.Drawing.Point(12, 62);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ViewDocument,
            this.ImprimerItem,
            this.repositoryItemButtonDetaisDevis,
            this.repositoryModifierDevis,
            this.repositorySendEmail});
            this.gridControl1.Size = new System.Drawing.Size(913, 367);
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
            this.ColViewDocument,
            this.ColImprimer,
            this.ColDetais});
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
            this.colDateCreation.Caption = "Date";
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
            this.colTVA.VisibleIndex = 5;
            // 
            // colTotal_DevisHT
            // 
            this.colTotal_DevisHT.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTotal_DevisHT.AppearanceHeader.Options.UseFont = true;
            this.colTotal_DevisHT.Caption = "Total HT";
            this.colTotal_DevisHT.FieldName = "Total_DevisHT";
            this.colTotal_DevisHT.GroupFormat.FormatString = "f3";
            this.colTotal_DevisHT.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal_DevisHT.Name = "colTotal_DevisHT";
            this.colTotal_DevisHT.OptionsColumn.AllowEdit = false;
            this.colTotal_DevisHT.Visible = true;
            this.colTotal_DevisHT.VisibleIndex = 4;
            // 
            // colTotal_DevisTTC
            // 
            this.colTotal_DevisTTC.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTotal_DevisTTC.AppearanceHeader.Options.UseFont = true;
            this.colTotal_DevisTTC.Caption = "Total TTC";
            this.colTotal_DevisTTC.FieldName = "Total_DevisTTC";
            this.colTotal_DevisTTC.GroupFormat.FormatString = "f3";
            this.colTotal_DevisTTC.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal_DevisTTC.Name = "colTotal_DevisTTC";
            this.colTotal_DevisTTC.OptionsColumn.AllowEdit = false;
            this.colTotal_DevisTTC.Visible = true;
            this.colTotal_DevisTTC.VisibleIndex = 6;
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
            // ColViewDocument
            // 
            this.ColViewDocument.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColViewDocument.AppearanceHeader.Options.UseFont = true;
            this.ColViewDocument.Caption = "Document";
            this.ColViewDocument.ColumnEdit = this.ViewDocument;
            this.ColViewDocument.Name = "ColViewDocument";
            this.ColViewDocument.Visible = true;
            this.ColViewDocument.VisibleIndex = 7;
            // 
            // ViewDocument
            // 
            this.ViewDocument.AutoHeight = false;
            editorButtonImageOptions6.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions6.Image")));
            this.ViewDocument.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions6, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.ViewDocument.Name = "ViewDocument";
            this.ViewDocument.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.ViewDocument.Click += new System.EventHandler(this.ViewDocument_Click);
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
            this.ColImprimer.VisibleIndex = 8;
            // 
            // ImprimerItem
            // 
            this.ImprimerItem.AutoHeight = false;
            editorButtonImageOptions7.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions7.Image")));
            this.ImprimerItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions7, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
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
            this.ColDetais.VisibleIndex = 9;
            // 
            // repositoryItemButtonDetaisDevis
            // 
            this.repositoryItemButtonDetaisDevis.AutoHeight = false;
            editorButtonImageOptions8.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions8.Image")));
            this.repositoryItemButtonDetaisDevis.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions8, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.repositoryItemButtonDetaisDevis.Name = "repositoryItemButtonDetaisDevis";
            this.repositoryItemButtonDetaisDevis.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonDetaisDevis.Click += new System.EventHandler(this.repositoryItemButtonDetaisDevis_Click);
            // 
            // repositorySendEmail
            // 
            this.repositorySendEmail.AutoHeight = false;
            editorButtonImageOptions10.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions10.Image")));
            this.repositorySendEmail.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions10, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.repositorySendEmail.Name = "repositorySendEmail";
            this.repositorySendEmail.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositorySendEmail.Click += new System.EventHandler(this.repositorySendEmail_Click);
            // 
            // repositoryModifierDevis
            // 
            this.repositoryModifierDevis.AutoHeight = false;
            editorButtonImageOptions9.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions9.Image")));
            this.repositoryModifierDevis.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions9, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.repositoryModifierDevis.Name = "repositoryModifierDevis";
            this.repositoryModifierDevis.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
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
            this.emptySpaceItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(937, 441);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(917, 371);
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
            this.emptySpaceItem1.Size = new System.Drawing.Size(465, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(465, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(452, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.ViewDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImprimerItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonDetaisDevis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorySendEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryModifierDevis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDebutItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn ColViewDocument;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ViewDocument;
        private DevExpress.XtraEditors.DateEdit DateFin;
        private DevExpress.XtraEditors.DateEdit DateDebut;
        private DevExpress.XtraLayout.LayoutControlItem DateDebutItem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn ColImprimer;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ImprimerItem;
        private DevExpress.XtraGrid.Columns.GridColumn ColDetais;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonDetaisDevis;
        public System.Windows.Forms.BindingSource devisBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryModifierDevis;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositorySendEmail;
    }
}