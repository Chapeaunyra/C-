namespace EMFI_Comparaison
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chercheFichier = new System.Windows.Forms.OpenFileDialog();
            this.maReference = new System.Windows.Forms.RichTextBox();
            this.monPdf = new System.Windows.Forms.RichTextBox();
            this.monFichierReference = new System.Windows.Forms.Button();
            this.monFichierPdf = new System.Windows.Forms.Button();
            this.maComparaison = new System.Windows.Forms.Button();
            this.pannelGauche = new System.Windows.Forms.Panel();
            this.monEffacement = new System.Windows.Forms.Button();
            this.pannelLogo = new System.Windows.Forms.Panel();
            this.nomEntreprise = new System.Windows.Forms.Label();
            this.monImpression = new System.Windows.Forms.Button();
            this.pannelHaut = new System.Windows.Forms.Panel();
            this.labelProduit = new System.Windows.Forms.Label();
            this.labelReference = new System.Windows.Forms.Label();
            this.Reduire = new System.Windows.Forms.PictureBox();
            this.Quitter = new System.Windows.Forms.PictureBox();
            this.Titre = new System.Windows.Forms.Label();
            this.pannelGauche.SuspendLayout();
            this.pannelLogo.SuspendLayout();
            this.pannelHaut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Reduire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quitter)).BeginInit();
            this.SuspendLayout();
            // 
            // chercheFichier
            // 
            this.chercheFichier.DefaultExt = "docx";
            resources.ApplyResources(this.chercheFichier, "chercheFichier");
            this.chercheFichier.RestoreDirectory = true;
            // 
            // maReference
            // 
            resources.ApplyResources(this.maReference, "maReference");
            this.maReference.BackColor = System.Drawing.Color.White;
            this.maReference.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.maReference.HideSelection = false;
            this.maReference.Name = "maReference";
            this.maReference.ReadOnly = true;
            this.maReference.DoubleClick += new System.EventHandler(this.maReference_DoubleClick);
            // 
            // monPdf
            // 
            resources.ApplyResources(this.monPdf, "monPdf");
            this.monPdf.BackColor = System.Drawing.Color.White;
            this.monPdf.EnableAutoDragDrop = true;
            this.monPdf.HideSelection = false;
            this.monPdf.Name = "monPdf";
            this.monPdf.ReadOnly = true;
            this.monPdf.DoubleClick += new System.EventHandler(this.monPdf_DoubleClick);
            // 
            // monFichierReference
            // 
            resources.ApplyResources(this.monFichierReference, "monFichierReference");
            this.monFichierReference.BackColor = System.Drawing.Color.Black;
            this.monFichierReference.FlatAppearance.BorderSize = 0;
            this.monFichierReference.ForeColor = System.Drawing.Color.White;
            this.monFichierReference.Name = "monFichierReference";
            this.monFichierReference.UseVisualStyleBackColor = false;
            this.monFichierReference.Click += new System.EventHandler(this.monFichierReference_Click);
            this.monFichierReference.MouseEnter += new System.EventHandler(this.monFichierReference_MouseEnter);
            this.monFichierReference.MouseLeave += new System.EventHandler(this.monFichierReference_MouseLeave);
            // 
            // monFichierPdf
            // 
            resources.ApplyResources(this.monFichierPdf, "monFichierPdf");
            this.monFichierPdf.BackColor = System.Drawing.Color.Black;
            this.monFichierPdf.FlatAppearance.BorderSize = 0;
            this.monFichierPdf.ForeColor = System.Drawing.Color.White;
            this.monFichierPdf.Name = "monFichierPdf";
            this.monFichierPdf.UseVisualStyleBackColor = false;
            this.monFichierPdf.Click += new System.EventHandler(this.monFichierPdf_Click);
            this.monFichierPdf.MouseEnter += new System.EventHandler(this.monFichierPdf_MouseEnter);
            this.monFichierPdf.MouseLeave += new System.EventHandler(this.monFichierPdf_MouseLeave);
            // 
            // maComparaison
            // 
            resources.ApplyResources(this.maComparaison, "maComparaison");
            this.maComparaison.BackColor = System.Drawing.Color.Black;
            this.maComparaison.FlatAppearance.BorderSize = 0;
            this.maComparaison.ForeColor = System.Drawing.Color.White;
            this.maComparaison.Name = "maComparaison";
            this.maComparaison.UseVisualStyleBackColor = false;
            this.maComparaison.Click += new System.EventHandler(this.maComparaison_Click);
            this.maComparaison.MouseEnter += new System.EventHandler(this.maComparaison_MouseEnter);
            this.maComparaison.MouseLeave += new System.EventHandler(this.maComparaison_MouseLeave);
            // 
            // pannelGauche
            // 
            resources.ApplyResources(this.pannelGauche, "pannelGauche");
            this.pannelGauche.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pannelGauche.Controls.Add(this.monEffacement);
            this.pannelGauche.Controls.Add(this.pannelLogo);
            this.pannelGauche.Controls.Add(this.monFichierReference);
            this.pannelGauche.Controls.Add(this.maComparaison);
            this.pannelGauche.Controls.Add(this.monFichierPdf);
            this.pannelGauche.Controls.Add(this.monImpression);
            this.pannelGauche.Name = "pannelGauche";
            // 
            // monEffacement
            // 
            resources.ApplyResources(this.monEffacement, "monEffacement");
            this.monEffacement.BackColor = System.Drawing.Color.Black;
            this.monEffacement.FlatAppearance.BorderSize = 0;
            this.monEffacement.ForeColor = System.Drawing.Color.White;
            this.monEffacement.Name = "monEffacement";
            this.monEffacement.UseVisualStyleBackColor = false;
            this.monEffacement.Click += new System.EventHandler(this.monEffacement_Click);
            this.monEffacement.MouseEnter += new System.EventHandler(this.monEffacement_MouseEnter);
            this.monEffacement.MouseLeave += new System.EventHandler(this.monEffacement_MouseLeave);
            // 
            // pannelLogo
            // 
            resources.ApplyResources(this.pannelLogo, "pannelLogo");
            this.pannelLogo.BackColor = System.Drawing.Color.Orange;
            this.pannelLogo.Controls.Add(this.nomEntreprise);
            this.pannelLogo.Name = "pannelLogo";
            // 
            // nomEntreprise
            // 
            resources.ApplyResources(this.nomEntreprise, "nomEntreprise");
            this.nomEntreprise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nomEntreprise.ForeColor = System.Drawing.Color.White;
            this.nomEntreprise.Name = "nomEntreprise";
            // 
            // monImpression
            // 
            resources.ApplyResources(this.monImpression, "monImpression");
            this.monImpression.BackColor = System.Drawing.Color.Black;
            this.monImpression.FlatAppearance.BorderSize = 0;
            this.monImpression.ForeColor = System.Drawing.Color.White;
            this.monImpression.Name = "monImpression";
            this.monImpression.UseVisualStyleBackColor = false;
            this.monImpression.Click += new System.EventHandler(this.monImpression_Click);
            this.monImpression.MouseEnter += new System.EventHandler(this.monImpression_MouseEnter);
            this.monImpression.MouseLeave += new System.EventHandler(this.monImpression_MouseLeave);
            // 
            // pannelHaut
            // 
            resources.ApplyResources(this.pannelHaut, "pannelHaut");
            this.pannelHaut.BackColor = System.Drawing.Color.Black;
            this.pannelHaut.Controls.Add(this.labelProduit);
            this.pannelHaut.Controls.Add(this.labelReference);
            this.pannelHaut.Controls.Add(this.Reduire);
            this.pannelHaut.Controls.Add(this.Quitter);
            this.pannelHaut.Controls.Add(this.Titre);
            this.pannelHaut.Name = "pannelHaut";
            this.pannelHaut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pannelHaut_MouseDown);
            // 
            // labelProduit
            // 
            resources.ApplyResources(this.labelProduit, "labelProduit");
            this.labelProduit.BackColor = System.Drawing.Color.Teal;
            this.labelProduit.ForeColor = System.Drawing.Color.White;
            this.labelProduit.Name = "labelProduit";
            // 
            // labelReference
            // 
            resources.ApplyResources(this.labelReference, "labelReference");
            this.labelReference.BackColor = System.Drawing.Color.Teal;
            this.labelReference.ForeColor = System.Drawing.Color.White;
            this.labelReference.Name = "labelReference";
            // 
            // Reduire
            // 
            resources.ApplyResources(this.Reduire, "Reduire");
            this.Reduire.BackColor = System.Drawing.Color.Transparent;
            this.Reduire.Name = "Reduire";
            this.Reduire.TabStop = false;
            this.Reduire.Click += new System.EventHandler(this.Reduire_Click);
            // 
            // Quitter
            // 
            resources.ApplyResources(this.Quitter, "Quitter");
            this.Quitter.BackColor = System.Drawing.Color.White;
            this.Quitter.Name = "Quitter";
            this.Quitter.TabStop = false;
            this.Quitter.Click += new System.EventHandler(this.Quitter_Click);
            // 
            // Titre
            // 
            resources.ApplyResources(this.Titre, "Titre");
            this.Titre.BackColor = System.Drawing.Color.Transparent;
            this.Titre.ForeColor = System.Drawing.Color.White;
            this.Titre.Name = "Titre";
            this.Titre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Titre_MouseDown);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.pannelHaut);
            this.Controls.Add(this.pannelGauche);
            this.Controls.Add(this.monPdf);
            this.Controls.Add(this.maReference);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pannelGauche.ResumeLayout(false);
            this.pannelLogo.ResumeLayout(false);
            this.pannelHaut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Reduire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quitter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog chercheFichier;
        private System.Windows.Forms.RichTextBox maReference;
        private System.Windows.Forms.RichTextBox monPdf;
        private System.Windows.Forms.Button monFichierReference;
        private System.Windows.Forms.Button monFichierPdf;
        private System.Windows.Forms.Button maComparaison;
        private System.Windows.Forms.Panel pannelGauche;
        private System.Windows.Forms.Panel pannelLogo;
        private System.Windows.Forms.Panel pannelHaut;
        private System.Windows.Forms.Label nomEntreprise;
        private System.Windows.Forms.Button monImpression;
        private System.Windows.Forms.PictureBox Reduire;
        private System.Windows.Forms.PictureBox Quitter;
        private System.Windows.Forms.Label Titre;
        private System.Windows.Forms.Label labelProduit;
        private System.Windows.Forms.Label labelReference;
        private System.Windows.Forms.Button monEffacement;
    }
}

