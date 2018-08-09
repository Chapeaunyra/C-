using System;
using System.Collections.Generic;

namespace EMFi
{
    class Comparaison
    {

        String reference;
        String produit;

        public Comparaison(String txt1, String txt2)
        {
            this.reference = txt1;
            this.produit = txt2;

        }

        public String ConvertToText(String[] text)
        {
            String result = "";
            for (int i = 0; i < text.Length; i++)
            {
                result += text[i] + " ";
            }
            return result;
        }

        public String[] CutInLinesAndWords(String text)
        {
            return ConvertToWords(ConvertToLines(text));
        }

        public override String ToString()
        {
            return " Text ref : " + Environment.NewLine + this.reference + Environment.NewLine + 
                   " Text produit : " + Environment.NewLine + this.produit;
        }

        public String[] ConvertToWords(String text)
        {
            String[] mots = text.Split(' ');
            
            for(int i = 0; i < mots.Length; i++)
            {
                if (mots[i].Substring(mots[i].Length - 1) == ".")
                {
                    mots[i] = mots[i].Substring(0, mots[i].Length -1); 
                }
            }
            
            return mots;
        }

        private String ConvertToWords_txt(String text)
        {
            String[] mots = text.Split(' ');
            String result = "";
            foreach (var mot in mots)
            {
                result += mot + " ";
            }

            return result;
        }

        public String[] ConvertToWords(String[] text)
        {
            String[] lignes = text;
            String[] mots = new String[lignes.Length];

            String tmp = ConvertToText(lignes);
            mots = tmp.Split(' ');

            Cleaning(mots);

            return mots;
        }

        public String Test(String[][] mots)
        {
            String result = "";

            for(int i = 0; i < mots.Length; i++)
            {
                result += " Ligne : " + mots[i] + Environment.NewLine + "       Contient les mots: ";
                mots[i] = new string[300];
                for (int j = 0; j < mots[i].Length; j++)
                {
                    result += Environment.NewLine + "       " + mots[i];
                }
            }

            return result;
        }

        public String[][] ConvertToLinesAndWords(String text)
        {
            String[] lignes = ConvertToLines(text);
            String[][] mots = new String[lignes.Length][];

            for (int i = 0; i < lignes.Length; i++)
            {
                mots[i] = new String[lignes[i].Split(' ').Length];

                for (int j = 0; j < lignes[i].Split(' ').Length; j++)
                {
                    mots[i] = lignes[i].Split(' ');
                }
            }
            return mots;
        }

        public String[] ConvertToLines(String text)
        {
            String[] phrases = text.Split('.');

            for (int i = 0; i < phrases.Length; i++)
            {
                phrases[i] = phrases[i] + "." + Environment.NewLine;
            }

            return phrases;
        }

        public String[] ConvertToLines(String[] text)
        {
            List<string> listeLignes = new List<string>(text);
            String[] lignes;

            lignes = listeLignes.ToArray();

            return lignes;
        }



        public String[] ConvertToParagraphe(String text)
        {
            String[] paragraphes = text.Split('\n');

            return paragraphes;
        }



        public String ToString_WordToWord()
        {
            String[] motProd = ConvertToWords(this.produit);
            String[] motRef = ConvertToWords(this.reference);

            String result = "";

            for (int i = 0; i < motProd.Length; i++)
            {
                result += motProd[i] + Environment.NewLine;
            }

            result += Environment.NewLine + "\\\\\\\\\\\\\\\\\\\\\\\\\\\\       ///////////////////////////" + Environment.NewLine;

            for (int i = 0; i < motRef.Length; i++)
            {
                result += motRef[i] + Environment.NewLine;
            }

            return result;
        }



        public String Compare_WordToWord()
        {
            String[] motProd = ConvertToWords(this.produit);
            String[] motRef = ConvertToWords(this.reference);

            String equal = "";
            String added = "";
            String moved = "";
            String result = "";

            int compteur = 0;

            for (int i = 0; i < motProd.Length; i++)
            {
                result = "           MOT " + i + "          " + Environment.NewLine;
                for (int j = 0; j < motRef.Length; j++)
                {
                    // EQUAL
                    if (motProd[i] == motRef[j])
                    {
                        equal += motProd[i] + Environment.NewLine;
                        break;
                    }
                    else
                    {
                        foreach (var mots in motRef)
                        {
                            if (motProd[i] == mots)
                            {
                                compteur++;
                                break;
                            }
                        }

                        if (compteur > 0)
                        {
                            moved += motProd[i] + Environment.NewLine;
                            compteur = 0;
                            break;
                        }
                        else
                        {
                            added += motProd[i] + Environment.NewLine;
                            break;
                        }
                    }
                }
            }
            result = " EQUAL : " + Environment.NewLine + equal + Environment.NewLine + Environment.NewLine +
                     " ADDED : " + Environment.NewLine + added + Environment.NewLine + Environment.NewLine +
                     " MOVED : " + Environment.NewLine + moved + Environment.NewLine + Environment.NewLine;
            return result;
        }

