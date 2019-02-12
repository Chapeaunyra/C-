using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EMFI_Comparaison
{
    class Comparer
    {
        private String texteReference = "";
        private String texteProduit = "";
        private String present = "";
        private String absent = "";
        private String modified = "";
        private String resultat = "";

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

        public Comparer(String str1, String str2, String rtf)
        {
            this.present = rtf;
            this.absent = rtf;
            this.modified = rtf;
            this.resultat = rtf;

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


        public List<String> DecoupageMot(String txt)
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
            int memory = 0;
            mots1.RemoveAll(Nothing);
            mots2.RemoveAll(Nothing);

            foreach (String mot2 in mots2)
            {
                foreach (String mot1 in mots1)
                {
                    if (mot2.ToLower() == mot1.ToLower())
                    {
                        this.present += @"\cf1 " + mot2 + " ";
                        this.resultat += @"\cf1 " + mot2 + " ";
                        memory = 0;
                        break;
                    }
                    else if (mot2.Contains(":") && mot2.ToLower() == mot1.ToLower() + ":")
                    {
                        this.present += @"\cf1 " + mot2 + " ";
                        this.resultat += @"\cf1 " + mot2 + " ";
                        memory = 0;
                        break;
                    }
                    else if (mot1.Contains(":") && mot2.ToLower() + ":" == mot1.ToLower())
                    {
                        this.present += @"\cf1 " + mot2 + " ";
                        this.resultat += @"\cf1 " + mot2 + " ";
                        memory = 0;
                        break;
                    }
                    else if (mot2 == ":" || mot2 == "'" || mot2 == "," || mot2 == ";" || mot2 == "-" || mot2 == "!")
                    {
                        this.present += @"\cf1 " + mot2 + " ";
                        this.resultat += @"\cf1 " + mot2 + " ";
                        memory = 0;
                        break;
                    }
                    else if (Regex.IsMatch(mot2, @"\b"+mot1 +@"\b", RegexOptions.IgnorePatternWhitespace) == true)
                    {
                        this.modified += @"\cf3 " + mot2 + " ";
                        this.present += @"\cf3 " + mot2 + " ";
                        this.resultat += @"\cf3 " + mot2 + " ";
                        memory = 0;
                        break;
                    }
                    else
                    {
                        memory++;
                    }
                }

                if(memory > 0)
                {
                    this.absent += @"\cf2 " + mot2 + " ";
                    this.resultat += @"\cf2 " + mot2 + " ";
                    memory = 0;
                }
            }
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


        public String getProduit()
        {
            return this.texteProduit;
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