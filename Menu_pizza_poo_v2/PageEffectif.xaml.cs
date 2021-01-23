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
    /// Logique d'interaction pour PageEffectif.xaml
    /// </summary>
    public partial class PageEffectif : Page
    {
        private MainWindow main;
        public PageEffectif(MainWindow mainWindow)
        {
            InitializeComponent();
            this.main = mainWindow;
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            main.EffectifAClient();
        }

        private void Commis_Click(object sender, RoutedEventArgs e)
        {
            main.EffectifAEmployé();
        }
    }
}
