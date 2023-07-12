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
using System.Windows.Navigation;
using Syncfusion.UI.Xaml.ImageEditor;
using Syncfusion.UI.Xaml.ImageEditor.Enums;

/// https://github.com/SyncfusionExamples/wpf-imageeditor-examples/tree/master/Samples/Signature

namespace CSharpDotNetProject
{
    /// <summary>
    /// Interaction logic for WindowSigniture.xaml
    /// </summary>
    public partial class WindowSigniture : Window
    {
        public WindowSigniture()
        {
            InitializeComponent();
         
        }
        /// <summary>
        /// Invoked when <see cref="SfImageEditor"/> is loaded.
        /// </summary>
        /// <param name="sender">Image editor</param>
        /// <param name="e">event arguments</param>
        private void SfImageEditor_Loaded(object sender, RoutedEventArgs e)
        {
            var imageEditor = sender as SfImageEditor;
            imageEditor?.AddShape(ShapeType.Path, new PenSettings() { Stroke = new SolidColorBrush(Colors.Red), PathStrokeWidth = 3 });
        }

        /// <summary>
        /// Invoked when clean button is clicked.
        /// </summary>
        /// <param name="sender">Clear button</param>
        /// <param name="e">event arguments</param>
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            editor.Reset();
            editor.AddShape(ShapeType.Path, new PenSettings());
        }

        /// <summary>
        /// Invoked when save button is clicked.
        /// </summary>
        /// <param name="sender">Save button</param>
        /// <param name="e">event arguments.</param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            editor.Save();
        }
    }
}
