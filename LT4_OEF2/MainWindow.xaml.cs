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

namespace LT4_OEF2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {List<int> zetellist = new List<int>();//maakt een list van ints aan
            
        public MainWindow()
        {
            InitializeComponent(); 
            //voegt alle maxen toe aan de list btw 1ste kan geen 1000 zijn wan dan zijn er 2 instances van 1000 en dan ook 2 resultaten
            zetellist.Add(999);
            zetellist.Add(1999);
            zetellist.Add(2999);
            zetellist.Add(3999);
            zetellist.Add(4999);
            zetellist.Add(6999);
            zetellist.Add(8999);
            zetellist.Add(11999);
            zetellist.Add(14999);
            zetellist.Add(19999);
            zetellist.Add(24999);
            zetellist.Add(29999);
            zetellist.Add(34999);
            zetellist.Add(39999);
            zetellist.Add(49999);
            zetellist.Add(59999);
            zetellist.Add(69999);
            zetellist.Add(79999);
            zetellist.Add(89999);
            zetellist.Add(99999);
            zetellist.Add(149999);
            zetellist.Add(199999);
            zetellist.Add(249999);
            zetellist.Add(299999);

        }

        private void btnBerekenen_Click(object sender, RoutedEventArgs e)//gebruikt een foreach om te kijken of het gegeven getal groter is dan de LUT dan stopt hij met optellen en op het einde berekent hij de zetels via dit getal dat berekend werd in de foreach.
        {
            int f = 0;
            foreach(int i in zetellist)
            {
                if(Convert.ToInt32(txbInwoners.Text)>= i)
                {
                    f++;
                }
                lblAantalZetels.Content = $"Aantal zetels: {(7 + (2 * f))}";
            }
        }
    }
}