        public String Compare_WordToWord(String[] mots1, String[] mots2)
        {
            String[] motProd = mots1;
            String[] motRef = mots2;

            String equal = "";
            String added = "";
            String moved = "";
            String result = "";

            int compteur = 0;

            for (int i = 0; i < motProd.Length; i++)
            {
                result = "           MOT " + i + "          " + Environment.NewLine;
                for (int j = 0; j < motRef.Length; j++)
                {
                    // EQUAL
                    if (motProd[i] == motRef[j])
                    {
                        equal += motProd[i] + Environment.NewLine;
                        break;
                    }
                    else
                    {
                        foreach (var mots in motRef)
                        {
                            if (motProd[i] == mots)
                            {
                                compteur++;
                                break;
                            }
                        }

                        if (compteur > 0)
                        {
                            moved += motProd[i] + Environment.NewLine;
                            compteur = 0;
                            break;
                        }
                        else
                        {
                            added += motProd[i] + Environment.NewLine;
                            break;
                        }
                    }
                }
            }
            result = " EQUAL : " + Environment.NewLine + equal + Environment.NewLine + Environment.NewLine +
                     " ADDED : " + Environment.NewLine + added + Environment.NewLine + Environment.NewLine +
                     " MOVED : " + Environment.NewLine + moved + Environment.NewLine + Environment.NewLine;
            return result;
        }

        public String Compare_SentenceToSentence()
        {
            String[] phraseRef = ConvertToLines(this.reference);
            String[] phraseProd = ConvertToLines(this.produit);

            String equal = "";
            String added = "";
            String moved = "";
            String result = "";

            int compteur = 0;

            for (int i = 0; i < phraseProd.Length; i++)
            {
                result = "           MOT " + i + "          " + Environment.NewLine;
                for (int j = 0; j < phraseRef.Length; j++)
                {
                    // EQUAL
                    if (phraseProd[i] == phraseRef[j])
                    {
                        equal += phraseProd[i] + Environment.NewLine;
                        break;
                    }
                    else
                    {
                        foreach (var mots in phraseRef)
                        {
                            if (phraseProd[i] == mots)
                            {
                                compteur++;
                                break;
                            }
                        }

                        if (compteur > 0)
                        {
                            moved += phraseProd[i] + Environment.NewLine;
                            compteur = 0;
                            break;
                        }
                        else
                        {
                            added += phraseProd[i] + Environment.NewLine;
                            break;
                        }
                    }
                }
            }
            result = " EQUAL : " + Environment.NewLine + equal + Environment.NewLine + Environment.NewLine +
                     " ADDED : " + Environment.NewLine + added + Environment.NewLine + Environment.NewLine +
                     " MOVED : " + Environment.NewLine + moved + Environment.NewLine + Environment.NewLine;

            return result;
        }

        // A CONCEPTUALISER
        public String Compare_Mixed()
        {
            String[] reference = ConvertToWords(ConvertToLines(this.reference));
            String[][] produit = ConvertToLinesAndWords(this.produit);

            String equal = "";
            String added = "";
            // String moved = "";
            String result = "";

            String compteur = "";
            int compt = 0;

            for (int ligneProd = 0; ligneProd < produit.Length; ligneProd++)
            {
                // compteur += Environment.NewLine + " Ligne " + (ligneProd + 1) + Environment.NewLine;
                // MOTS DE LA LIGNE PRODUIT
                for (int motsProd = 0; motsProd < produit[ligneProd].Length; motsProd++)
                {

                    // MOTS DE LA LIGNE REFERENCE
                    for (int motsRef = 0; motsRef < reference.Length; motsRef++)
                    {
                        // EXISTE DANS LES DEUX, à compléter par
                        // &motsProd == motsRef pour plus de précision.
                        if (produit[ligneProd][motsProd] == reference[motsRef])
                        {
                            equal += produit[ligneProd][motsProd] + " ";
                            compt++;
                            break;
                        }
                        // Vérifie qu'on a testé tous les mots ref et que rien ne correspond
                        else if (motsRef == reference.Length - 1 & compt < 1)
                        {
                            added += produit[ligneProd][motsProd] + " ";
                        }
                    }
                    compt = 0;
                }
                //equal = "";
                //added = "";
            }
            result += " ------------------------------------------------------------------------ "
                    + Environment.NewLine + Environment.NewLine + "EQUAL : " + Environment.NewLine + Environment.NewLine 
                    + equal + Environment.NewLine + Environment.NewLine +
                    " ------------------------------------------------------------------------ " 
                    + Environment.NewLine + Environment.NewLine + "ADDED : " + Environment.NewLine + Environment.NewLine 
                    + added + Environment.NewLine + Environment.NewLine +
                    " ------------------------------------------------------------------------ ";
            // "MOVED : " + Environment.NewLine + moved + Environment.NewLine +
            // Environment.NewLine + " -------------------------" + Environment.NewLine;

            return result;
        }

        public String[] Compare_Mixed2()
        {
        {

            for(int i = 0; i < text.Length; i++)
            {
                // mot.Replace("\r", "");
                // mot.Replace("\n", "");
                text[i] = text[i].Replace("\r\n\r\r\r.\r\n", ".\r\n");
                text[i] = text[i].Replace("\r\r\r/\r\r", "/\r\n");
                text[i] = text[i].Replace("\r\n.\r\n", ".\r\n");
                text[i] = text[i].Replace("\r\n\r\r\r", "\r\n");
                text[i] = text[i].Replace("\r\n\r", "\r\n");
                text[i] = text[i].Replace("\r\r", "\r\n");
            }

            return text;
        }

    }
}
