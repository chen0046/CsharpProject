using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Syncfusion.UI.Xaml.ImageEditor;
using Syncfusion.UI.Xaml.ImageEditor.Enums;


using System.IO;
using Microsoft.Win32;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace CSharpDotNetProject
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        string connectionstring = "server=localhost;port=3306;database=kloningsattest;uid=root;password=Oliven13";
        int[] yesNo = new int[11];
        string strName1, imageName1;
        string strName2, imageName2;


        public Window1()
        {
            InitializeComponent();
        }

        private void OpenwindowSign(object sender, RoutedEventArgs e)
        {
            WindowSigniture sW = new WindowSigniture();
            sW.Show();
        }

       
        private void save_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionstring);
                connection.Open();
                string query = "INSERT INTO `bil_information` (`Registreringsnummer`,`Stelnummer`,`Maerke`,`Model`,`Version`,`Foerste_registrering`,`Antal_noegler`,`Gearkassenummer`) " +
                         "VALUES('" + registreringsnummer.Text + "','" + stelnummer.Text + "','" + mærke.Text + "','" + model.Text + "'," +
                         "'" + version.Text + "','" + første_registrering.Text + "','" + antal_nøgler.Text + "','" + gearkassenummer.Text + "')";

                string query2 = "INSERT INTO `attest_information` (`Dato`,`Registreringsnummer`,`Stelnummer`,`DEKRA_Bilsyn`,`Rapport_udfoert_af`," +
                    "`Fremstiller`,`Kontaktperson`,`Registreringsattest`,`Registreringsattest_original_kopi`,`Seneste_kendte_registreringsnummer`," +
                    "`E_typegodkendt_under_nr`,`Dokumenteret_med_brochure`,`Dokumenteret_med_erklaering_proevningslaboratorium`,`Dokumenteret_med_CoC_erklaering`," +
                    "`Billeder_af_dokumenter_vedhaeftet`,`KM_stand`,`Gearkassenummer_kontrolleret`,`Medbragt_servicehitorik_kontrolleret`,`Noegler_kontrolleret_statspaerre_og_aaben_og_laasefunktion`," +
                    "`Identitet_dokumenteret_Originalt_CoC_dokument_data_erklaering`,`Originalt_laktykkelse`,`Laktykkelse_maalt_til`,`Lak_konklusion`,`Motornummer_kontrolleret`,`Koeretoej_i_original_farve`," +
                    "`Er_stelnummer_korrekt`,`Stelnummerets_tilstand`,`Beskadiget_manglende_stelnummer`) " +
                "VALUES('" + dato.Text + "','" + registreringsnummer.Text + "','" + stelnummer.Text + "','" + dekra_bilsyn.Text + "'," +
                "'" + rapport_udført_af.Text + "','" + fremstiller.Text + "','" + kontaktperson.Text + "','" + Registreringsattest.Text + "'," +
                "'" + registreringsattest_original.Text + "','" + seneste_kendte_registreringsnummer.Text + "','" + E_typegodkendt.Text + "'," +
                "'" + yesNo[1] + "','" + yesNo[2] + "'," +
                "'" + yesNo[3] + "','" + yesNo[4] + "','" + km_stand.Text + "'," +
                "'" + yesNo[8] + "','" + yesNo[9] + "','" + yesNo[7] + "','" + yesNo[10] + "'," +
                "'" + original_laktykkelse.Text + "','" + laktykkelse_målt_til.Text + "','" + lak_konklusion.Text + "','" + yesNo[6] + "','" + yesNo[5] + "'," +
                "'" + yesNo[0] + "','" + stelnummer_tilstand.Text + "','" + beskadigt_stelnummer.Text + "')";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                int value = cmd.ExecuteNonQuery();
                int value2 = cmd2.ExecuteNonQuery();


                MessageBox.Show("Saved");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MainWindow sW = new MainWindow();
            sW.Show();
            this.Close();

        }

        private void km_stand_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void antal_nøgler_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }





        private void Stelnummer_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[0] = 0;
        }

        private void StelnummerFalse_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[0] = 1;
        }

        private void Brochure_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[1] = 0;
        }

        private void BrochureFalse_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[1] = 1;
        }

        private void Proevelab_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[2] = 0;
        }

        private void ProevelabFalse_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[2] = 1;
        }

        private void Cocdok_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[3] = 0;
        }

        private void CocdokFalse_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[3] = 1;
        }

        private void Billed_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[4] = 0;
        }

        private void BilledFalse_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[4] = 1;
        }

        private void Farve_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[5] = 0;
        }

        private void FarveFalse_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[5] = 1;
        }

        private void Motorkontrolleret_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[6] = 0;
        }

        private void MotorkontrolleretFalse_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[6] = 1;
        }

        private void Noeglekontrol_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[7] = 0;
        }

        private void NoeglekontrolFalse_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[7] = 1;
        }

        private void Gearkassenummer_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[8] = 0;
        }

        private void GearkassenummerFalse_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[8] = 1;
        }

        private void medbragt_servicehistorik_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[9] = 0;
        }

        private void medbragt_servicehistorikFalse_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[9] = 1;
        }

        private void Coc_dokument_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[10] = 0;
        }

        private void Coc_dokumentFalse_Checked(object sender, RoutedEventArgs e)
        {
            yesNo[10] = 1;
        }

    }
}