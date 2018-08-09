using System;
using Word = Microsoft.Office.Interop.Word;

namespace [nom du namespace]
{
    class DocxToText
    {
        Word.Application app;
        Word.Document doc;

        public DocxToText()
        {
            this.app = new Word.Application();
            this.doc = new Word.Document();
        }

        public String OpenReadQuit(object path)
        {
            this.doc = this.app.Documents.Open(path);
            string text = this.doc.Content.Text;
            this.app.Quit();

            return text;
        }
        
        /**
        public void OpenSaveQuit(object path, object txtPath)
        {
            this.doc = this.app.Documents.Open(path);
            string text = this.doc.Content.Text;
            this.app.Quit();

            File.WriteAllText(txtPath.ToString(), text);
        }
        */
    }
}
