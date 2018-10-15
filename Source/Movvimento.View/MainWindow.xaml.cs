using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ControleDeAulas.View
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Ribbon_Loaded(object sender, RoutedEventArgs e)
        { if (VisualTreeHelper.GetChild((DependencyObject)sender, 0) is Grid child) { child.RowDefinitions[0].Height = new GridLength(0); } }
    }
}
