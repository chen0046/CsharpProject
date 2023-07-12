using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for SaveImage.xaml
    /// </summary>
    public partial class SaveImage : Window
    {
        string strName, imageName;

        string connectionstring = "server=localhost;port=3306;database=Kloningsattest;uid=root;password=Oliven13";

        public SaveImage()
        {
            InitializeComponent();

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "ImageFiles | *.jpg; *.jpeg; *.png";
                Nullable<bool> result = openFileDialog.ShowDialog();
                if (result == true)
                {
                    strName = openFileDialog.SafeFileName;
                    imageName = openFileDialog.FileName;
                    ImageSourceConverter isc = new ImageSourceConverter();
                    
                    pictureName.Text = openFileDialog.FileName;

                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            uploadImage();
        }

        private void uploadImage()
        {
            if (imageName != "")
            {
                FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);
                byte[] byteArray = new byte[fs.Length];
                fs.Read(byteArray, 0, Convert.ToInt32(fs.Length));
                MySqlConnection connection = new MySqlConnection(connectionstring);
                MySqlCommand cmd = new MySqlCommand("INSERT INTO billede (image) VALUES(@byteArray)", connection);
                cmd.Parameters.AddWithValue("@byteArray", byteArray);

                fs.Close();
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("saved image sucessfully");
                    connection.Close();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
