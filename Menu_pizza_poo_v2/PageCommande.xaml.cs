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
    /// Logique d'interaction pour PageCommande.xaml
    /// </summary>
    public partial class PageCommande : Page
    {
        private MainWindow mainWindow;
        private List<Client> clients;
        private Client client;
        public PageCommande(MainWindow main, List<Client> list)
        {
            InitializeComponent();
            this.mainWindow = main;
            this.clients = list;
            VoirCommandes.Content = "    Voir les\ncommandes\n    actives";
            VoirCommandesClient.Content = "    Voir les\ncommandes\n  d'un client";
            NumCommande.Content = "   Voir une\ncommande \navec son n°";
        }

        private void Commander_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.RenvoyerConnexion();
        }

        private void VoirCommandes_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.AfficherToutesLesCommandes();
        }

        private void VoirCommandesClient_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ConnexionCommandeClient();
        }

        private void NumCommande_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.RechCommande();
        }
    }
}
