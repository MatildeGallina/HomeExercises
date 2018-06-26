using System;
using System.Collections.Generic;
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

namespace ListBox_Trials
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Riserva> list = new List<Riserva>();

            list.Add(new Riserva() { Type = "Gasolio", Percentage = 80});
            list.Add(new Riserva() { Type = "Liquido refrigerante", Percentage = 20 });
            list.Add(new Riserva() { Type = "Olio", Percentage = 50 });

            ListRiserve.ItemsSource = list;
        }

        private void Pieno_Click(object sender, RoutedEventArgs e, List<Riserva> list)
        {
            for(int i = 0; i < list.Count; i++)
                if (list[i].Percentage < 100)
                    list[i].Percentage = 100;

            ListRiserve.ItemsSource = list;
        }

        private void E20_Click(object sender, RoutedEventArgs e)
        {
            foreach (Riserva r in ListRiserve.SelectedItems)
                if (r.Percentage < 100)
                    r.Percentage += 10;
        }

        private void E10_Click(object sender, RoutedEventArgs e)
        {
            foreach (Riserva r in ListRiserve.SelectedItems)
                if (r.Percentage < 100)
                    r.Percentage = 20;
        }
    }

    public class Riserva
    {
        public string Type { get; set; }
        public int Percentage { get; set; }
    }
}
