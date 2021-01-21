using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_pizza_poo_v2
{
    public class Personne
    {
        protected string nomFamille;
        protected string prenom;
        protected string adresse;

        public Personne(string nomFamille, string prenom, string adresse)
        {
            this.nomFamille = nomFamille;
            this.prenom = prenom;
            this.adresse = adresse;
        }
        public Personne() { }

        public string NomFamille
        {
            get { return this.nomFamille; }
        }
        public string Prenom
        {
            get { return this.prenom; }
        }
        public string Adresse
        {
            get { return this.adresse; }
        }

        public override string ToString()
        {
            return this.nomFamille + " " + this.prenom + " " + this.adresse;
        }
    }
}
