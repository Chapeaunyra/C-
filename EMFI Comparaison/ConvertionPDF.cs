using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;

namespace EMFI_Comparaison
{
    class ConvertionPDF
    {
        public string ExtraireText(string path)
        {
            PDDocument doc = null;
            try
            {
                doc = PDDocument.load(path);
                PDFTextStripper stripper = new PDFTextStripper();
                return stripper.getText(doc);
            }
            finally
            {
                if (doc != null)
                {
                    doc.close();
                }
            }
        }
    }
}
