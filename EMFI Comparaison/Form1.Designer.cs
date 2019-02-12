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
            this.monFichierReference = new System.Windows.Forms.Button();
            this.monFichierPdf = new System.Windows.Forms.Button();
            this.maComparaison = new System.Windows.Forms.Button();
            this.monImpression = new System.Windows.Forms.Button();
            this.monEffacement = new System.Windows.Forms.Button();
            this.pannelHaut = new System.Windows.Forms.Panel();
            this.rtbDocx = new System.Windows.Forms.RichTextBox();
            this.rtbPdf = new System.Windows.Forms.RichTextBox();
            this.rtbResultat = new System.Windows.Forms.RichTextBox();
            this.pannelHaut.SuspendLayout();
            this.SuspendLayout();
            // 
            // chercheFichier
            // 
            this.chercheFichier.DefaultExt = "docx";
            resources.ApplyResources(this.chercheFichier, "chercheFichier");
            this.chercheFichier.RestoreDirectory = true;
            // 
            // monFichierReference
            // 
            this.monFichierReference.BackColor = System.Drawing.Color.DarkSlateGray;
            resources.ApplyResources(this.monFichierReference, "monFichierReference");
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
            this.monFichierPdf.BackColor = System.Drawing.Color.DarkSlateGray;
            resources.ApplyResources(this.monFichierPdf, "monFichierPdf");
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
            this.maComparaison.BackColor = System.Drawing.Color.DarkSlateGray;
            resources.ApplyResources(this.maComparaison, "maComparaison");
            this.maComparaison.FlatAppearance.BorderSize = 0;
            this.maComparaison.ForeColor = System.Drawing.Color.White;
            this.maComparaison.Name = "maComparaison";
            this.maComparaison.UseVisualStyleBackColor = false;
            this.maComparaison.Click += new System.EventHandler(this.maComparaison_Click);
            this.maComparaison.MouseEnter += new System.EventHandler(this.maComparaison_MouseEnter);
            this.maComparaison.MouseLeave += new System.EventHandler(this.maComparaison_MouseLeave);
            // 
            // monImpression
            // 
            this.monImpression.BackColor = System.Drawing.Color.DarkSlateGray;
            resources.ApplyResources(this.monImpression, "monImpression");
            this.monImpression.FlatAppearance.BorderSize = 0;
            this.monImpression.ForeColor = System.Drawing.Color.White;
            this.monImpression.Name = "monImpression";
            this.monImpression.UseVisualStyleBackColor = false;
            this.monImpression.Click += new System.EventHandler(this.monImpression_Click);
            this.monImpression.MouseEnter += new System.EventHandler(this.monImpression_MouseEnter);
            this.monImpression.MouseLeave += new System.EventHandler(this.monImpression_MouseLeave);
            // 
            // monEffacement
            // 
            this.monEffacement.BackColor = System.Drawing.Color.DarkSlateGray;
            resources.ApplyResources(this.monEffacement, "monEffacement");
            this.monEffacement.FlatAppearance.BorderSize = 0;
            this.monEffacement.ForeColor = System.Drawing.Color.White;
            this.monEffacement.Name = "monEffacement";
            this.monEffacement.UseVisualStyleBackColor = false;
            this.monEffacement.Click += new System.EventHandler(this.monEffacement_Click);
            this.monEffacement.MouseEnter += new System.EventHandler(this.monEffacement_MouseEnter);
            this.monEffacement.MouseLeave += new System.EventHandler(this.monEffacement_MouseLeave);
            // 
            // pannelHaut
            // 
            resources.ApplyResources(this.pannelHaut, "pannelHaut");
            this.pannelHaut.BackColor = System.Drawing.Color.Teal;
            this.pannelHaut.Controls.Add(this.monFichierReference);
            this.pannelHaut.Controls.Add(this.monFichierPdf);
            this.pannelHaut.Controls.Add(this.monEffacement);
            this.pannelHaut.Controls.Add(this.monImpression);
            this.pannelHaut.Controls.Add(this.maComparaison);
            this.pannelHaut.Name = "pannelHaut";
            // 
            // rtbDocx
            // 
            resources.ApplyResources(this.rtbDocx, "rtbDocx");
            this.rtbDocx.Name = "rtbDocx";
            this.rtbDocx.DoubleClick += new System.EventHandler(this.rtbDocx_DoubleClick);
            // 
            // rtbPdf
            // 
            resources.ApplyResources(this.rtbPdf, "rtbPdf");
            this.rtbPdf.Name = "rtbPdf";
            this.rtbPdf.DoubleClick += new System.EventHandler(this.monFichierPdf_Click);
            // 
            // rtbResultat
            // 
            resources.ApplyResources(this.rtbResultat, "rtbResultat");
            this.rtbResultat.Name = "rtbResultat";
            this.rtbResultat.DoubleClick += new System.EventHandler(this.rtbResultat_DoubleClick);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.rtbResultat);
            this.Controls.Add(this.rtbPdf);
            this.Controls.Add(this.rtbDocx);
            this.Controls.Add(this.pannelHaut);
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ClientSizeChanged += new System.EventHandler(this.Form1_Resize);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.pannelHaut.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog chercheFichier;
        private System.Windows.Forms.Button monFichierReference;
        private System.Windows.Forms.Button monFichierPdf;
        private System.Windows.Forms.Button monEffacement;
        private System.Windows.Forms.Button monImpression;
        private System.Windows.Forms.Button maComparaison;
        private System.Windows.Forms.Panel pannelHaut;
        private System.Windows.Forms.RichTextBox rtbDocx;
        private System.Windows.Forms.RichTextBox rtbPdf;
        private System.Windows.Forms.RichTextBox rtbResultat;
    }
}

