﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Menu_pizza_poo_v2
{
    public class Commis : Personne, IEquatable<Commis>
    {
        private DateTime dateEmbauche;
        private string etat;
        private int numTel;
        private List<Commande> commandes;

        public Commis() { }

        public Commis(string nomFamille, string prenom, string adresse, int numTel, DateTime dateEmbauche) : base(nomFamille, prenom, adresse)
        {
            this.nomFamille = nomFamille;
            this.prenom = prenom;
            this.adresse = adresse;
            this.numTel = numTel;
            this.dateEmbauche = dateEmbauche;
            this.commandes = new List<Commande> { };
        }

        public Commis(string nom, string prenom, string adresse, int numerodetel, string etat, DateTime dateEmbauche) : base(nom, prenom, adresse)
        {
            this.numTel = numerodetel;
            this.etat = etat;
            this.dateEmbauche = dateEmbauche;
            this.commandes = new List<Commande> { };
        }

        static public List<Commis> LectureFichier()
        {
            string ligne;
            List<Commis> commis = new List<Commis> { };
            int compteur = 0;
            List<string> liste = new List<string> { };
            StreamReader line = new StreamReader(@"C:\Users\lewis\source\repos\Menu_pizza_poo_v2\Menu_pizza_poo_v2\bin\Debug\Commis.csv");
            while ((ligne = line.ReadLine()) != null)
            {
                String[] substrings = ligne.Split(';');
                foreach (var substring in substrings)
                {
                    liste.Add(substring);
                }
                compteur++;
            }
            line.Close();
            for (int i = 0; i < liste.Count; i++)
            {
                if (i % 6 == 0)
                {
                    if (liste[i + 4] == "surplace" || liste[i+4]=="Sur place")
                    {
                        commis.Add(new Commis(liste[i], liste[i + 1], liste[i + 2], Convert.ToInt32(liste[i + 3]), "Sur place", Convert.ToDateTime(liste[i + 5])));
                    }
                    else
                    {
                        commis.Add(new Commis(liste[i], liste[i + 1], liste[i + 2], Convert.ToInt32(liste[i + 3]), "En congés", Convert.ToDateTime(liste[i + 5])));
                    }
                }
            }
            return commis;
        }

        public static void AjoutCommisCSV(Commis commis)
        {
            using (var w = new StreamWriter((@"C:\Users\lewis\source\repos\Menu_pizza_poo_v2\Menu_pizza_poo_v2\bin\Debug\Commis.csv"), true))
            {
                string line = string.Format("{0};{1};{2};{3};{4};{5}", commis.NomFamille, commis.Prenom, commis.Adresse, commis.NumTel.ToString(), commis.Etat, commis.DateEmbauche.ToShortDateString());
                w.WriteLine(line);
            }
        }
        public DateTime DateEmbauche
        {
            get
            {
                return this.dateEmbauche;
            }
        }

        public string Etat
        {
            get
            {
                return this.etat;
            }
            set
            {
                this.etat = value;
            }
        }
        public int NumTel
        {
            get { return this.numTel; }
        }
        public List<Commande> Commandes
        {
            get { return this.commandes; }
            set { this.commandes = value; }
        }

        //public int RetourEncaissement(int numerodecommande, int numerodulivreur, List<Commande> commande)
        //{
        //    int result = 0;
        //    foreach (Commande element in commande)
        //    {
        //        if (element.NumerodeCommande == numerodecommande && element.Livreur.Numerodetelephone == numerodulivreur)
        //        {
        //            result += element.Prix(numerodecommande);
        //        }
        //    }
        //    return result;
        //}

        //public void EtatEffectif(List<Commis> commis, List<Livreur> livreur)
        //{
        //    foreach (Commis element in commis)
        //    {
        //        Console.WriteLine("L'état de ce commis : " + element.Prenom + " " + element.Nom + "est : " + element.Etat);
        //    }
        //    Console.WriteLine("Passons aux livreur :");
        //    foreach (Livreur element in livreur)
        //    {
        //        Console.WriteLine("L'état de ce livreur : " + element.Prenom + " " + element.Nom + "est : " + element.Etat);
        //    }
        //}

        public override string ToString()
        {
            return base.ToString() + " et son etat est : " + this.etat + ", et sa date d'embauche est : " + this.dateEmbauche.ToShortDateString();
        }
        public override bool Equals(object b)
        {
            return Equals(b);
        }
        public bool Equals(Commis b)
        {
            if ((this.Prenom == b.Prenom && this.NomFamille == b.NomFamille) || this.NumTel == b.NumTel) { return true; }
            return false;
        }
    }
}
