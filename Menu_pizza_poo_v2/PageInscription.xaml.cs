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
    /// Logique d'interaction pour PageInscription.xaml
    /// </summary>
    public partial class PageInscription : Page
    {
        private List<Client> clients;
        private MainWindow main;
        private List<Commis> commis;
        private List<Livreur> livreurs;
        public PageInscription(List<Client> list, MainWindow mainWindow, List<Commis> listcom, List<Livreur> listliv)
        {
            InitializeComponent();
            this.clients = list;
            this.main = mainWindow;
            this.commis = listcom;
            this.livreurs = listliv;
            if (list == null || list.Count <= 0)
            {
                etat.Text = "Entrez ici votre état d'activité";
                etat.BorderBrush = Brushes.DarkGray;
                form.Foreground = Brushes.LightGray;
                if (listcom == null || listcom.Count <= 0)
                {
                    vehicule.Text = "Entrez ici votre véhicule";
                    vehicule.BorderBrush = Brushes.DarkGray;
                    vehic.Foreground = Brushes.LightGray;
                    form.Text = "Soit Sur place, soit En congés, soit En livraison";
                }
            }
        }
        private void numtel_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= numtel_GotFocus;
        }
        int id;
        private void inscription_Click(object sender, RoutedEventArgs e)
        {
            if (prenom.Text != null && prenom.Text != "Entrez ici votre prénom" && nom.Text != null && nom.Text != "Entrez ici votre nom" && adresse.Text != null && adresse.Text != "Entrez ici votre adresse")
            {
                bool success = int.TryParse(numtel.Text, out id);
                if (!success)
                {
                    MessageBox.Show("Veuillez rentrer un numéro de téléphone valide");
                }
                else
                {
                    if (this.clients == null || this.clients.Count <= 0)
                    {
                        if (etat.Text != null && etat.Text != "Entrez ici votre état d'activité" && (etat.Text == "Sur place" || etat.Text == "En congés" || etat.Text == "En livraison"))
                        {
                            if (this.livreurs == null || this.livreurs.Count <= 0 && (etat.Text == "Sur place" || etat.Text == "En congés"))
                            {
                                Commis commis = new Commis(nom.Text, prenom.Text, adresse.Text, id, etat.Text, DateTime.Now);
                                if (VerifOccurenceListeCommis(commis) == false)
                                {
                                    Commis.AjoutCommisCSV(commis);
                                    main.GoBackToStartPageInscriptionCommis(commis);
                                }
                                else
                                {
                                    MessageBox.Show("Ce commis existe déjà !");
                                }
                            }
                            else
                            {
                                if (vehicule.Text == "scooter" || vehicule.Text == "trotinette" || vehicule.Text == "velo")
                                {
                                    Livreur livreur = new Livreur(nom.Text, prenom.Text, adresse.Text, id, etat.Text, vehicule.Text);
                                    if (VerifOccurenceListeLivreur(livreur) == false)
                                    {
                                        Livreur.AjoutLivreurCSV(livreur);
                                        main.GoBackToStartPageInscriptionLivreur(livreur);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ce livreur existe déjà !");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Client client = new Client(nom.Text, prenom.Text, adresse.Text, id);
                        if (VerifOccurenceListe(client) == false)
                        {
                            Client.AjoutClientCSV(client);
                            main.GoBackToStartPageInscription(client);
                        }
                        else
                        {
                            MessageBox.Show("Client déjà existant");
                        }
                    }
                }
            }
        }
        private bool VerifOccurenceListe(Client client)
        {
            return clients.Contains(client);
        }
        private bool VerifOccurenceListeCommis(Commis commi)
        {
            return commis.Contains(commi);
        }
        private bool VerifOccurenceListeLivreur(Livreur livreur)
        {
            return livreurs.Contains(livreur);
        }
    }
}
