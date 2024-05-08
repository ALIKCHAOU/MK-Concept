namespace Gestion_de_Stock.Forms
{
    partial class FrmDemandeRetour
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDemandeRetour));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.TxtMettrage = new DevExpress.XtraEditors.TextEdit();
            this.checkBoxAjouterChute = new System.Windows.Forms.CheckBox();
            this.TxtCodeLigne = new DevExpress.XtraEditors.TextEdit();
            this.TxtQuantiteVendu = new DevExpress.XtraEditors.TextEdit();
            this.BtnEnregistrer = new DevExpress.XtraEditors.SimpleButton();
            this.checkRetourStock = new System.Windows.Forms.CheckBox();
            this.TxtQte = new DevExpress.XtraEditors.TextEdit();
            this.TxtNomArticle = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMettrage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCodeLigne.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtQuantiteVendu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtQte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNomArticle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
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
            this.layoutControl1.Size = new System.Drawing.Size(544, 261);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(520, 237);
            this.groupControl1.TabIndex = 4;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.TxtMettrage);
            this.layoutControl2.Controls.Add(this.checkBoxAjouterChute);
            this.layoutControl2.Controls.Add(this.TxtCodeLigne);
            this.layoutControl2.Controls.Add(this.TxtQuantiteVendu);
            this.layoutControl2.Controls.Add(this.BtnEnregistrer);
            this.layoutControl2.Controls.Add(this.checkRetourStock);
            this.layoutControl2.Controls.Add(this.TxtQte);
            this.layoutControl2.Controls.Add(this.TxtNomArticle);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 20);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(516, 215);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // TxtMettrage
            // 
            this.TxtMettrage.Location = new System.Drawing.Point(294, 132);
            this.TxtMettrage.Name = "TxtMettrage";
            this.TxtMettrage.Properties.Mask.EditMask = "n0";
            this.TxtMettrage.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TxtMettrage.Size = new System.Drawing.Size(210, 20);
            this.TxtMettrage.StyleController = this.layoutControl2;
            this.TxtMettrage.TabIndex = 11;
            // 
            // checkBoxAjouterChute
            // 
            this.checkBoxAjouterChute.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAjouterChute.Location = new System.Drawing.Point(12, 132);
            this.checkBoxAjouterChute.Name = "checkBoxAjouterChute";
            this.checkBoxAjouterChute.Size = new System.Drawing.Size(169, 20);
            this.checkBoxAjouterChute.TabIndex = 10;
            this.checkBoxAjouterChute.Text = "Ajouter Chute";
            this.checkBoxAjouterChute.UseVisualStyleBackColor = true;
            this.checkBoxAjouterChute.CheckedChanged += new System.EventHandler(this.checkBoxAjouterChute_CheckedChanged);
            // 
            // TxtCodeLigne
            // 
            this.TxtCodeLigne.Location = new System.Drawing.Point(121, 12);
            this.TxtCodeLigne.Name = "TxtCodeLigne";
            this.TxtCodeLigne.Properties.ReadOnly = true;
            this.TxtCodeLigne.Size = new System.Drawing.Size(383, 20);
            this.TxtCodeLigne.StyleController = this.layoutControl2;
            this.TxtCodeLigne.TabIndex = 9;
            // 
            // TxtQuantiteVendu
            // 
            this.TxtQuantiteVendu.Location = new System.Drawing.Point(121, 60);
            this.TxtQuantiteVendu.Name = "TxtQuantiteVendu";
            this.TxtQuantiteVendu.Properties.ReadOnly = true;
            this.TxtQuantiteVendu.Size = new System.Drawing.Size(383, 20);
            this.TxtQuantiteVendu.StyleController = this.layoutControl2;
            this.TxtQuantiteVendu.TabIndex = 8;
            // 
            // BtnEnregistrer
            // 
            this.BtnEnregistrer.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnregistrer.Appearance.Options.UseFont = true;
            this.BtnEnregistrer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnEnregistrer.ImageOptions.Image")));
            this.BtnEnregistrer.Location = new System.Drawing.Point(261, 177);
            this.BtnEnregistrer.Name = "BtnEnregistrer";
            this.BtnEnregistrer.Size = new System.Drawing.Size(243, 26);
            this.BtnEnregistrer.StyleController = this.layoutControl2;
            this.BtnEnregistrer.TabIndex = 7;
            this.BtnEnregistrer.Text = "Enregistrer";
            this.BtnEnregistrer.Click += new System.EventHandler(this.BtnEnregistrer_Click);
            // 
            // checkRetourStock
            // 
            this.checkRetourStock.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkRetourStock.Location = new System.Drawing.Point(12, 108);
            this.checkRetourStock.Name = "checkRetourStock";
            this.checkRetourStock.Size = new System.Drawing.Size(492, 20);
            this.checkRetourStock.TabIndex = 6;
            this.checkRetourStock.Text = "Ajouter Au Stock";
            this.checkRetourStock.UseVisualStyleBackColor = true;
            this.checkRetourStock.CheckedChanged += new System.EventHandler(this.checkRetourStock_CheckedChanged);
            // 
            // TxtQte
            // 
            this.TxtQte.EditValue = "1";
            this.TxtQte.Location = new System.Drawing.Point(121, 84);
            this.TxtQte.Name = "TxtQte";
            this.TxtQte.Properties.ReadOnly = true;
            this.TxtQte.Size = new System.Drawing.Size(383, 20);
            this.TxtQte.StyleController = this.layoutControl2;
            this.TxtQte.TabIndex = 5;
            // 
            // TxtNomArticle
            // 
            this.TxtNomArticle.Location = new System.Drawing.Point(121, 36);
            this.TxtNomArticle.Name = "TxtNomArticle";
            this.TxtNomArticle.Properties.ReadOnly = true;
            this.TxtNomArticle.Size = new System.Drawing.Size(383, 20);
            this.TxtNomArticle.StyleController = this.layoutControl2;
            this.TxtNomArticle.TabIndex = 4;
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
            this.layoutControlItem5,
            this.emptySpaceItem2,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(516, 215);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.TxtNomArticle;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(496, 24);
            this.layoutControlItem2.Text = "Nom Article";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(106, 15);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 144);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(496, 21);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.TxtQte;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(496, 24);
            this.layoutControlItem3.Text = "Quantite Retournée";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(106, 15);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.checkRetourStock;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(496, 24);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.BtnEnregistrer;
            this.layoutControlItem5.Location = new System.Drawing.Point(249, 165);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(247, 30);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 165);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(249, 30);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.Control = this.TxtQuantiteVendu;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(496, 24);
            this.layoutControlItem6.Text = "Quantite Vendu";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(106, 15);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem7.Control = this.TxtCodeLigne;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(496, 24);
            this.layoutControlItem7.Text = "Code Ligne";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(106, 15);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.checkBoxAjouterChute;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(173, 24);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem9.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem9.Control = this.TxtMettrage;
            this.layoutControlItem9.Location = new System.Drawing.Point(173, 120);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(323, 24);
            this.layoutControlItem9.Text = "Mettrage";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(106, 15);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(544, 261);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(524, 241);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // FrmDemandeRetour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 261);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmDemandeRetour";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demande de Retour";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDemandeRetour_FormClosed);
            this.Load += new System.EventHandler(this.FrmDemandeRetour_Load);
            this.Shown += new System.EventHandler(this.FrmDemandeRetour_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TxtMettrage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCodeLigne.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtQuantiteVendu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtQte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNomArticle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
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
        private DevExpress.XtraEditors.SimpleButton BtnEnregistrer;
        private System.Windows.Forms.CheckBox checkRetourStock;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        public DevExpress.XtraEditors.TextEdit TxtNomArticle;
        public DevExpress.XtraEditors.TextEdit TxtQte;
        public DevExpress.XtraEditors.TextEdit TxtQuantiteVendu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        public DevExpress.XtraEditors.TextEdit TxtCodeLigne;
        private DevExpress.XtraEditors.TextEdit TxtMettrage;
        private System.Windows.Forms.CheckBox checkBoxAjouterChute;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}