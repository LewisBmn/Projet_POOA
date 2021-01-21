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
        private Client client;
        public MainWindow()
        {
            InitializeComponent();
            //Affichage.Content = new AffichageMenu();
            this.commandes = new List<Commande> { };
            this.clients = new List<Client> { };
            //VoirCommandes.Content = "Commandes\n   en cours";
        }
        public void GoBackToStartPageCommander(Commande com)
        {
            Affichage.Content = null;
            if (com.Prix > 0)
            {
                commandes.Add(com);
            }
        }
        public void RafraichirCommandes(List<Commande> com)
        {
            Affichage.Content = null;
            Affichage.Content = new PageResumeCommandes(com, this);
        }

        private void VoirCommandes_Click(object sender, RoutedEventArgs e)
        {
            Affichage.Content = new PageResumeCommandes(this.commandes, this);
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
            Affichage.Content = new Page1(this, client);
        }
        public void AfficherToutesLesCommandes()
        {
            Affichage.Content = new PageResumeCommandes(this.commandes, this);
        }
        public void AfficherCommandeClient(List<Commande> list)
        {
            Affichage.Content = new PageResumeCommandes(list, this);
        }
        public void ConnexionCommandeClient()
        {
            Affichage.Content = new PageConnexionCommandesClient(this, this.clients, this.commandes);
        }

        private void Effectifs_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
