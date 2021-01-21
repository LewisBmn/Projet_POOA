using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_pizza_poo_v2
{
    public class Commande
    {
        static int numerodecommande = 0;
        Pizza[] pizzas;
        int prix;
        string etatcommande;
        int numcommande;
        int numTelAssocié;

        public Commande(Pizza[] pizzas, int prix)
        {
            this.pizzas = pizzas;
            this.prix = prix;
            Commande.numerodecommande++;
            this.etatcommande = "En préparation";
            this.numcommande = Commande.numerodecommande;
        }
        public Commande(Pizza[] pizzas, int prix, int numTelAssocié)
        {
            this.pizzas = pizzas;
            this.prix = prix;
            Commande.numerodecommande++;
            this.etatcommande = "En préparation";
            this.numcommande = Commande.numerodecommande;
            this.numTelAssocié = numTelAssocié;
        }
        public int NumeroDeCommande
        {
            get { return this.numcommande; }
        }
        public Pizza[] Pizzas
        {
            get { return this.pizzas; }
            set { this.pizzas = value; }
        }
        public int Prix
        {
            get { return this.prix; }
            set { this.prix = value; }
        }
        public string EtatCommande
        {
            get { return this.etatcommande; }
            set { this.etatcommande = value; }
        }
        public int NumTelAssocié
        {
            get { return this.numTelAssocié; }
        }

        public override string ToString()
        {
            string str = "";

            int compteurFrom = 0;
            int compteurChor = 0;
            int compteurVege = 0;

            Pizza pizzaFrom = new Pizza();
            Pizza pizzaChor = new Pizza();
            Pizza pizzaVege = new Pizza();

            foreach (Pizza piz in this.pizzas)
            {
                if (piz.Type == "4 fromages") { compteurFrom++; pizzaFrom = piz; }
                if (piz.Type == "chorizo") { compteurChor++; pizzaChor = piz; }
                if (piz.Type == "végétarienne") { compteurVege++; pizzaVege = piz; }
            }
            if (compteurFrom > 0) { str += "\n" + compteurFrom + " * " + pizzaFrom.ToString(); }
            if (compteurChor > 0) { str += "\n" + compteurChor + " * " + pizzaChor.ToString(); }
            if (compteurVege > 0) { str += "\n" + compteurVege + " * " + pizzaVege.ToString(); }
            return str;
        }
    }
}
