using MySql.Data.MySqlClient;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Widget;
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
using System.Windows.Shapes;

namespace CSharpDotNetProject
{
    /// <summary>
    /// Interaction logic for CertificateOverview.xaml
    /// </summary>
    public partial class CertificateOverview : Window
    {
        string connectionstring = "server=localhost; port=3306;database=kloningsattest;uid=root;password=Oliven13";
        private const string Value = "Kloningsattest-02-2022-TEST.pdf";
        string[] textForPdf = new string[40];
        Boolean[] checksForPdf = new Boolean[5]; 
        Certificate certificate = new Certificate();
        public CertificateOverview(string id)
        {
            InitializeComponent();

            initCert(id);
            initCar(certificate.Registration);
            fillTextArray();
            insertText();


            void initCar(string reg)
            {
                MySqlConnection connection = new MySqlConnection(connectionstring);
                MySqlCommand cmd = new MySqlCommand("select * FROM kloningsattest.Bil_information WHERE Registreringsnummer = @reg;", connection) ;
                connection.Open(); 
                cmd.Parameters.AddWithValue("@reg", reg);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    reader.Read();
                    certificate.Make = reader["maerke"].ToString();
                    certificate.Model = reader["model"].ToString();
                    certificate.Version = reader["version"].ToString();
                    certificate.Keys = (int)reader["Antal_noegler"];
                    certificate.GearBoxNumber = reader["Gearkassenummer"].ToString(); 
                }
            }

