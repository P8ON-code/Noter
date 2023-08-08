using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noter.Models
{
    public class DocumentModel : ObservableObject
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set { OnPropertyChanged(ref _text, value); }
        }
        private string _filepath;
        public string Filepath
        {
            get { return _filepath; }
            set { OnPropertyChanged(ref _filepath, value); }
        }
        private string _filename;
        public string Filename
        {
            get { return _filename; }
            set { OnPropertyChanged(ref _filename, value); }
        }

        public bool isEmpty
        {
            get
            {
                if (string.IsNullOrEmpty(Filename) || string.IsNullOrEmpty(Filepath))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
