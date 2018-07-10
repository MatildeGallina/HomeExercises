using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReverseExercises
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
        }
    }

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(DirectText))
                {
                    ReverseText = ReverseString(DirectText);
                }

                else if (e.PropertyName == nameof(ReverseText))
                {
                    DirectText = ReverseString(ReverseText);
                }
            };
        }

        List<string> text = new List<string>();

        private string ReverseString(string directText)
        {
            text.Add(directText);
            text.Reverse();

            string reversedText = "";

            foreach(string s in text)
            {
                reversedText += s;
            }

            return reversedText;
        }

        public string DirectText
        {
            get { return _DirectText; }
            set
            {
                if (_DirectText != value)
                {
                    _DirectText = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(DirectText)));
                }
            }
        }
        private string _DirectText;

        public string ReverseText
        {
            get { return _ReverseText; }
            set
            {
                if (_ReverseText != value)
                {
                    _ReverseText = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(ReverseText)));
                }
            }
        }
        private string _ReverseText;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
