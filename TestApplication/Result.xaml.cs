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
    /// Interaction logic for Result.xaml
    /// </summary>
    public partial class Result : Page
    {
        private List<String> available;
        public List<String> Available
        {
            get
            {
                return available;
            }
            set
            {
                available = value;
            }
        }
        HHU hhuOperator;
        public Result()
        {
            InitializeComponent();
            try
            {
                hhuOperator = new HHU();
                Available = hhuOperator.Categories;
            }
            catch (Exception e)
            {
                lblLetter.Content = "%&";
                MessageBox.Show(e.ToString());
            }
        }

        private void btnNextLetter_Click(object sender, RoutedEventArgs e)
        {
            if ((string)lblLetter.Content == "%&")
            {
                return;
            }
            String strLet = hhuOperator.Picker(hhuOperator.Alphabet, 1)[0];
            lblLetter.Content = strLet;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnCategories_Click(object sender, RoutedEventArgs e)
        {
            if ((string)lblLetter.Content == "%&")
            {
                return;
            }
            List<String> lstCat = new List<string>();
            if (Properties.Settings.Default.CatForget)
            {
                lstCat = hhuOperator.Picker(hhuOperator.Categories, Properties.Settings.Default.CatPick);
            }
            else
            {
                lstCat = hhuOperator.Picker(Available, Properties.Settings.Default.CatPick);
                Available = hhuOperator.Remove(lstCat);
            }
            lstCategories.Items.Clear();
            foreach (String strCat in lstCat)
            {
                ListViewItem lviCat = new ListViewItem();
                lviCat.Content = strCat;
                lstCategories.Items.Add(lviCat);
            }
            lblLetter.Content = "--";
        }
    }
}