            void initCert(string id)
            {
                MySqlConnection connection = new MySqlConnection(connectionstring);
                MySqlCommand cmd = new MySqlCommand("select * FROM kloningsattest.attest_information where Attest_ID = " + id + ";", connection);
                connection.Open();
                MySqlDataReader dt;
                dt = cmd.ExecuteReader();
                if (dt != null)
                {
                    dt.Read();
                    certificate.Id = (int)dt["Attest_ID"];
                    certificate.Date = dt["Dato"].ToString();
                    certificate.Registration = dt["Registreringsnummer"].ToString();
                    certificate.SerialNumber = dt["Stelnummer"].ToString();
                    certificate.Workshop = dt["DEKRA_Bilsyn"].ToString();
                    certificate.Worker = dt["Rapport_udfoert_af"].ToString();
                    certificate.Customer = dt["Fremstiller"].ToString();
                    certificate.Contact = dt["Kontaktperson"].ToString();
                    certificate.Registrationcertificate = dt["Registreringsattest"].ToString();
                    certificate.RegistrationcertificateOriginal = dt["Registreringsattest_original_kopi"].ToString();
                    certificate.LastRegistration = dt["Seneste_kendte_registreringsnummer"].ToString();
                    certificate.ETypeApproveNr = dt["E_typegodkendt_under_nr"].ToString();
                    certificate.DocumentedByBrochure = dt["Dokumenteret_med_brochure"].ToString();
                    certificate.DocumentedByLab = dt["Dokumenteret_med_erklaering_proevningslaboratorium"].ToString();
                    certificate.DocumentedByCocDoc = dt["Dokumenteret_med_CoC_erklaering"].ToString();
                    certificate.PicturesAppended = dt["Billeder_af_dokumenter_vedhaeftet"].ToString();
                    certificate.Mileage = (int)dt["KM_stand"];
                    certificate.GearBoxVerified = dt["Gearkassenummer_kontrolleret"].ToString();
                    certificate.ServiceHistoryVerified = dt["Medbragt_servicehitorik_kontrolleret"].ToString();
                    certificate.KeyControlled = dt["Noegler_kontrolleret_statspaerre_og_aaben_og_laasefunktion"].ToString();
                    certificate.IdentityVerified = dt["Identitet_dokumenteret_Originalt_CoC_dokument_data_erklaering"].ToString();
                    certificate.OriginalPaintThickness = dt["Originalt_laktykkelse"].ToString();
                    certificate.OriginalPaintThicknessMeasured = dt["Laktykkelse_maalt_til"].ToString();
                    certificate.PaintConclusion = dt["Lak_konklusion"].ToString();
                    certificate.EngineNumberVerified = dt["Motornummer_kontrolleret"].ToString();
                    certificate.OriginalPaint = dt["Koeretoej_i_original_farve"].ToString();
                    certificate.SerialCorrect = dt["Er_stelnummer_korrekt"].ToString();
                    certificate.SerialCondition = dt["Stelnummerets_tilstand"].ToString();
                    certificate.SerialDamaged = dt["Beskadiget_manglende_stelnummer"].ToString();                    
                }
                else
                {

                }
            }
                void insertText()
                {
                ID.Text = certificate.Id.ToString();
                dato.Text = certificate.Date.ToString();
                registreringsnummer.Text = certificate.Registration.ToString();
                stelnummer.Text = certificate.SerialNumber.ToString();
                workshop.Text = certificate.Workshop.ToString();
                rapport_udført_af.Text = certificate.Worker.ToString();
                fremstiller.Text = certificate.Customer.ToString();
                registreringsattest.Text = certificate.Registrationcertificate.ToString();
                registreringsattest_kopi.Text = certificate.Registrationcertificate.ToString();
                seneste_registreringsnummer.Text = certificate.LastRegistration.ToString();
                e_typegodkendt.Text = certificate.ETypeApproveNr.ToString();
                brochure.Text = certificate.DocumentedByBrochure.ToString();
                proeningslaboratorium.Text = certificate.DocumentedByLab.ToString();
                coc_dokument.Text = certificate.DocumentedByCocDoc.ToString();
                billeder_vedhæftet.Text = certificate.PicturesAppended.ToString();
                km_stand.Text = certificate.Mileage.ToString();
                gearkassenummer_kontrolleret.Text = certificate.GearBoxVerified.ToString();
                servicehistorik_kontrolleret.Text = certificate.ServiceHistoryVerified.ToString();
                noegler_kontrolleret.Text = certificate.KeyControlled.ToString();
                coc_dokument_data.Text = certificate.IdentityVerified.ToString();
                originalt_laktykkelse.Text = certificate.OriginalPaintThickness.ToString();
                laktykkelse_maalt.Text = certificate.OriginalPaintThicknessMeasured.ToString();
                lak_konklusion.Text = certificate.PaintConclusion.ToString();
                motornummer_kontrolleret.Text = certificate.EngineNumberVerified.ToString();
                koertøj_original_farve.Text = certificate.SerialCorrect.ToString();
                stelnummer_korrekt.Text = certificate.SerialCorrect.ToString();
                stelnummerets_tilstand.Text = certificate.SerialCondition.ToString();
                beskadgiet_stelnummer.Text = certificate.SerialDamaged.ToString();
                certGearbox.Text = certificate.GearBoxNumber.ToString();
                certKeys.Text = certificate.Keys.ToString();
                certMake.Text = certificate.Make.ToString();
                certModel.Text = certificate.Model.ToString();
                certVersion.Text = certificate.Version.ToString();
                }
        }
        private void fillTextArray()
        {
            textForPdf[0] = certificate.Customer;
            textForPdf[1] = certificate.SerialCondition;
            textForPdf[2] = certificate.Contact;
            textForPdf[3] = certificate.SerialCondition;
            textForPdf[4] = certificate.Registration;
            textForPdf[5] = certificate.RegistrationcertificateOriginal;
            textForPdf[6] = certificate.SerialNumber;
            textForPdf[7] = certificate.Make;
            textForPdf[8] = certificate.Model;
            textForPdf[9] = certificate.Version;
            textForPdf[10] = certificate.Mileage.ToString();
            textForPdf[11] = certificate.DateRegistered.ToString();
            textForPdf[12] = certificate.Date;
            textForPdf[13] = certificate.Worker;
            textForPdf[14] = certificate.Workshop;
            textForPdf[15] = certificate.Registration;
            textForPdf[16] = certificate.LastRegistration;
            textForPdf[17] = certificate.ETypeApproveNr;
            textForPdf[18] = certificate.OriginalPaint;
            textForPdf[19] = certificate.OriginalPaintThickness;
            textForPdf[20] = certificate.PaintConclusion;
            textForPdf[21] = certificate.OriginalPaintThicknessMeasured;
            textForPdf[22] = "12345678";
            textForPdf[23] = certificate.GearBoxNumber; 
            textForPdf[24] = certificate.EngineNumberVerified;
            textForPdf[25] = certificate.GearBoxVerified;
            textForPdf[26] = certificate.Keys.ToString();
            textForPdf[27] = certificate.ServiceHistoryVerified;
            textForPdf[28] = certificate.KeyControlled;
            textForPdf[29] = "Godkendt";
            textForPdf[30] = "Ikke andet nævnt";
            textForPdf[31] = "Ikke andet nævnt";
            textForPdf[32] = certificate.Date;
            textForPdf[33] = certificate.Date;
            textForPdf[34] = certificate.Date;
            textForPdf[35] = certificate.Date;
            textForPdf[36] = "Ikke andet nævnt";
            textForPdf[37] = "Ikke andet nævnt";
            textForPdf[38] = "Ikke andet nævnt";
            textForPdf[39] = "Ikke andet nævnt";

            if (certificate.SerialCorrect == "1")
            {
                checksForPdf[0] = true; 
            }
            else
            {
                checksForPdf[0] = false; 
            }
            if (certificate.DocumentedByBrochure == "1")
            {
                checksForPdf[1] = true;
            }
            else
            {
                checksForPdf[1] = false;
            }
            if (certificate.DocumentedByLab == "1")
            {
                checksForPdf[2] = true;
            }
            else
            {
                checksForPdf[2] = false;
            }
            if (certificate.DocumentedByCocDoc == "1")
            {
                checksForPdf[3] = true;
            }
            else
            {
                checksForPdf[3] = false;
            }
            if (certificate.PicturesAppended == "1")
            {
                checksForPdf[4] = true;
            }
            else
            {
                checksForPdf[4] = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int t = 0;
            int bt = 0;
            Boolean firstDown = false; 
            string fileName = new string(Value);
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(fileName);
            PdfFormWidget formWidget = doc.Form as PdfFormWidget;
            for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
            {
                PdfField field = formWidget.FieldsWidget.List[i] as PdfField;

                if (field is PdfTextBoxFieldWidget)
                {
                    PdfTextBoxFieldWidget pdfTextBoxField = field as PdfTextBoxFieldWidget;
                    pdfTextBoxField.Text = textForPdf[t];
                    t++;
                }
                if (field is PdfCheckBoxWidgetFieldWidget)
                {
               
                        if (!firstDown && checksForPdf[bt])
                        {
                            PdfCheckBoxWidgetFieldWidget pdfCheckButtonField = field as PdfCheckBoxWidgetFieldWidget;
                            pdfCheckButtonField.Checked = true;
                            firstDown = true; 
                        }
                        else if (!firstDown && !checksForPdf[bt])
                        {
                            firstDown = true;
                        }
                        else if (firstDown && checksForPdf[bt])
                        {
                            firstDown = false;
                            bt++;
                        } 
                        else if (firstDown && !checksForPdf[bt])
                        {
                            PdfCheckBoxWidgetFieldWidget pdfCheckButtonField = field as PdfCheckBoxWidgetFieldWidget;
                            pdfCheckButtonField.Checked = true;
                            bt++; 
                            firstDown = false;
                        }
                    
                }
            }
            doc.SaveToFile("saveTest.pdf");
        }
    }
}
