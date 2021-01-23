using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Timers;
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
    /// Logique d'interaction pour PageResumeCommandes.xaml
    /// </summary>
    public partial class PageResumeCommandes : Page
    {
        private List<Commande> com = new List<Commande> { };
        private MainWindow mainWindow;
        private List<Livreur> livreurs = new List<Livreur> { };
        public PageResumeCommandes(List<Commande> commandes, MainWindow main, List<Livreur> livreurs)
        {
            InitializeComponent();
            this.com = commandes;
            this.mainWindow = main;
            this.livreurs = livreurs;
            if (commandes == null || commandes.Count <= 0 /*|| (commandes.Count == 1 && commandes[0] == null)*/)
            {
                TextBlock text = new TextBlock
                {
                    Text = "\n          Pas de commande active, revenez plus tard !"
                };
                Border rec = new Border()
                {
                    Height = 50,
                    Width = 300,
                    Background = Brushes.LightGray,
                    BorderBrush = Brushes.LightGray,
                    CornerRadius = new CornerRadius(20),
                };
                grid.Children.Add(text);
                grid.Children.Add(rec);
                Grid.SetRow(rec, 3);
                Grid.SetColumn(rec, 1);
                Grid.SetZIndex(rec, 0);
                Grid.SetRow(text, 3);
                Grid.SetColumn(text, 1);
                Grid.SetZIndex(text, 1);
            }
            else
            {
                List<TextBlock> tx = new List<TextBlock> { };
                List<TextBlock> txCom = new List<TextBlock> { };
                List<TextBlock> txEtat = new List<TextBlock> { };
                List<TextBlock> txPrix = new List<TextBlock> { };
                List<TextBlock> txLivreur = new List<TextBlock> { };
                int compteur = 1;
                foreach (Commande commande in commandes)
                {
                    Livreur tamp = new Livreur();
                    for (int i = 0; i < livreurs.Count; i++)
                    {
                        if (livreurs[i].Commandedulivreur.NumeroDeCommande == commande.NumeroDeCommande)
                        {
                            tamp = livreurs[i];
                        }
                        else { }
                    }
                    txCom.Add(new TextBlock() { Text = "Commande n°" + commande.NumeroDeCommande, FontFamily = new FontFamily("Arial"), FontSize = 20, HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10, 5, 0, 0) });
                    tx.Add(new TextBlock() { Text = "\n" + commande.ToString(), FontFamily = new FontFamily("Arial"), HorizontalAlignment = HorizontalAlignment.Center, Margin = new Thickness(0, 20, 0, 0) });
                    txEtat.Add(new TextBlock() { Text = commande.EtatCommande, FontFamily = new FontFamily("Arial"), FontSize = 14, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, 10, 10, 0) });
                    txPrix.Add(new TextBlock() { Text = commande.Prix.ToString() + "€", FontFamily = new FontFamily("Arial"), FontSize = 14, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, 25, 10, 0) });
                    txLivreur.Add(new TextBlock() { Text = "Livreur : " + tamp.NomFamille + " " + tamp.Prenom, FontFamily = new FontFamily("Arial"), FontSize = 14, HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10, 30, 10, 0) });
                    Border rec = new Border()
                    {
                        Height = ((commande.Pizzas.Length + commande.Boisson.Count + 2) * 15) + 10,
                        MinHeight = 70,
                        Width = 300,
                        Background = Brushes.LightGray,
                        BorderBrush = Brushes.LightGray,
                        CornerRadius = new CornerRadius(20),
                    };
                    grid.Children.Add(txCom[compteur - 1]);
                    grid.Children.Add(tx[compteur - 1]);
                    grid.Children.Add(txEtat[compteur - 1]);
                    grid.Children.Add(txPrix[compteur - 1]);
                    grid.Children.Add(txLivreur[compteur - 1]);
                    grid.Children.Add(rec);

                    Grid.SetRow(txCom[compteur - 1], 1 + 2 * compteur);
                    Grid.SetColumn(txCom[compteur - 1], 1);
                    Grid.SetZIndex(txCom[compteur - 1], 1);

                    Grid.SetRow(rec, 1 + 2 * compteur);
                    Grid.SetColumn(rec, 1);
                    Grid.SetZIndex(rec, 0);

                    Grid.SetRow(tx[compteur - 1], 1 + 2 * compteur);
                    Grid.SetColumn(tx[compteur - 1], 1);
                    Grid.SetZIndex(tx[compteur - 1], 1);

                    Grid.SetRow(txEtat[compteur - 1], 1 + 2 * compteur);
                    Grid.SetColumn(txEtat[compteur - 1], 1);
                    Grid.SetZIndex(txEtat[compteur - 1], 1);

                    Grid.SetRow(txPrix[compteur - 1], 1 + 2 * compteur);
                    Grid.SetColumn(txPrix[compteur - 1], 1);
                    Grid.SetZIndex(txPrix[compteur - 1], 1);

                    Grid.SetRow(txLivreur[compteur - 1], 1 + 2 * compteur);
                    Grid.SetColumn(txLivreur[compteur - 1], 1);
                    Grid.SetZIndex(txLivreur[compteur - 1], 1);
                    compteur++;

                }
                int compt = 0;
                while (compt < commandes.Count)
                {
                    this.EnLivraisonChange(commandes[compt], txEtat[compt]);
                    compt++;
                }
                int compt2 = 0;
                while (compt2 < commandes.Count)
                {
                    this.ArriveChange(commandes[compt2], txEtat[compt2]);
                    compt2++;
                }
                int compt3 = 0;
                while (compt3<commandes.Count)
                {
                    this.FermerCommande(commandes[compt3], txCom[compt3], tx[compt3], txEtat[compt3], txPrix[compt3], txLivreur[compt3], txCom, tx, txEtat, txPrix, txLivreur);
                    compt3++;
                }
            }
        }
        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            this.mainWindow.RafraichirCommandes(this.com, this.livreurs);
        }

        private void EnLivraisonChange(Commande commande, TextBlock tb)
        {
            Random rd = new Random();
            System.Threading.Thread.Sleep(50);
            Task.Delay(rd.Next(10000, 20000)).ContinueWith(_ =>
            {
                if (commande.EtatCommande == "En préparation")
                {
                    commande.EtatCommande = "En livraison";
                    tb.Text = "En livraison";
                }
                int index = 0;
                for (int i = 0; i < livreurs.Count; i++)
                {
                    if (livreurs[i].Commandedulivreur.NumeroDeCommande == commande.NumeroDeCommande)
                    {
                        index = i;
                    }
                    else { }
                }
                livreurs[index].EtatLivraison();
            }
            );
        }
        private void ArriveChange(Commande commande, TextBlock tb)
        {
            Random rd = new Random();
            System.Threading.Thread.Sleep(50);
            Task.Delay(rd.Next(20000, 30000)).ContinueWith(_ =>
            {
                if (commande.EtatCommande == "En livraison")
                {
                    commande.EtatCommande = "Arrivée";
                    tb.Text = "Arrivée";
                }
                int index = 0;
                for (int i = 0; i < livreurs.Count; i++)
                {
                    if (livreurs[i].Commandedulivreur.NumeroDeCommande == commande.NumeroDeCommande)
                    {
                        index = i;
                    }
                    else { }
                }
                livreurs[index].EtatLivraison();
            }
            );
        }
        private void FermerCommande(Commande commande, TextBlock tb, TextBlock tb2, TextBlock tb3, TextBlock tb4, TextBlock tb5, List<TextBlock> ltb, List<TextBlock> ltb2, List<TextBlock> ltb3, List<TextBlock> ltb4, List<TextBlock> ltb5)
        {
            Task.Delay(50000).ContinueWith(_ =>
            {
                if (commande.EtatCommande == "Arrivée")
                {
                    this.com.Remove(commande);
                    ltb.Remove(tb);
                    ltb2.Remove(tb2);
                    ltb3.Remove(tb3);
                    ltb4.Remove(tb4);
                    ltb5.Remove(tb5);
                }
            }
            );
        }
    }

}

