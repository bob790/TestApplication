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
    /// Interaction logic for Setup.xaml
    /// </summary>
    public partial class Setup : Page
    {
        public Setup()
        {
            InitializeComponent();
            sldCatPick.Value = Properties.Settings.Default.CatPick;
            if (Properties.Settings.Default.CatForget)
            {
                chkCatForget.IsChecked = false;
            }
            else
            {
                chkCatForget.IsChecked = true;
            }
        }

        private void sldCatPick_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.CatPick = (int)sldCatPick.Value;
            Properties.Settings.Default.Save();
        }

        private void chkCatForget_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.CatForget = !chkCatForget.IsChecked.Value;
            Properties.Settings.Default.Save();
        }
    }
}
