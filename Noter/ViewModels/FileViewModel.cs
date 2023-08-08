using Microsoft.Win32;
using Noter.Models;
using System.IO;
using System.Windows.Input;

namespace Noter.ViewModels
{
    public class FileViewModel
    {
        public DocumentModel Document { get; private set; }

        //Toolbar Commands
        public ICommand NewCommad { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand OpenCommand { get; }


        public FileViewModel(DocumentModel document)
        {
            Document = document;

            NewCommad = new RelayCommand(NewFile);
            SaveCommand = new RelayCommand(Savefile);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            OpenCommand = new RelayCommand(OpenFile);
        }

        public void NewFile()
        {
            Document.Filename = string.Empty;
            Document.Filepath = string.Empty;
            Document.Text = string.Empty;
        }

        private void Savefile()
        {
            File.WriteAllText(Document.Filepath, Document.Text);
        }

        private void SaveFileAs()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                DockFile(saveFileDialog);
                Savefile();
            }
        }

        private void OpenFile()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                DockFile(openFileDialog);
                Document.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        /*Tak jak w c++ w generycznych funkjach możesz wyodrębnić inne zachowanie zależnie od określonych typów, tak tutaj do tego służy "where"
          */
        private void DockFile<T>(T dialog) where T : FileDialog
        {
            Document.Filepath = dialog.FileName;
            Document.Filename = dialog.SafeFileName;
        }
    }
}
