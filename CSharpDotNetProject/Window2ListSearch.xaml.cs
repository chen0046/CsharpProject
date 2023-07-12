using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;


namespace CSharpDotNetProject
{
    /// <summary>
    /// Interaction logic for Window2ListSearch.xaml
    /// </summary>
    public partial class Window2ListSearch : Window
    {
        string connectionstring = "server=localhost;database=Kloningsattest;uid=root;password=Oliven13";

        List<CertificateElement> elements = new List<CertificateElement>();
        public Window2ListSearch()
        {
            InitializeComponent();

            MySqlConnection connection = new MySqlConnection(connectionstring);
            MySqlCommand cmd = new MySqlCommand("select Attest_ID, Registreringsnummer, Dato FROM kloningsattest.attest_information;", connection);
            connection.Open();
            MySqlDataReader dt; 
            dt = cmd.ExecuteReader();
            if (dt.HasRows)
            {
                while (dt.Read())
                {
                    elements.Add(new CertificateElement((int)dt["Attest_ID"], dt["Registreringsnummer"].ToString(), dt["Dato"].ToString())); 
                }
            }
            connection.Close();
            certificateDGrid.ItemsSource = elements;

        }
        private void searchBox_KeyUp(object sender, System.Windows.Input.KeyboardEventArgs e)
        {
            List<CertificateElement> filtered = new List<CertificateElement>(elements.Where(certificate => certificate.registration.StartsWith(searchBox.Text)));
            certificateDGrid.ItemsSource = filtered;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow sW = new MainWindow();
            sW.Show();
            this.Close();
        }
        private void Double_Click(object sender, RoutedEventArgs e)
        {
            var row = ItemsControl.ContainerFromElement((DataGrid)sender,
                                        e.OriginalSource as DependencyObject) as DataGridRow;
            if (row == null) return;
            else
            {
                int index = certificateDGrid.SelectedIndex; 
                string setInfo = (index + 1).ToString();
                CertificateOverview sW = new CertificateOverview(setInfo);
                sW.Show();
                this.Close();
            }
        }
    }
    public class CertificateElement
    {
        public int id { get; set; }
        public string registration { get; set; }
        public string date { get; set; }

        public CertificateElement(int id, string registration, string date)
        {
            this.id = id;
            this.registration = registration;
            this.date = date;
        }
    }
    // create database connection to get current list. 
}
