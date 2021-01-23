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

namespace Menu_pizza_poo_v2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Commande> commandes;
        private List<Client> clients;
        private List<Commis> commis;
        private List<Livreur> livreurs;
        public MainWindow()
        {
            InitializeComponent();
            //Affichage.Content = new AffichageMenu();
            this.commandes = new List<Commande> { };
            this.clients = Client.LectureFichier();
            this.commis = Commis.LectureFichier();
            this.livreurs = Livreur.LectureFichier();
            //VoirCommandes.Content = "Commandes\n   en cours";
        }
        public void GoBackToStartPageCommander(Commande com)
        {
            Affichage.Content = null;
            if (com.Prix > 0)
            {
                commandes.Add(com);
            }
            Random rdn = new Random();
            commis[rdn.Next(0, commis.Count)].Commandes.Add(com);
            bool tousLivreurs = false;
            int compt = 0;
            while (tousLivreurs == false)
            {
                if (compt == livreurs.Count) { tousLivreurs = true; }
                else
                {
                    if (livreurs[compt].Etat == "Sur place" || livreurs[compt].Etat == "surplace")
                    {
                        livreurs[compt].Commandedulivreur = com;
                        livreurs[compt].Etat = "En livraison";
                        livreurs[compt].CommandeGerer.Add(com);
                        tousLivreurs = true;
                    }
                    else
                    {
                        compt++;
                    }
                }
            }
        }
        public void GoBackToStartPageInscription(Client client)
        {
            this.clients.Add(client);
            Affichage.Content = null;
        }
        public void GoBackToStartPageInscriptionLivreur(Livreur livreur)
        {
            Affichage.Content = null;
            this.livreurs.Add(livreur);
        }
        public void GoBackToStartPageInscriptionCommis(Commis commis)
        {
            this.commis.Add(commis);
            Affichage.Content = null;
        }
        public void RafraichirCommandes(List<Commande> com, List<Livreur> livreurs)
        {
            Affichage.Content = null;
            this.livreurs = livreurs;
            this.commandes = com;
            Affichage.Content = new PageResumeCommandes(com, this, livreurs);
        }

        private void VoirCommandes_Click(object sender, RoutedEventArgs e)
        {
            Affichage.Content = new PageResumeCommandes(this.commandes, this, this.livreurs);
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            Affichage.Content = new PageCommande(this, clients);
        }
        public void RenvoyerConnexion()
        {
            Affichage.Content = new PageConnexionClient(clients, this);
        }
        public void PasserConnexionACommande(List<Client> list, Client client)
        {
            this.clients = list;
            Affichage.Content = new Page1(this, client, this.livreurs);
        }
        public void AfficherToutesLesCommandes()
        {
            Affichage.Content = new PageResumeCommandes(this.commandes, this, this.livreurs);
        }
        public void AfficherCommandeClient(List<Commande> list)
        {
            Affichage.Content = new PageResumeCommandes(list, this, this.livreurs);
        }
        public void ConnexionCommandeClient()
        {
            Affichage.Content = new PageConnexionCommandesClient(this, this.clients, this.commandes);
        }

        private void Effectifs_Click(object sender, RoutedEventArgs e)
        {
            Affichage.Content = new PageEffectif(this);
        }
        public void EffectifAClient()
        {
            Affichage.Content = new PageEffectifClient(this, this.clients);
        }
        public void EffectifAEmployé()
        {
            Affichage.Content = new PageEffectifEmployés(this);
        }
        public void ClientAAffichage(List<Client> list)
        {
            Affichage.Content = new PageAffichageClient(this, list);
        }
        public void EffectifACommis()
        {
            Affichage.Content = new AffichageEmployes(this, this.commis, new List<Livreur> { });
        }
        public void EffectifALivreur()
        {
            Affichage.Content = new AffichageEmployes(this, new List<Commis> { }, this.livreurs);
        }
        public void RechCommande()
        {
            Affichage.Content = new PageRechCommande(this, this.commandes);
        }
        public void AfficherCommande(Commande commande)
        {
            Affichage.Content = new PageResumeCommandes(new List<Commande> { commande }, this, this.livreurs);
        }
        public void Inscription()
        {
            Affichage.Content = new PageInscription(this.clients, this, new List<Commis> { }, new List<Livreur> { });
        }
        public void InscriptionCommis()
        {
            Affichage.Content = new PageInscription(new List<Client> { }, this, this.commis, new List<Livreur> { });
        }
        public void InscriptionLivreur()
        {
            Affichage.Content = new PageInscription(new List<Client> { }, this, new List<Commis> { }, this.livreurs);
        }
    }
}
