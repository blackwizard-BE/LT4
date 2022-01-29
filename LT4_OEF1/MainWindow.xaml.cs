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

namespace LT4_OEF1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Medewerker> medewerkerList = new List<Medewerker>();


        public MainWindow()
        {
            InitializeComponent();
            cmbGeslacht.Items.Add("m");//voegt geslacht toe aan de combobox
            cmbGeslacht.Items.Add("v");
            cmbGeslacht.Items.Add("x");
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (medewerkerList.Count == 25)//max 25 list items
                {
                    MessageBox.Show("Je hebt het maximum aantal werknemers bereikt.");
                }
                else
                {//voegt alles toe aan de list en cleart dan de ingevulde gegevens

                    medewerkerList.Add(new Medewerker(txbVoornaam.Text, txbFamilienaam.Text, Convert.ToDouble(txbMaandwedde.Text), txbStatuut.Text, Convert.ToChar(cmbGeslacht.SelectedItem)));
                    lsbLeden.Items.Add($"{txbVoornaam.Text}, {txbFamilienaam.Text}");
                    txbFamilienaam.Clear();
                    txbMaandwedde.Clear();
                    txbOpslag.Clear();
                    txbStatuut.Clear();
                    cmbGeslacht.SelectedIndex = -1;
                    txbVoornaam.Clear();
                }
            }
            catch (Exception ex)
            {
                bool isDouble = Double.TryParse(txbMaandwedde.Text, out double temp);
                if (isDouble) { MessageBox.Show("Check je ingevulde waarden en probeer opnieuw"); }
                else
                {
                    MessageBox.Show("Je hebt geen juiste waarde ingegeven als loon herzie deze info.");
                }

            }
        }


        private void lsbLeden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsbLeden.SelectedIndex != -1)//voegt de info toe aan de label
            {
                int index = lsbLeden.SelectedIndex;
                lblLidRes.Content = $"Voornaam: {medewerkerList[index].voornaam}\nFamilienaam: {medewerkerList[index].familienaam}\nMaandwedde: €{medewerkerList[index].maandwedde}\nStatuut: {medewerkerList[index].statuut}\nGeslacht: {medewerkerList[index].geslacht}";
            }
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)//geeft de opslag aan de geselecteerde persoon
        {
            if (lsbLeden.SelectedIndex != -1)
            {
                try
                {
                    int index = lsbLeden.SelectedIndex;
                    medewerkerList[index].opslag(Convert.ToDouble(txbOpslag.Text));
                    lblLidRes.Content = $"Voornaam: {medewerkerList[index].voornaam}\nFamilienaam: {medewerkerList[index].familienaam}\nMaandwedde: €{medewerkerList[index].maandwedde}\nStatuut: {medewerkerList[index].statuut}\nGeslacht: {medewerkerList[index].geslacht}";
                }
                catch
                {
                    MessageBox.Show("De ingevulde opslag is een ongeldige waarde.");
                }
            }
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)//neemt geld af .... ngl kinda not cool
        {
            if (lsbLeden.SelectedIndex != -1)
            {
                try
                {
                    int index = lsbLeden.SelectedIndex;
                    medewerkerList[index].minderslag(Convert.ToDouble(txbOpslag.Text));
                    lblLidRes.Content = $"Voornaam: {medewerkerList[index].voornaam}\nFamilienaam: {medewerkerList[index].familienaam}\nMaandwedde: €{medewerkerList[index].maandwedde}\nStatuut: {medewerkerList[index].statuut}\nGeslacht: {medewerkerList[index].geslacht}";
                }
                catch
                {
                    MessageBox.Show("De ingevulde opslag is een ongeldige waarde.");
                }

            }

        }

        private void btnPlusOneHalf_Click(object sender, RoutedEventArgs e)
        {
            foreach (var medewerker in medewerkerList)//geeft iedereen 1.5% extra yeey meer taxen
            {
                medewerker.opslag(medewerker.maandwedde * 0.015);
            }
            if (lsbLeden.SelectedIndex != -1)
            {
                int index = lsbLeden.SelectedIndex;
                lblLidRes.Content = $"Voornaam: {medewerkerList[index].voornaam}\nFamilienaam: {medewerkerList[index].familienaam}\nMaandwedde: €{medewerkerList[index].maandwedde}\nStatuut: {medewerkerList[index].statuut}\nGeslacht: {medewerkerList[index].geslacht}";
            }
        }

        private void btnZoeken_Click(object sender, RoutedEventArgs e)//zoekt de naam van de persoon en geeft de eerst gevonden naam in een messagebox
        {
            bool search = true;
            int i = 0;
            do
            {
                if (txbZoeken.Text == medewerkerList[i].voornaam)
                {
                    search = false;
                }
                else
                {
                    i++;
                }
            }
            while (search);
            MessageBox.Show($"Voornaam: {medewerkerList[i].voornaam}\nFamilienaam: {medewerkerList[i].familienaam}\nMaandwedde: €{medewerkerList[i].maandwedde}\nStatuut: {medewerkerList[i].statuut}\nGeslacht: {medewerkerList[i].geslacht}");
        }
    }
}
