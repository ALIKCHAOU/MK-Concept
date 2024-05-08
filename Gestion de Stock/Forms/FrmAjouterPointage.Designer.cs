namespace Gestion_de_Stock.Forms
{
    partial class FrmAjouterPointage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAjouterPointage));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.TxtMontant = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxPoste = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.searchLookUpEditSalarier = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BtnValider = new DevExpress.XtraEditors.SimpleButton();
            this.dateEditDatePointage = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Date = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.Intitulé = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.salarierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pointageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMontant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxPoste.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditSalarier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDatePointage.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDatePointage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Intitulé)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salarierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.TxtMontant);
            this.layoutControl1.Controls.Add(this.comboBoxPoste);
            this.layoutControl1.Controls.Add(this.label1);
            this.layoutControl1.Controls.Add(this.searchLookUpEditSalarier);
            this.layoutControl1.Controls.Add(this.BtnValider);
            this.layoutControl1.Controls.Add(this.dateEditDatePointage);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(385, 229);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // TxtMontant
            // 
            this.TxtMontant.Location = new System.Drawing.Point(74, 119);
            this.TxtMontant.Name = "TxtMontant";
            this.TxtMontant.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMontant.Properties.Appearance.Options.UseFont = true;
            this.TxtMontant.Properties.AutoHeight = false;
            this.TxtMontant.Properties.Mask.EditMask = "n3";
            this.TxtMontant.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TxtMontant.Size = new System.Drawing.Size(299, 32);
            this.TxtMontant.StyleController = this.layoutControl1;
            this.TxtMontant.TabIndex = 11;
            // 
            // comboBoxPoste
            // 
            this.comboBoxPoste.Location = new System.Drawing.Point(74, 83);
            this.comboBoxPoste.Name = "comboBoxPoste";
            this.comboBoxPoste.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPoste.Properties.Appearance.Options.UseFont = true;
            this.comboBoxPoste.Properties.AutoHeight = false;
            this.comboBoxPoste.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxPoste.Size = new System.Drawing.Size(299, 32);
            this.comboBoxPoste.StyleController = this.layoutControl1;
            this.comboBoxPoste.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 20);
            this.label1.TabIndex = 9;
            // 
            // searchLookUpEditSalarier
            // 
            this.searchLookUpEditSalarier.EditValue = "";
            this.searchLookUpEditSalarier.Location = new System.Drawing.Point(74, 50);
            this.searchLookUpEditSalarier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchLookUpEditSalarier.Name = "searchLookUpEditSalarier";
            this.searchLookUpEditSalarier.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLookUpEditSalarier.Properties.Appearance.Options.UseFont = true;
            this.searchLookUpEditSalarier.Properties.AutoHeight = false;
            this.searchLookUpEditSalarier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEditSalarier.Properties.DataSource = this.salarierBindingSource;
            this.searchLookUpEditSalarier.Properties.DisplayMember = "Intitule";
            this.searchLookUpEditSalarier.Properties.ShowClearButton = false;
            this.searchLookUpEditSalarier.Properties.ValueMember = "Id";
            this.searchLookUpEditSalarier.Properties.View = this.searchLookUpEdit1View;
            this.searchLookUpEditSalarier.Size = new System.Drawing.Size(299, 29);
            this.searchLookUpEditSalarier.StyleController = this.layoutControl1;
            this.searchLookUpEditSalarier.TabIndex = 8;
            this.searchLookUpEditSalarier.EditValueChanged += new System.EventHandler(this.searchLookUpEditSalarier_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // BtnValider
            // 
            this.BtnValider.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnValider.Appearance.Options.UseFont = true;
            this.BtnValider.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnValider.ImageOptions.Image")));
            this.BtnValider.Location = new System.Drawing.Point(198, 155);
            this.BtnValider.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnValider.Name = "BtnValider";
            this.BtnValider.Size = new System.Drawing.Size(175, 38);
            this.BtnValider.StyleController = this.layoutControl1;
            this.BtnValider.TabIndex = 6;
            this.BtnValider.Text = "Valider";
            this.BtnValider.Click += new System.EventHandler(this.BtnValider_Click);
            // 
            // dateEditDatePointage
            // 
            this.dateEditDatePointage.EditValue = null;
            this.dateEditDatePointage.Location = new System.Drawing.Point(74, 12);
            this.dateEditDatePointage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateEditDatePointage.Name = "dateEditDatePointage";
            this.dateEditDatePointage.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEditDatePointage.Properties.Appearance.Options.UseFont = true;
            this.dateEditDatePointage.Properties.AutoHeight = false;
            this.dateEditDatePointage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDatePointage.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDatePointage.Size = new System.Drawing.Size(299, 34);
            this.dateEditDatePointage.StyleController = this.layoutControl1;
            this.dateEditDatePointage.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Date,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.Intitulé,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(385, 229);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // Date
            // 
            this.Date.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date.AppearanceItemCaption.Options.UseFont = true;
            this.Date.Control = this.dateEditDatePointage;
            this.Date.Location = new System.Drawing.Point(0, 0);
            this.Date.MinSize = new System.Drawing.Size(119, 29);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(365, 38);
            this.Date.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.Date.TextSize = new System.Drawing.Size(58, 19);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.BtnValider;
            this.layoutControlItem2.Location = new System.Drawing.Point(186, 143);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(179, 42);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 143);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(186, 42);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Intitulé
            // 
            this.Intitulé.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Intitulé.AppearanceItemCaption.Options.UseFont = true;
            this.Intitulé.Control = this.searchLookUpEditSalarier;
            this.Intitulé.Location = new System.Drawing.Point(0, 38);
            this.Intitulé.MinSize = new System.Drawing.Size(119, 29);
            this.Intitulé.Name = "Intitulé";
            this.Intitulé.Size = new System.Drawing.Size(365, 33);
            this.Intitulé.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.Intitulé.Text = "Salarié";
            this.Intitulé.TextSize = new System.Drawing.Size(58, 19);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.label1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 185);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(365, 24);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.comboBoxPoste;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 71);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(105, 36);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(365, 36);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Poste";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(58, 19);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.TxtMontant;
            this.layoutControlItem4.CustomizationFormText = "Montant";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 107);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(151, 36);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(365, 36);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Montant";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(58, 19);
            // 
            // salarierBindingSource
            // 
            this.salarierBindingSource.DataSource = typeof(Gestion_de_Stock.Model.Salarier);
            // 
            // pointageBindingSource
            // 
            this.pointageBindingSource.DataSource = typeof(Gestion_de_Stock.Model.PointageJournalier);
            // 
            // FrmAjouterPointage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 229);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmAjouterPointage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter Pointage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAjouterPointage_FormClosed);
            this.Load += new System.EventHandler(this.FrmAjouterPointage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TxtMontant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxPoste.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditSalarier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDatePointage.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDatePointage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Intitulé)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salarierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointageBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.DateEdit dateEditDatePointage;
        private DevExpress.XtraLayout.LayoutControlItem Date;
        private DevExpress.XtraEditors.SimpleButton BtnValider;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.BindingSource pointageBindingSource;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEditSalarier;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem Intitulé;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        public System.Windows.Forms.BindingSource salarierBindingSource;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxPoste;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit TxtMontant;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}