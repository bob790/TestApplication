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
using System.IO;


namespace TestApplication
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Updater : Page
    {
        private String current;
        public String Current
        {
            get
            {
                return current;
            }
            set
            {
                current = value;
            }
        }
        private List<String> categories;
        public List<String> Categories
        {
            get
            {
                return categories;
            }
            set
            {
                categories = value;
            }
        }
        public Updater()
        {
            InitializeComponent();
            try
            {
                List<String> lstTemp = new List<String>();
                using (StreamReader ioReader = new StreamReader(Properties.Settings.Default.CatFile))
                {
                    string line;
                    while ((line = ioReader.ReadLine()) != null)
                    {
                        lstTemp.Add(line);
                    }
                    ioReader.Close();
                }
                if (lstTemp != null)
                {
                    Categories = lstTemp;
                }
            }
            catch
            {
                MessageBox.Show("No Categories Available");
            }
            this.RefreshList();
        }

        private void RefreshList()
        {
            lstCategories.Items.Clear();
            foreach (String strCat in Categories)
            {
                ListViewItem lviCat = new ListViewItem();
                lviCat.Content = strCat;
                lstCategories.Items.Add(lviCat);
            }

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewItem lviCat = (ListViewItem)lstCategories.SelectedItem;
            if (lviCat != null)
            {
                txtCat.Text = (string)lviCat.Content;
                Current = txtCat.Text;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (categories.Contains(txtCat.Text))
            {
                return;
            }
            ListViewItem lviCat = new ListViewItem();
            lviCat.Content = txtCat.Text;
            lstCategories.Items.Add(lviCat);
            categories.Add(txtCat.Text);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (categories.Contains(txtCat.Text))
            {
                return;
            }
            if (Current != null)
            {
                for (int intCount = 0; intCount < categories.Count; intCount++)
                {
                    if (categories[intCount] == Current)
                    {
                        categories[intCount] = txtCat.Text;
                        Current = txtCat.Text;
                    }
                }
            }
            this.RefreshList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!categories.Contains(txtCat.Text))
            {
                return;
            }
            categories.Remove(Current);
            this.RefreshList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter ioWriter = new StreamWriter(Properties.Settings.Default.CatFile, false))
                {
                    foreach (String strCat in categories)
                    {
                        ioWriter.WriteLine(strCat);
                    }
                    ioWriter.Close();
                }
            }
            catch
            {
                MessageBox.Show("Save Failed");
            }
            finally
            {
                MessageBox.Show("Save Successful");
            }
        }
    }
}
