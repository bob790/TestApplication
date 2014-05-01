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

namespace TestApplication
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Result resultResultPage = new Result();
            this.NavigationService.Navigate(resultResultPage);
        }

        private void btnSetup_Click(object sender, RoutedEventArgs e)
        {
            Setup setupSetupPage = new Setup();
            this.NavigationService.Navigate(setupSetupPage);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Updater updateUpdatePage = new Updater();
            this.NavigationService.Navigate(updateUpdatePage);
        }
    }
}
