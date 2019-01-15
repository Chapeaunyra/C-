using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing.Printing;
using System.IO;

namespace EMFI_Comparaison
{
    public partial class Form1 : Form
    {

        

        public Form1()
        {
            InitializeComponent();
        }

        #region Variables nécessaire pour le déplacement de fenêtre
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            String monUtilisateur = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            chercheFichier.InitialDirectory = "C://Users/" + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Documents";
            /*
            this.maReference.AllowDrop = true;
            monPdf.AllowDrop = true;
            this.maReference.DragEnter += new DragEventHandler(maReference_DragEnter);
            // monPdf.DragEnter += new DragEventHandler(monPdf_DragEnter);
            this.maReference.DragDrop += new DragEventHandler(maReference_DragDrop);
            // monPdf.DragDrop += new DragEventHandler(monPdf_DragDrop);
            */
    }

        #region Bouton users
        private void monFichierReference_Click(object sender, EventArgs e)
            {
                maReference.Text = "";
                chercheFichier.Filter = "Fichier Word (*.docx)|*.docx|All files (*.*)|*.*";

                // Extraction du texte de word si le résultat de la boîte de dialogue est bon
                if (chercheFichier.ShowDialog() == DialogResult.OK)
                {
                    ConvertionDocx convertisseurWord = new ConvertionDocx();

                    maReference.Text = convertisseurWord.OuvrirLireQuitter(chercheFichier.FileName);
                }
            }

        private void monFichierPdf_Click(object sender, EventArgs e)
            {
                monPdf.Text = "";
                chercheFichier.Filter = "Fichier pdf (*.pdf)|*.pdf|All files (*.*)|*.*";

                if (chercheFichier.ShowDialog() == DialogResult.OK)
                {
                    // Extraire txt du pdf
                    ConvertionPDF convertisseurPdf = new ConvertionPDF();
                    monPdf.Text = convertisseurPdf.ExtraireText(chercheFichier.FileName);
                }
            }

        private void maComparaison_Click(object sender, EventArgs e)
        {
            if (maReference.SelectedText == "" && monPdf.SelectedText == "")
            {
                Comparer c = new Comparer(maReference.Text, monPdf.Text);
                monPdf.Text = c.getPresent();
                maReference.Text = c.getAbsent();

                colorisation();
            }
            else if (maReference.SelectedText == "" && monPdf.SelectedText != "")
            {
                Comparer c = new Comparer(maReference.Text, monPdf.SelectedText);
                monPdf.Text = c.getPresent();
                maReference.Text = c.getAbsent();

                colorisation();
            }
            else if (maReference.SelectedText != "" && monPdf.SelectedText == "")
            {
                Comparer c = new Comparer(maReference.SelectedText, monPdf.Text);
                monPdf.Text = c.getPresent();
                maReference.Text = c.getAbsent();

                colorisation();
            }
            else if (maReference.SelectedText != "" && monPdf.SelectedText != "")
            {
                Comparer c = new Comparer(maReference.SelectedText, monPdf.SelectedText);
                monPdf.Text = c.getPresent();
                maReference.Text = c.getAbsent();

                colorisation();
            }
        }

        private void monImpression_Click(object sender, EventArgs e)
        {
            PrintDocument _printDocument = new PrintDocument();
            PrintDialog printDialog = new PrintDialog();
            _printDocument.Print();
        }

        private void monEffacement_Click(object sender, EventArgs e)
            {
                monPdf.Text = "";
                maReference.Text = "";
            }

        #endregion

        #region Event lié au visuel users

        private void maReference_DoubleClick(object sender, EventArgs e)
        {
            monFichierReference_Click(sender, e);
        }

        private void monPdf_DoubleClick(object sender, EventArgs e)
        {
            monFichierPdf_Click(sender, e);
        }

        /*
        void maReference_DragEnter(object sender, DragEventArgs e)
        {
            monPdf.Text = "REUSSIT";
            Console.WriteLine("DragEnter!");
            e.Effect = DragDropEffects.Copy;

        }
        
        void maReference_DragDrop(object sender, DragEventArgs e)
        {

            // string[] filenames = e.Data.GetData(DataFormats.FileDrop) as string[];

            // string filetype = filenames[0].Substring(filenames[0].LastIndexOf(@"\") + 1);

            monFichierReference_Click(sender, e);

        }
        */
        #endregion

        #region MouseOver orange

        private void monFichierReference_MouseLeave(object sender, EventArgs e)
            {
                monFichierReference.ForeColor = Color.White;
            }

            private void monFichierReference_MouseEnter(object sender, EventArgs e)
            {
                monFichierReference.ForeColor = Color.Orange;
            }

            private void monFichierPdf_MouseEnter(object sender, EventArgs e)
            {
                monFichierPdf.ForeColor = Color.Orange;
            }

            private void monFichierPdf_MouseLeave(object sender, EventArgs e)
            {
                monFichierPdf.ForeColor = Color.White;
            }

            private void maComparaison_MouseEnter(object sender, EventArgs e)
            {
                maComparaison.ForeColor = Color.Orange;
            }

            private void maComparaison_MouseLeave(object sender, EventArgs e)
            {
                maComparaison.ForeColor = Color.White;
            }

            private void monImpression_MouseEnter(object sender, EventArgs e)
            {
                monImpression.ForeColor = Color.Orange;
            }

            private void monImpression_MouseLeave(object sender, EventArgs e)
            {
                monImpression.ForeColor = Color.White;
            }

            private void monEffacement_MouseEnter(object sender, EventArgs e)
            {
                monEffacement.ForeColor = Color.Orange;
            }

        private void monEffacement_MouseLeave(object sender, EventArgs e)
        {
            monEffacement.ForeColor = Color.White;
        }



        #endregion

        #region Options de la fenêtre

        private void Titre_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }

            private void Quitter_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }

            private void Reduire_Click(object sender, EventArgs e)
            {
                this.WindowState = FormWindowState.Minimized;
            }

            private void pannelHaut_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }


        #endregion

        #region Fonctions

        private void colorisation()
        {
            labelProduit.Text = "Présent";
            monPdf.ForeColor = Color.Green;

            labelReference.Text = "Absent";
            maReference.ForeColor = Color.Red;
        }

        #endregion


    }
}
