namespace Gestion_de_Stock.Forms
{
    partial class FrmAccueil
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
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement8 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement9 = new DevExpress.XtraEditors.TileItemElement();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.tileControl1 = new DevExpress.XtraEditors.TileControl();
            this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            this.tileIFrounisseurs = new DevExpress.XtraEditors.TileItem();
            this.tileISociete = new DevExpress.XtraEditors.TileItem();
            this.tileIClients = new DevExpress.XtraEditors.TileItem();
            this.tileIAchat = new DevExpress.XtraEditors.TileItem();
            this.tileIVente = new DevExpress.XtraEditors.TileItem();
            this.tileIJournalAchat = new DevExpress.XtraEditors.TileItem();
            this.tileItemListeDevis = new DevExpress.XtraEditors.TileItem();
            this.tileItemCreerDevis = new DevExpress.XtraEditors.TileItem();
            this.BtnListeVentes = new DevExpress.XtraEditors.TileItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
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
            this.layoutControl1.Size = new System.Drawing.Size(1133, 444);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1109, 420);
            this.groupControl1.TabIndex = 4;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.tileControl1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 20);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(1105, 398);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // tileControl1
            // 
            this.tileControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tileControl1.Groups.Add(this.tileGroup2);
            this.tileControl1.Location = new System.Drawing.Point(12, 12);
            this.tileControl1.MaxId = 26;
            this.tileControl1.Name = "tileControl1";
            this.tileControl1.Size = new System.Drawing.Size(1081, 374);
            this.tileControl1.TabIndex = 4;
            this.tileControl1.Text = "tileControl1";
            // 
            // tileGroup2
            // 
            this.tileGroup2.Items.Add(this.tileIFrounisseurs);
            this.tileGroup2.Items.Add(this.tileISociete);
            this.tileGroup2.Items.Add(this.tileIClients);
            this.tileGroup2.Items.Add(this.tileIAchat);
            this.tileGroup2.Items.Add(this.tileIVente);
            this.tileGroup2.Items.Add(this.tileIJournalAchat);
            this.tileGroup2.Items.Add(this.tileItemListeDevis);
            this.tileGroup2.Items.Add(this.tileItemCreerDevis);
            this.tileGroup2.Items.Add(this.BtnListeVentes);
            this.tileGroup2.Name = "tileGroup2";
            this.tileGroup2.Text = "Liste Devis";
            // 
            // tileIFrounisseurs
            // 
            this.tileIFrounisseurs.AppearanceItem.Normal.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tileIFrounisseurs.AppearanceItem.Normal.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileIFrounisseurs.AppearanceItem.Normal.ForeColor = System.Drawing.Color.White;
            this.tileIFrounisseurs.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileIFrounisseurs.AppearanceItem.Normal.Options.UseFont = true;
            this.tileIFrounisseurs.AppearanceItem.Normal.Options.UseForeColor = true;
            tileItemElement1.Image = global::Gestion_de_Stock.Properties.Resources.famille_contact;
            tileItemElement1.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement1.Text = "Fournisseurs";
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tileIFrounisseurs.Elements.Add(tileItemElement1);
            this.tileIFrounisseurs.Id = 1;
            this.tileIFrounisseurs.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileIFrounisseurs.Name = "tileIFrounisseurs";
            this.tileIFrounisseurs.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileIFrounisseurs_ItemClick);
            // 
            // tileISociete
            // 
            this.tileISociete.AppearanceItem.Normal.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tileISociete.AppearanceItem.Normal.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileISociete.AppearanceItem.Normal.ForeColor = System.Drawing.Color.White;
            this.tileISociete.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileISociete.AppearanceItem.Normal.Options.UseFont = true;
            this.tileISociete.AppearanceItem.Normal.Options.UseForeColor = true;
            tileItemElement2.Image = global::Gestion_de_Stock.Properties.Resources.banque;
            tileItemElement2.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement2.Text = "Societe";
            tileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tileISociete.Elements.Add(tileItemElement2);
            this.tileISociete.Id = 2;
            this.tileISociete.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileISociete.Name = "tileISociete";
            this.tileISociete.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileISociete_ItemClick);
            // 
            // tileIClients
            // 
            this.tileIClients.AppearanceItem.Normal.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tileIClients.AppearanceItem.Normal.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileIClients.AppearanceItem.Normal.ForeColor = System.Drawing.Color.White;
            this.tileIClients.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileIClients.AppearanceItem.Normal.Options.UseFont = true;
            this.tileIClients.AppearanceItem.Normal.Options.UseForeColor = true;
            tileItemElement3.Image = global::Gestion_de_Stock.Properties.Resources.partenaires;
            tileItemElement3.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement3.Text = "Clients";
            tileItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tileIClients.Elements.Add(tileItemElement3);
            this.tileIClients.Id = 4;
            this.tileIClients.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileIClients.Name = "tileIClients";
            this.tileIClients.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileIClients_ItemClick);
            // 
            // tileIAchat
            // 
            this.tileIAchat.AppearanceItem.Normal.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tileIAchat.AppearanceItem.Normal.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileIAchat.AppearanceItem.Normal.ForeColor = System.Drawing.Color.White;
            this.tileIAchat.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileIAchat.AppearanceItem.Normal.Options.UseFont = true;
            this.tileIAchat.AppearanceItem.Normal.Options.UseForeColor = true;
            tileItemElement4.Image = global::Gestion_de_Stock.Properties.Resources.sell;
            tileItemElement4.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement4.Text = "Achats";
            tileItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tileIAchat.Elements.Add(tileItemElement4);
            this.tileIAchat.Id = 6;
            this.tileIAchat.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileIAchat.Name = "tileIAchat";
            this.tileIAchat.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileIAchat_ItemClick);
            // 
            // tileIVente
            // 
            this.tileIVente.AppearanceItem.Normal.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tileIVente.AppearanceItem.Normal.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileIVente.AppearanceItem.Normal.ForeColor = System.Drawing.Color.White;
            this.tileIVente.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileIVente.AppearanceItem.Normal.Options.UseFont = true;
            this.tileIVente.AppearanceItem.Normal.Options.UseForeColor = true;
            tileItemElement5.Image = global::Gestion_de_Stock.Properties.Resources.caisse;
            tileItemElement5.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement5.Text = "Listes des Factures";
            tileItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tileIVente.Elements.Add(tileItemElement5);
            this.tileIVente.Id = 7;
            this.tileIVente.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileIVente.Name = "tileIVente";
            this.tileIVente.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileIVente_ItemClick);
            // 
            // tileIJournalAchat
            // 
            this.tileIJournalAchat.AppearanceItem.Normal.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tileIJournalAchat.AppearanceItem.Normal.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileIJournalAchat.AppearanceItem.Normal.ForeColor = System.Drawing.Color.White;
            this.tileIJournalAchat.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileIJournalAchat.AppearanceItem.Normal.Options.UseFont = true;
            this.tileIJournalAchat.AppearanceItem.Normal.Options.UseForeColor = true;
            tileItemElement6.Image = global::Gestion_de_Stock.Properties.Resources.sell;
            tileItemElement6.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement6.Text = "Liste des  Achats";
            tileItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tileIJournalAchat.Elements.Add(tileItemElement6);
            this.tileIJournalAchat.Id = 12;
            this.tileIJournalAchat.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileIJournalAchat.Name = "tileIJournalAchat";
            this.tileIJournalAchat.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileIJournalAchat_ItemClick);
            // 
            // tileItemListeDevis
            // 
            this.tileItemListeDevis.AppearanceItem.Normal.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tileItemListeDevis.AppearanceItem.Normal.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileItemListeDevis.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItemListeDevis.AppearanceItem.Normal.Options.UseFont = true;
            tileItemElement7.Image = global::Gestion_de_Stock.Properties.Resources.famille_articles;
            tileItemElement7.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement7.Text = "Liste Devis";
            tileItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tileItemListeDevis.Elements.Add(tileItemElement7);
            this.tileItemListeDevis.Id = 21;
            this.tileItemListeDevis.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItemListeDevis.Name = "tileItemListeDevis";
            this.tileItemListeDevis.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemListeDevis_ItemClick);
            // 
            // tileItemCreerDevis
            // 
            this.tileItemCreerDevis.AppearanceItem.Normal.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tileItemCreerDevis.AppearanceItem.Normal.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileItemCreerDevis.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItemCreerDevis.AppearanceItem.Normal.Options.UseFont = true;
            tileItemElement8.Image = global::Gestion_de_Stock.Properties.Resources.famille_articles;
            tileItemElement8.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement8.Text = "Créer Devis";
            tileItemElement8.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tileItemCreerDevis.Elements.Add(tileItemElement8);
            this.tileItemCreerDevis.Id = 13;
            this.tileItemCreerDevis.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItemCreerDevis.Name = "tileItemCreerDevis";
            this.tileItemCreerDevis.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem3_ItemClick);
            // 
            // BtnListeVentes
            // 
            this.BtnListeVentes.AppearanceItem.Normal.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BtnListeVentes.AppearanceItem.Normal.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnListeVentes.AppearanceItem.Normal.Options.UseBackColor = true;
            this.BtnListeVentes.AppearanceItem.Normal.Options.UseFont = true;
            tileItemElement9.Image = global::Gestion_de_Stock.Properties.Resources.listeventes;
            tileItemElement9.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement9.Text = "Liste Ventes";
            tileItemElement9.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.BtnListeVentes.Elements.Add(tileItemElement9);
            this.BtnListeVentes.Id = 25;
            this.BtnListeVentes.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.BtnListeVentes.Name = "BtnListeVentes";
            this.BtnListeVentes.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.BtnListeVentes_ItemClick);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1105, 398);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.tileControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1085, 378);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1133, 444);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1113, 424);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // FrmAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 444);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmAccueil";
            this.Text = "Accueil";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAccueil_FormClosed);
            this.Load += new System.EventHandler(this.FrmAccueil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
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
        private DevExpress.XtraEditors.TileControl tileControl1;
        private DevExpress.XtraEditors.TileGroup tileGroup2;
        private DevExpress.XtraEditors.TileItem tileIFrounisseurs;
        private DevExpress.XtraEditors.TileItem tileISociete;
        private DevExpress.XtraEditors.TileItem tileIClients;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TileItem tileIAchat;
        private DevExpress.XtraEditors.TileItem tileIVente;
        private DevExpress.XtraEditors.TileItem tileIJournalAchat;
        private DevExpress.XtraEditors.TileItem tileItemCreerDevis;
        private DevExpress.XtraEditors.TileItem tileItemListeDevis;
        private DevExpress.XtraEditors.TileItem BtnListeVentes;
    }
}