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
        public PageResumeCommandes(List<Commande> commandes, MainWindow main)
        {
            InitializeComponent();
            this.com = commandes;
            this.mainWindow = main;
            if (commandes == null || commandes.Count <= 0 || (commandes.Count == 1 && commandes[0] == null))
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
                int compteur = 1;
                foreach (Commande commande in commandes)
                {
                    if (commande != null)
                    {
                        txCom.Add(new TextBlock() { Text = "Commande n°" + commande.NumeroDeCommande, FontFamily = new FontFamily("Arial"), FontSize = 20, HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10, 5, 0, 0) });
                        tx.Add(new TextBlock() { Text = "\n" + commande.ToString(), FontFamily = new FontFamily("Arial"), HorizontalAlignment = HorizontalAlignment.Center, Margin = new Thickness(0, 3, 0, 0) });
                        txEtat.Add(new TextBlock() { Text = commande.EtatCommande, FontFamily = new FontFamily("Arial"), FontSize = 14, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, 10, 10, 0) });
                        txPrix.Add(new TextBlock() { Text = commande.Prix.ToString() + "€", FontFamily = new FontFamily("Arial"), FontSize = 14, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, 25, 10, 0) });
                        Border rec = new Border()
                        {
                            Height = ((commande.Pizzas.Length + 2) * 15) + 10,
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
                        compteur++;
                    }
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
            }
        }
        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            this.mainWindow.RafraichirCommandes(this.com);
        }

        private void EnLivraisonChange(Commande commande, TextBlock tb)
        {
            Random rd = new Random();
            Task.Delay(rd.Next(10000, 20000)).ContinueWith(_ =>
            {
                if (commande.EtatCommande == "En préparation")
                {
                    commande.EtatCommande = "En livraison";
                    tb.Text = "En livraison";
                }
            }
            );
        }
        private void ArriveChange(Commande commande, TextBlock tb)
        {
            Random rd = new Random();
            Task.Delay(rd.Next(100000, 200000)).ContinueWith(_ =>
            {
                if (commande.EtatCommande == "En livraison")
                {
                    commande.EtatCommande = "Arrivée";
                    tb.Text = "Arrivée";
                }
            }
            );
        }
    }

}

