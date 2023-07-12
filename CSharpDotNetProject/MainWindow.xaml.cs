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
namespace CSharpDotNetProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           // clickMe.FontSize = 50;
         
        }

      
        private void Openwindow1(object sender, RoutedEventArgs e)
        {
            Window1 sW = new Window1();
            sW.Show();
            this.Close(); 

        }
        private void Openwindow2ListSearch(object sender, RoutedEventArgs e)
        {
            Window2ListSearch sW = new Window2ListSearch();
            sW.Show();
   
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount== 2)
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        /*private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FillPdf pdf = new FillPdf();
            pdf.Show();
            this.Close(); 
        }*/

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 sW = new Window1();
            sW.Show();
            this.Close();

        }

       /* private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveImage sW = new SaveImage();
            sW.Show();
        }*/

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window2ListSearch sW = new Window2ListSearch();
            sW.Show();
        }
    }
}
