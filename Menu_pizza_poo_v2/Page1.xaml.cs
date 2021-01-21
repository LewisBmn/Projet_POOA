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
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        int compteurFrom = 0;
        int compteurChor = 0;
        int compteurVege = 0;

        int compteurPrixFrom = 0;
        int compteurPrixChor = 0;
        int compteurPrixVege = 0;

        int grandeVege = 22;
        int moyenneVege = 18;
        int petiteVege = 15;

        int grandeFrom = 20;
        int moyenneFrom = 16;
        int petiteFrom = 12;

        int grandeChor = 26;
        int moyenneChor = 22;
        int petiteChor = 18;

        public Page1(MainWindow mainWindow, Client cl)
        {
            InitializeComponent();
            main = mainWindow;
            this.client = cl;
        }
        private MainWindow main;
        private Client client;
        private void Btn_MoinsFrom_Click(object sender, RoutedEventArgs e)
        {
            if (compteurFrom > 0)
            {
                compteurFrom--;
                TxCompteurFrom.Text = compteurFrom.ToString();
                if (GrandeFrom.IsChecked == true) { compteurPrixFrom = compteurFrom * grandeFrom; }
                if (MoyenneFrom.IsChecked == true) { compteurPrixFrom = compteurFrom * moyenneFrom; }
                if (PetiteFrom.IsChecked == true) { compteurPrixFrom = compteurFrom * petiteFrom; }
                PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
            }
        }

        private void Btn_PlusFrom_Click(object sender, RoutedEventArgs e)
        {
            compteurFrom++;
            TxCompteurFrom.Text = compteurFrom.ToString();
            if (GrandeFrom.IsChecked == true) { compteurPrixFrom = compteurFrom * grandeFrom; }
            if (MoyenneFrom.IsChecked == true) { compteurPrixFrom = compteurFrom * moyenneFrom; }
            if (PetiteFrom.IsChecked == true) { compteurPrixFrom = compteurFrom * petiteFrom; }
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }
        private void Btn_MoinsChor_Click(object sender, RoutedEventArgs e)
        {
            if (compteurChor > 0)
            {
                compteurChor--;
                TxCompteurChor.Text = compteurChor.ToString();
                if (GrandeChor.IsChecked == true) { compteurPrixChor = compteurChor * grandeChor; }
                if (MoyenneChor.IsChecked == true) { compteurPrixChor = compteurChor * moyenneChor; }
                if (PetiteChor.IsChecked == true) { compteurPrixChor = compteurChor * petiteChor; }
                PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
            }
        }
        private void Btn_PlusChor_Click(object sender, RoutedEventArgs e)
        {
            compteurChor++;
            TxCompteurChor.Text = compteurChor.ToString();
            if (GrandeChor.IsChecked == true) { compteurPrixChor = compteurChor * grandeChor; }
            if (MoyenneChor.IsChecked == true) { compteurPrixChor = compteurChor * moyenneChor; }
            if (PetiteChor.IsChecked == true) { compteurPrixChor = compteurChor * petiteChor; }
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }
        private void Btn_MoinsVege_Click(object sender, RoutedEventArgs e)
        {
            if (compteurVege > 0)
            {
                compteurVege--;
                TxCompteurVege.Text = compteurVege.ToString();
                if (GrandeVege.IsChecked == true) { compteurPrixVege = compteurVege * grandeVege; }
                if (MoyenneVege.IsChecked == true) { compteurPrixVege = compteurVege * moyenneVege; }
                if (PetiteVege.IsChecked == true) { compteurPrixVege = compteurVege * petiteVege; }
                PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
            }
        }
        private void Btn_PlusVege_Click(object sender, RoutedEventArgs e)
        {
            compteurVege++;
            TxCompteurVege.Text = compteurVege.ToString();
            if (GrandeVege.IsChecked == true) { compteurPrixVege = compteurVege * grandeVege; }
            if (MoyenneVege.IsChecked == true) { compteurPrixVege = compteurVege * moyenneVege; }
            if (PetiteVege.IsChecked == true) { compteurPrixVege = compteurVege * petiteVege; }
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void PetiteFrom_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixFrom = compteurFrom * petiteFrom;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void MoyenneFrom_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixFrom = compteurFrom * moyenneFrom;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void GrandeFrom_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixFrom = compteurFrom * grandeFrom;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void PetiteChor_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixChor = compteurChor * petiteChor;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void MoyenneChor_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixChor = compteurChor * moyenneChor;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void GrandeChor_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixChor = compteurChor * grandeChor;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void PetiteVege_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixVege = compteurVege * petiteVege;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void MoyenneVege_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixVege = compteurVege * moyenneVege;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void GrandeVege_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixVege = compteurVege * grandeVege;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void Btn_Commander_Click(object sender, RoutedEventArgs e)
        {
            Pizza[] pizzas = new Pizza[compteurFrom + compteurChor + compteurVege];
            if (compteurFrom > 0 || compteurChor > 0 || compteurVege > 0)
            {
                Pizza pizzaFrom = new Pizza();
                Pizza pizzaChor = new Pizza();
                Pizza pizzaVege = new Pizza();
                if (PetiteFrom.IsChecked == true) { pizzaFrom = new Pizza("petite", "4 fromages", petiteFrom); }
                if (MoyenneFrom.IsChecked == true) { pizzaFrom = new Pizza("moyenne", "4 fromages", moyenneFrom); }
                if (GrandeFrom.IsChecked == true) { pizzaFrom = new Pizza("grande", "4 fromages", grandeFrom); }

                if (PetiteChor.IsChecked == true) { pizzaChor = new Pizza("petite", "chorizo", petiteChor); }
                if (MoyenneChor.IsChecked == true) { pizzaChor = new Pizza("moyenne", "chorizo", moyenneChor); }
                if (GrandeChor.IsChecked == true) { pizzaChor = new Pizza("grande", "chorizo", grandeChor); }

                if (PetiteVege.IsChecked == true) { pizzaVege = new Pizza("petite", "végétarienne", petiteVege); }
                if (MoyenneVege.IsChecked == true) { pizzaVege = new Pizza("moyenne", "végétarienne", moyenneVege); }
                if (GrandeVege.IsChecked == true) { pizzaVege = new Pizza("grande", "végétarienne", grandeVege); }

                for (int i = 0; i < compteurFrom; i++) { pizzas[i] = pizzaFrom; }
                for (int j = compteurFrom; j < compteurFrom + compteurChor; j++) { pizzas[j] = pizzaChor; }
                for (int k = compteurFrom + compteurChor; k < compteurFrom + compteurChor + compteurVege; k++) { pizzas[k] = pizzaVege; }
            }

            Commande commande = new Commande(pizzas, compteurPrixFrom + compteurPrixChor + compteurPrixVege, this.client.NumTel);
            this.client.Commandes.Add(commande);
            this.client.AchatsCumulés += commande.Prix;
            main.GoBackToStartPageCommander(commande);
        }
    }
}
