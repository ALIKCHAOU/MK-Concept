﻿namespace Gestion_de_Stock.Forms
{
    partial class FrmSalarier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSalarier));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.BtnAjouter = new DevExpress.XtraEditors.SimpleButton();
            this.BtnModifier = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSupprimer = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.salarierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumSalarie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntitule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MontantReglé = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RestARegle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TotalSolde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GcMatricule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MontantJournalier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salarierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
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
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(866, 483);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(842, 459);
            this.groupControl1.TabIndex = 4;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.BtnAjouter);
            this.layoutControl2.Controls.Add(this.BtnModifier);
            this.layoutControl2.Controls.Add(this.BtnSupprimer);
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 20);
            this.layoutControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(838, 437);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // BtnAjouter
            // 
            this.BtnAjouter.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAjouter.Appearance.Options.UseFont = true;
            this.BtnAjouter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnAjouter.ImageOptions.Image")));
            this.BtnAjouter.Location = new System.Drawing.Point(230, 379);
            this.BtnAjouter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnAjouter.Name = "BtnAjouter";
            this.BtnAjouter.Size = new System.Drawing.Size(196, 46);
            this.BtnAjouter.StyleController = this.layoutControl2;
            this.BtnAjouter.TabIndex = 7;
            this.BtnAjouter.Text = "Ajouter";
            this.BtnAjouter.Click += new System.EventHandler(this.BtnAjouter_Click);
            // 
            // BtnModifier
            // 
            this.BtnModifier.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModifier.Appearance.Options.UseFont = true;
            this.BtnModifier.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnModifier.ImageOptions.Image")));
            this.BtnModifier.Location = new System.Drawing.Point(430, 379);
            this.BtnModifier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnModifier.Name = "BtnModifier";
            this.BtnModifier.Size = new System.Drawing.Size(196, 46);
            this.BtnModifier.StyleController = this.layoutControl2;
            this.BtnModifier.TabIndex = 6;
            this.BtnModifier.Text = "Modifier";
            this.BtnModifier.Click += new System.EventHandler(this.BtnModifier_Click);
            // 
            // BtnSupprimer
            // 
            this.BtnSupprimer.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSupprimer.Appearance.Options.UseFont = true;
            this.BtnSupprimer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnSupprimer.ImageOptions.Image")));
            this.BtnSupprimer.Location = new System.Drawing.Point(630, 379);
            this.BtnSupprimer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSupprimer.Name = "BtnSupprimer";
            this.BtnSupprimer.Size = new System.Drawing.Size(196, 46);
            this.BtnSupprimer.StyleController = this.layoutControl2;
            this.BtnSupprimer.TabIndex = 5;
            this.BtnSupprimer.Text = "Supprimer";
            this.BtnSupprimer.Click += new System.EventHandler(this.BtnSupprimer_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.salarierBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(814, 363);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // salarierBindingSource
            // 
            this.salarierBindingSource.DataSource = typeof(Gestion_de_Stock.Model.Salarier);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTel,
            this.colNumSalarie,
            this.colIntitule,
            this.MontantReglé,
            this.RestARegle,
            this.TotalSolde,
            this.GcMatricule,
            this.MontantJournalier});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "Entrer un texte pour rechercher...";
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            // 
            // colTel
            // 
            this.colTel.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTel.AppearanceHeader.Options.UseFont = true;
            this.colTel.Caption = "Téléphone";
            this.colTel.FieldName = "Tel";
            this.colTel.Name = "colTel";
            this.colTel.OptionsColumn.AllowEdit = false;
            this.colTel.Visible = true;
            this.colTel.VisibleIndex = 3;
            // 
            // colNumSalarie
            // 
            this.colNumSalarie.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNumSalarie.AppearanceHeader.Options.UseFont = true;
            this.colNumSalarie.Caption = "Numéro";
            this.colNumSalarie.FieldName = "numero";
            this.colNumSalarie.Name = "colNumSalarie";
            this.colNumSalarie.OptionsColumn.AllowEdit = false;
            this.colNumSalarie.OptionsFilter.AllowAutoFilter = false;
            this.colNumSalarie.Visible = true;
            this.colNumSalarie.VisibleIndex = 0;
            // 
            // colIntitule
            // 
            this.colIntitule.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colIntitule.AppearanceHeader.Options.UseFont = true;
            this.colIntitule.Caption = "Intitulé";
            this.colIntitule.FieldName = "Intitule";
            this.colIntitule.Name = "colIntitule";
            this.colIntitule.OptionsColumn.AllowEdit = false;
            this.colIntitule.Visible = true;
            this.colIntitule.VisibleIndex = 1;
            // 
            // MontantReglé
            // 
            this.MontantReglé.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MontantReglé.AppearanceHeader.Options.UseFont = true;
            this.MontantReglé.Caption = "Montant Reglès";
            this.MontantReglé.DisplayFormat.FormatString = "n3";
            this.MontantReglé.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.MontantReglé.FieldName = "MontantReglé";
            this.MontantReglé.Name = "MontantReglé";
            this.MontantReglé.OptionsColumn.AllowEdit = false;
            this.MontantReglé.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontantReglé", "={0:n3}")});
            this.MontantReglé.Visible = true;
            this.MontantReglé.VisibleIndex = 6;
            // 
            // RestARegle
            // 
            this.RestARegle.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestARegle.AppearanceHeader.Options.UseFont = true;
            this.RestARegle.Caption = "Rest a Reglès";
            this.RestARegle.DisplayFormat.FormatString = "n3";
            this.RestARegle.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.RestARegle.FieldName = "MontantRestReglé";
            this.RestARegle.Name = "RestARegle";
            this.RestARegle.OptionsColumn.AllowEdit = false;
            this.RestARegle.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontantRestReglé", "={0:n3}")});
            this.RestARegle.Visible = true;
            this.RestARegle.VisibleIndex = 7;
            // 
            // TotalSolde
            // 
            this.TotalSolde.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalSolde.AppearanceHeader.Options.UseFont = true;
            this.TotalSolde.Caption = "Total Solde";
            this.TotalSolde.DisplayFormat.FormatString = "n3";
            this.TotalSolde.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TotalSolde.FieldName = "Solde";
            this.TotalSolde.Name = "TotalSolde";
            this.TotalSolde.OptionsColumn.AllowEdit = false;
            this.TotalSolde.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Solde", "={0:n3}")});
            this.TotalSolde.Visible = true;
            this.TotalSolde.VisibleIndex = 5;
            // 
            // GcMatricule
            // 
            this.GcMatricule.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GcMatricule.AppearanceHeader.Options.UseFont = true;
            this.GcMatricule.Caption = "Matricule";
            this.GcMatricule.FieldName = "Matricule";
            this.GcMatricule.Name = "GcMatricule";
            this.GcMatricule.OptionsColumn.AllowEdit = false;
            this.GcMatricule.Visible = true;
            this.GcMatricule.VisibleIndex = 2;
            // 
            // MontantJournalier
            // 
            this.MontantJournalier.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MontantJournalier.AppearanceHeader.Options.UseFont = true;
            this.MontantJournalier.Caption = "Montant Journalier";
            this.MontantJournalier.DisplayFormat.FormatString = "n3";
            this.MontantJournalier.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.MontantJournalier.FieldName = "MontantJournalie";
            this.MontantJournalier.Name = "MontantJournalier";
            this.MontantJournalier.OptionsColumn.AllowEdit = false;
            this.MontantJournalier.Visible = true;
            this.MontantJournalier.VisibleIndex = 4;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup2.Size = new System.Drawing.Size(838, 437);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(300, 200);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(818, 367);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 367);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(218, 50);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.BtnSupprimer;
            this.layoutControlItem3.Location = new System.Drawing.Point(618, 367);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(200, 50);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(200, 50);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(200, 50);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.BtnModifier;
            this.layoutControlItem4.Location = new System.Drawing.Point(418, 367);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(200, 200);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(200, 50);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(200, 50);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.BtnAjouter;
            this.layoutControlItem5.Location = new System.Drawing.Point(218, 367);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(200, 50);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(200, 50);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(200, 50);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(866, 483);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(846, 463);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(16, 363);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(717, 27);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "simpleButton1";
            // 
            // FrmSalarier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 483);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmSalarier";
            this.Text = "Liste des Salariés";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmOuvrier_FormClosed);
            this.Load += new System.EventHandler(this.FrmOuvrier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salarierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton BtnAjouter;
        private DevExpress.XtraEditors.SimpleButton BtnModifier;
        private DevExpress.XtraEditors.SimpleButton BtnSupprimer;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Columns.GridColumn colIntitule;
        private DevExpress.XtraGrid.Columns.GridColumn colTel;
        public DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        public System.Windows.Forms.BindingSource salarierBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNumSalarie;
        private DevExpress.XtraGrid.Columns.GridColumn MontantReglé;
        private DevExpress.XtraGrid.Columns.GridColumn RestARegle;
        private DevExpress.XtraGrid.Columns.GridColumn TotalSolde;
        private DevExpress.XtraGrid.Columns.GridColumn GcMatricule;
        private DevExpress.XtraGrid.Columns.GridColumn MontantJournalier;
    }
}