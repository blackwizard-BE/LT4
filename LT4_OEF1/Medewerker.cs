using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LT4_OEF1
{
    internal class Medewerker
    {
        private string Voornaam { get; set; }
        private string Familienaam { get; set; }
        private double Maandwedde { get; set; }
        private string Statuut { get; set; }
        private char Geslacht { get; set; }



        public Medewerker(string Voornaam, string Familienaam, double Maandwedde, string Statuut, char Geslacht)
        {
            this.Voornaam = Voornaam;
            this.Familienaam = Familienaam;
            this.Maandwedde = Maandwedde;
            this.Statuut = Statuut;
            this.Geslacht = Geslacht;
        }
        public string voornaam
        {
            get { return Voornaam; }
            set { Voornaam = value; }
        }
        public string familienaam
        {
            get { return Familienaam; }
            set { Familienaam = value; }
        }
        public double maandwedde
        {
            get { return Maandwedde; }
            set { Maandwedde = value; }
        }
        public string statuut
        {
            get { return Statuut; }
            set { Statuut = value; }
        }
        public char geslacht
        {
            get { return Geslacht; }
            set { Geslacht = value; }
        }
        public double opslag(double opslag)
        {
            Maandwedde += opslag;
            return Maandwedde;
        }
        public double minderslag(double opslag)
        {
            Maandwedde -= opslag;
            return Maandwedde;
        }
    }
}
