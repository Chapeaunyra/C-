using System;
using Word = Microsoft.Office.Interop.Word;

namespace EMFI_Comparaison
{
    class ConvertionDocx
    {
        Word.Application app;
        Word.Document doc;

        public ConvertionDocx()
        {
            this.app = new Word.Application();
            this.doc = new Word.Document();
        }

        public String OuvrirLireQuitter(object path)
        {
            this.doc = this.app.Documents.Open(path);
            string text = this.doc.Content.Text;
            this.app.Quit();

            return text;
        }

    }
}
