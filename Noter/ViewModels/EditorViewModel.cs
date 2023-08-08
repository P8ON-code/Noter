using Noter.Models;
using System.Windows.Input;

namespace Noter.ViewModels
{
    public class EditorViewModel
    {
        public ICommand FormatCommand { get; }
        public ICommand WrapCommand { get; }
        public FormatModel Format { get; set; }
        public DocumentModel Document { get; set; }

        public EditorViewModel(DocumentModel document)
        {
            Document = document;
            Format = new FormatModel();
            FormatCommand = new RelayCommand(OpenStyleDialog);
            WrapCommand = new RelayCommand(ToggleWrap);
        }

        private void OpenStyleDialog()
        {
            var fontDialoge = new FontDialoge();
            fontDialoge.DataContext = Format;
            fontDialoge.ShowDialog();
        }

        private void ToggleWrap()
        {
            Format.TextWrapping = Format.TextWrapping == System.Windows.TextWrapping.Wrap
                ? System.Windows.TextWrapping.NoWrap
                : System.Windows.TextWrapping.Wrap;
        }
    }
}
