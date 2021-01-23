using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_pizza_poo_v2
{
    public class Boissons
    {
        private string nom;
        private int volume;
        private int prix;

        public Boissons() { }
        public Boissons(string nom, int volume, int prix)
        {
            this.nom = nom;
            this.volume = volume;
            this.prix = prix;
        }
        public string Nom
        {
            get
            {
                return this.nom;
            }
            set
            {
                this.nom = value;
            }
        }

        public int Volume
        {
            get
            {
                return this.volume;
            }
            set
            {
                this.volume = value;
            }
        }

        public int Prix
        {
            get
            {
                return this.prix;
            }
            set
            {
                this.prix = value;
            }
        }

        public override string ToString()
        {
            return this.nom + " " + this.volume + "cl";
        }
    }
}
