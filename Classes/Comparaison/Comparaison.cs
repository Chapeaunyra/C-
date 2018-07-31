using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace [nom projet]
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



        public String[] ConvertToWords(String text)
        {
            String[] mots = text.Split(' ');

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

            String tmp = "";

            tmp = ConvertToText(lignes);

            for (int i = 0; i < lignes.Length; i++)
            {

            }

            mots = tmp.Split(' ');

            return mots;
        }



        public String[][] ConvertToLinesAndWords(String text)
        {
            String[] lignes = ConvertToLines(text);
            String[][] mots = new String[lignes.Length][];

            for (int i = 0; i < lignes.Length - 1; i++)
            {
                mots[i] = new string[lignes[i].Length];

                for (int j = 0; j < lignes[i].Length - 1; j++)
                {
                    mots[i][j] = ConvertToWords_txt(lignes[i]);
                }
            }
            return mots;
        }



        public String[] ConvertToLines(String text)
        {
            String[] phrases = text.Split('.');
            for (int i = 0; i < phrases.Length; i++)
            {
                phrases[i] += "\n";
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
            String[][] reference = ConvertToLinesAndWords(this.reference);
            String[][] produit = ConvertToLinesAndWords(this.produit);

            String equal = "";
            String added = "";
            String moved = "";
            String result = "";

            int compteur = 0;
            int compt = 0;

            for (int ligneProd = 0; ligneProd < produit.Length - 1; ligneProd++)
            {

                for (int ligneRef = 0; ligneRef < reference.Length - 1; ligneRef++)
                {

                    // MOTS DE LA LIGNE PRODUIT
                    for (int motsProd = 0; motsProd < produit[ligneProd].Length - 1; motsProd++)
                    {

                        // MOTS DE LA LIGNE REFERENCE
                        for (int motsRef = 0; motsRef < reference[ligneRef].Length - 1; motsRef++)
                        {
                            if (produit[ligneProd][motsProd] == reference[ligneRef][motsRef])
                            {
                                equal += produit[ligneProd][motsProd] + Environment.NewLine;
                                compteur++;
                                break;
                            }

                        }
                        if (compteur > 0)
                        {
                            moved += produit[ligneProd][motsProd] + Environment.NewLine;
                            compteur = 0;
                            break;
                        }
                        else
                        {
                            added += produit[ligneProd][motsProd] + Environment.NewLine;
                            break;
                        }

                    }
                    break;
                }
            }
            result += "EQUAL : " + Environment.NewLine + equal + Environment.NewLine +
                      "ADDED : " + Environment.NewLine + added + Environment.NewLine +
                      "MOVED : " + Environment.NewLine + moved + Environment.NewLine;

            equal = "";
            added = "";
            moved = "";

            result += Environment.NewLine + " -------------------------" + Environment.NewLine;

            return result;
        }
    }
}
