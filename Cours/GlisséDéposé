// Pour se faire, il faut d'abords allez dans Designer.cs, choisir l'élément où l'on doit glissé-déposé le fichier 
// et définir sa propriété AllowDrop sur True.

// Ensuite, cliquez sur l'éclair (toujours dans l'onglet propriété)
// Double cliquez sur DragEnter, la ligne suivante permet d'autoriser tout les types de fichiers dans une textBox.

private void text_Box1_DragEnter(object sender, DragEventArgs e)
{
      e.Effect = DragDropEffects.All;
}
        
// Retournez dans l'onglet proprété et double cliquez sur DragDrop, et rentrer le code de l'action souhaité.
// Ici ça sera d'afficher le contenu du fichier .docx dans la textBox.

private void text_Box1_DragDrop(object sender, DragEventArgs e)
        {
            text_Box1.Text = "";
            DocxToText myDoc = new DocxToText();
            String[] files = ((String[])e.Data.GetData(DataFormats.FileDrop, false));
            String[] ligneRef;
            String refText = "";
            foreach (var file in files)
            {
                refText = myDoc.OpenReadQuit(file);
            }

            ligneRef = refText.Split('.');
            foreach (string ligne in ligneRef)
            {
                text_Box1.Text += ligne + "." + Environment.NewLine;
            }
        }
