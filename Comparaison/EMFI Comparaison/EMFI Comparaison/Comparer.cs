using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMFI_Comparaison
{
    class Comparer
    {
        String texteReference = "";
        String texteProduit = "";
        String present = "";
        String absent = "";
        String resultat = "";

        public Comparer ()
        {
            this.texteReference = "";
            this.texteProduit = "";
            this.present = "";
            this.absent = "";
            this.resultat = "";
        }


        public Comparer(String str1, String str2)
        {
            this.texteReference = Nettoyage(str1);
            this.texteProduit = Nettoyage(str2);

            Traitement();
        }


        private void Traitement()
        {
            String phrasesRef = DecoupagePhrase(this.texteReference);
            String phrasesProd = DecoupagePhrase(this.texteProduit);

            List<String> motsRef = DecoupageMot(phrasesRef);
            List<String> motsProd = DecoupageMot(phrasesProd);

            Comparaison(motsRef, motsProd);
            setResultat();
        }


        private String Nettoyage(String txt)
        {
            string result = Regex.Replace(txt, @"\r\n?|\n", " ");
            return result;
        }


        private String DecoupagePhrase(String txt)
        {
            List<String> phrases = new List<String>(txt.Split('.'));
            String resultat = "";

            foreach (String phrase in phrases)
            {
                resultat += phrase + "." + Environment.NewLine;
            }
            return resultat;
        }


        private List<String> DecoupageMot(String txt)
        {
            List<String> resultat = new List<String>(txt.Split(' '));
            return resultat;
        }


        private List<String> DecoupageLettre(String txt)
        {
            List<String> resultat = new List<String>(Regex.Split(txt, String.Empty));
            return resultat;
        }


        private void Comparaison(List<String> mots1, List<String> mots2)
        {
            mots1.RemoveAll(Nothing);
            mots2.RemoveAll(Nothing);

            foreach (String mot1 in mots1)
            {
                foreach (String mot2 in mots2)
                {

                    if (mot2.ToLower() == mot1.ToLower())
                    {
                        this.present += mot2 + " ";
                        mots2.Remove(mot2);
                        break;
                    }
                    else if (mot2.Contains(":"))
                    {
                        if (mot2.ToLower() == mot1.ToLower() + ":")
                        {
                            this.present += mot2 + " ";
                            mots2.Remove(mot2);
                            break;
                        }
                    }
                    else if (mot1.Contains(":"))
                    {
                        if (mot2.ToLower() + ":" == mot1.ToLower())
                        {
                            this.present += mot2 + " : ";
                            mots2.Remove(mot2);
                            break;
                        }
                    }

                    /*
                    if (Regex.IsMatch(mot2, Regex.Escape(":"), RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace) == true ||
                        mot2.Contains(":") != true)
                    {
                        this.present += mot2 + " ";
                        mots2.Remove(mot2);
                        break;
                    }
                    */
                }
            }
            this.absent = String.Join(" ", mots2.ToArray());
        }


        private static bool Nothing (String s)
        {
            if(s == String.Empty)
            {
                return true;
            }
            else { return false; }
        }


        public String getResultat()
        {
            return this.resultat;
        }


        public String getPresent()
        {
            return this.present;
        }


        public String getAbsent()
        {
            return this.absent;
        }


        private void setReference(String str)
        {
            this.texteReference = str;
        }


        private void setProd(String str)
        {
            this.texteProduit = str;
        }


        private void setResultat()
        {
            this.resultat = " ##### PRESENT ##### " + Environment.NewLine + this.present + Environment.NewLine +
                            " ##### ABSENT  ##### " + Environment.NewLine + this.absent;
        }
    }
}