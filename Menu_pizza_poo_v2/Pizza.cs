using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_pizza_poo_v2
{
    public class Pizza
    {
        private string taille;
        private string type;  //3 types dispo : 4 fromages, chorizo ou végétarienne
        private int prix;

        public Pizza() { }
        public Pizza(string taille, string type, int prix)
        {
            this.taille = taille;
            this.type = type;
            this.prix = prix;
        }
        public string Taille
        {
            get { return this.taille; }
        }
        public string Type
        {
            get { return this.type; }
        }
        public int Prix
        {
            get { return this.prix; }
        }

        public override string ToString()
        {
            return "pizza " + this.type + " format " + this.taille;
        }

    }
}
