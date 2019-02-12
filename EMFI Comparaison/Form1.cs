using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EMFI_Comparaison
{
    public partial class Form1 : Form
    {
        TextBox impress = new TextBox();

        // 144,238,144 = LightGreen     ====> Première couleur
        // 255,182,193 = LightPink      ====> Deuxième couleur
        // 173,216,230 = LightBlue      ====> Troisième couleur
        String Rtf = @"{\rtf1\ansi{\colortbl;
                                   \red144\green238\blue144;
                                   \red255\green182\blue193;
                                   \red173\green216\blue230;
                       }";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String monUtilisateur = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            chercheFichier.InitialDirectory = "C://Users/" + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Documents";
            impress.Visible = false;
            impress.Multiline = true;

            Responsivity();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Responsivity();
        }



        #region Impression

        private void PrintPanel()
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
            doc.Print();
        }

        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            //1 cm ~ 37.5px
            int pixelsWidth = 787;      // 21 cm
            int pixelsHeight = 1114;    // 29.7 cm
            Bitmap bmp = new Bitmap(pixelsWidth, pixelsHeight);

            float tgtWidthMM = 210;  //A4 paper size
            float tgtHeightMM = 297;
            float tgtWidthInches = tgtWidthMM / 25.4f;
            float tgtHeightInches = tgtHeightMM / 25.4f;
            float srcWidthPx = bmp.Width;
            float srcHeightPx = bmp.Height;
            float dpiX = srcWidthPx / tgtWidthInches;       // 787 / (210/25.4) = 95, 189524217
            float dpiY = srcHeightPx / tgtHeightInches;

            bmp.SetResolution(dpiX, dpiY);
            impress.DrawToBitmap(bmp, impress.ClientRectangle);

            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            e.Graphics.DrawImage(bmp, 0, 0, tgtWidthMM, tgtHeightMM);
        }

        #endregion

        #region Bouton users

        private void monFichierReference_Click(object sender, EventArgs e)
        {
            reset(rtbDocx);
            chercheFichier.Filter = "Fichier Word (*.docx)|*.docx|All files (*.*)|*.*";

            // Extraction du texte de word si le résultat de la boîte de dialogue est bon
            if (chercheFichier.ShowDialog() == DialogResult.OK)
            {
                ConvertionDocx convertisseurWord = new ConvertionDocx();
         
                rtbDocx.Text = convertisseurWord.OuvrirLireQuitter(chercheFichier.FileName);
            }
        }

        private void monFichierPdf_Click(object sender, EventArgs e)
        {
            reset(rtbPdf);
            chercheFichier.Filter = "Fichier pdf (*.pdf)|*.pdf|All files (*.*)|*.*";

            if (chercheFichier.ShowDialog() == DialogResult.OK)
            {
                    // Extraire txt du pdf
                ConvertionPDF convertisseurPdf = new ConvertionPDF();
                rtbPdf.Text = convertisseurPdf.ExtraireText(chercheFichier.FileName);
            }
        }

        private void maComparaison_Click(object sender, EventArgs e)
        {
            if (rtbDocx.SelectedText == String.Empty && rtbPdf.SelectedText == String.Empty)
            {
                Comparer c = new Comparer(rtbDocx.Text, rtbPdf.Text, Rtf);
                rtbResultat.Rtf = c.getResultat();
                rtbDocx.Rtf = c.getPresent();
                rtbPdf.Rtf = c.getAbsent();
            }
            else if (rtbDocx.SelectedText == String.Empty && rtbPdf.SelectedText != String.Empty)
            {
                Comparer c = new Comparer(rtbDocx.Text, rtbPdf.SelectedText, Rtf);
                rtbResultat.Rtf = c.getResultat();
                rtbDocx.Rtf = c.getPresent();
                rtbPdf.Rtf = c.getAbsent();
            }
            else if (rtbDocx.SelectedText != String.Empty && rtbPdf.SelectedText == String.Empty)
            {
                Comparer c = new Comparer(rtbDocx.SelectedText, rtbPdf.Text, Rtf);
                rtbResultat.Rtf = c.getResultat();
                rtbDocx.Rtf = c.getPresent();
                rtbPdf.Rtf = c.getAbsent();
            }
            else if (rtbDocx.SelectedText != String.Empty && rtbPdf.SelectedText != String.Empty)
            {
                Comparer c = new Comparer(rtbDocx.SelectedText, rtbPdf.SelectedText, Rtf);
                rtbResultat.Rtf = c.getResultat();
                rtbDocx.Rtf = c.getPresent();
                rtbPdf.Rtf = c.getAbsent();
            }
            // colorisation();
        }

        private void monEffacement_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void monImpression_Click(object sender, EventArgs e)
        {
            impress.Text = "######## PRESENT ###########" + Environment.NewLine + rtbPdf.Text + Environment.NewLine + rtbPdf.Text +
                        "######## ABSENT ###########" + Environment.NewLine + Environment.NewLine + rtbPdf.Text + rtbDocx.Text;
            impress.Width = rtbResultat.Width;
            impress.Height = rtbResultat.Height;
            PrintPanel();
        }
        

        #endregion

        #region Event lié au visuel users

        private void rtbDocx_DoubleClick(object sender, EventArgs e)
        {
            monFichierReference_Click(sender, e);
        }

        private void rtbPdf_DoubleClick(object sender, EventArgs e)
        {
            monFichierPdf_Click(sender, e);
        }


        private void rtbResultat_DoubleClick(object sender, EventArgs e)
        {
            if(rtbPdf.Text != String.Empty && rtbDocx.Text != String.Empty)
            {
                maComparaison_Click(sender, e);
            }
        }

        /*
        void rtbDocx_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        
        void rtbDocx_DragDrop(object sender, DragEventArgs e)
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

        #region Fonctions

        private void colorisation()
        {
            rtbPdf.ForeColor = Color.Red;
            rtbDocx.ForeColor = Color.Green;
        }

        private void reset()
        {
            rtbDocx.Rtf = String.Empty;
            rtbDocx.Text = String.Empty;
            rtbDocx.ForeColor = Color.Black;

            rtbPdf.Rtf = String.Empty;
            rtbPdf.Text = String.Empty;
            rtbPdf.ForeColor = Color.Black;

            rtbResultat.Rtf = String.Empty;
            rtbResultat.Text = String.Empty;
            rtbResultat.ForeColor = Color.Black;
        }

        private void reset(RichTextBox rtb)
        {
            rtb.Rtf = String.Empty;
            rtb.ForeColor = Color.Black;
        }

        private void Responsivity()
        {
            // SIZING
            int sWidth = this.ClientSize.Width;
            int sHeight = this.ClientSize.Height;

            // setting up BOUNDS                    ( x, y, width, hheight )
            monFichierReference.SetBounds(0, 0, sWidth / 5, sHeight / 20);
            monFichierPdf.SetBounds(sWidth / 5 , 0, sWidth / 5, sHeight / 20);
            maComparaison.SetBounds(sWidth / 5 * 2, 0, sWidth / 5, sHeight / 20);
            monImpression.SetBounds(sWidth / 5 * 3, 0, sWidth / 5, sHeight / 20);
            monEffacement.SetBounds(sWidth / 5 * 4, 0, sWidth / 5, sHeight / 20);


            // OK
            rtbDocx.SetBounds(5,
                              monFichierReference.Height + 10,
                              sWidth / 3 - 10,
                              sHeight / 20 * 18);
            rtbPdf.SetBounds(sWidth / 3 + 5,
                             monFichierReference.Height + 10,
                             sWidth / 3 - 10,
                             sHeight / 20 * 18);
            rtbResultat.SetBounds(sWidth / 3 * 2 + 5,
                                  monFichierReference.Height + 10,
                                  sWidth / 3 - 10,
                                  sHeight / 20 * 18);
        }


        #endregion

        
    }
}
