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
        List<Boissons> boissons;
        int prix;
        string etatcommande;
        int numcommande;
        int numTelAssocié;

        public Commande() { }
        public Commande(Pizza[] pizzas, int prix, List<Boissons> bois)
        {
            this.pizzas = pizzas;
            this.boissons = bois;
            this.prix = prix;
            Commande.numerodecommande++;
            this.etatcommande = "En préparation";
            this.numcommande = Commande.numerodecommande;
        }
        public Commande(Pizza[] pizzas, int prix, int numTelAssocié, List<Boissons> bois)
        {
            this.pizzas = pizzas;
            this.boissons = bois;
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
        public List<Boissons> Boisson
        {
            get { return this.boissons; }
        }

        public override string ToString()
        {
            string str = "";

            int compteurFrom = 0;
            int compteurChor = 0;
            int compteurVege = 0;

            int compteurCoca = 0;
            int compteurJusOrange = 0;
            int compteurIceTea = 0;

            Pizza pizzaFrom = new Pizza();
            Pizza pizzaChor = new Pizza();
            Pizza pizzaVege = new Pizza();

            Boissons coca = new Boissons();
            Boissons jusOrange = new Boissons();
            Boissons iceTea = new Boissons();

            foreach (Pizza piz in this.pizzas)
            {
                if (piz.Type == "4 fromages") { compteurFrom++; pizzaFrom = piz; }
                if (piz.Type == "chorizo") { compteurChor++; pizzaChor = piz; }
                if (piz.Type == "végétarienne") { compteurVege++; pizzaVege = piz; }
            }

            foreach (Boissons bois in this.boissons)
            {
                if (bois.Nom == "Coca") { compteurCoca++; coca = bois; }
                if (bois.Nom == "Jus d'orange") { compteurJusOrange++; jusOrange = bois; }
                if (bois.Nom == "Ice Tea") { compteurIceTea++; iceTea = bois; }
            }

            if (compteurFrom > 0) { str += "\n" + compteurFrom + " * " + pizzaFrom.ToString(); }
            if (compteurChor > 0) { str += "\n" + compteurChor + " * " + pizzaChor.ToString(); }
            if (compteurVege > 0) { str += "\n" + compteurVege + " * " + pizzaVege.ToString(); }

            if (compteurCoca > 0) { str += "\n" + compteurCoca + " * " + coca.ToString(); }
            if (compteurJusOrange > 0) { str += "\n" + compteurJusOrange + " * " + jusOrange.ToString(); }
            if (compteurIceTea > 0) { str += "\n" + compteurIceTea + " * " + iceTea.ToString(); }

            return str;
        }
        public static bool operator ==(Commande a, Commande b)
        {
            if(a==null && b != null) { return false; }
            if(a!=null && b == null) { return false; }
            if(a==null && b == null) { return true; }
            if(a.NumeroDeCommande == b.NumeroDeCommande && a.Prix == b.Prix) { return true; }
            return false;
        }
        public static bool operator !=(Commande a, Commande b)
        {
            if (a == null && b != null) { return true; }
            if (a != null && b == null) { return true; }
            if (a == null && b == null) { return false; }
            if (a.NumeroDeCommande == b.NumeroDeCommande && a.Prix == b.Prix) { return false; }
            return true;
        }
    }
}
