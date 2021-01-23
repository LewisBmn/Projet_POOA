﻿using System;
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
    /// Logique d'interaction pour PageEffectifEmployés.xaml
    /// </summary>
    public partial class PageEffectifEmployés : Page
    {
        private MainWindow main;
        public PageEffectifEmployés(MainWindow mainWindow)
        {
            InitializeComponent();
            AfficherCommis.Content = "Afficher les\n   commis";
            AjouterCommis.Content = "Ajouter un\n   commis";
            AfficherLivreur.Content = "Afficher les\n   livreurs";
            AjouterLivreur.Content = "Ajouter un\n   livreur";
            this.main = mainWindow;
        }

        private void AfficherCommis_Click(object sender, RoutedEventArgs e)
        {
            main.EffectifACommis();
        }

        private void AjouterCommis_Click(object sender, RoutedEventArgs e)
        {
            main.InscriptionCommis();
        }

        private void AfficherLivreur_Click(object sender, RoutedEventArgs e)
        {
            main.EffectifALivreur();
        }

        private void AjouterLivreur_Click(object sender, RoutedEventArgs e)
        {
            main.InscriptionLivreur();
        }
    }
}
