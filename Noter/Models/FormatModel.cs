using System.Windows;
using System.Windows.Media;

namespace Noter.Models
{
    public class FormatModel : ObservableObject
    {
        private FontStyle _style;
        public FontStyle Style { get { return _style; } set { OnPropertyChanged(ref _style, value); } }

        private FontWeight _weight;
        public FontWeight Weight { get { return _weight; } set { OnPropertyChanged(ref _weight, value); } }

        private FontFamily _family;
        public FontFamily FontFamily { get { return _family; } set { OnPropertyChanged(ref _family, value); } }

        private TextWrapping _textWrapping;
        public TextWrapping TextWrapping
        {
            get { return _textWrapping; }
            set
            {
                OnPropertyChanged(ref _textWrapping, value);
                isWrapped = value == TextWrapping.Wrap ? true : false;
            }
        }

        private bool _isWrapped;
        public bool isWrapped
        {
            get { return _isWrapped; }
            set { OnPropertyChanged(ref _isWrapped, value); }
        }

        private double _size;
        public double Size
        {
            get { return _size; }
            set { OnPropertyChanged(ref _size, value); }
        }
    }
}
