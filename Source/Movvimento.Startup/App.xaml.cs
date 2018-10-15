using ControleDeAulas.View;
using ControleDeAulas.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ControleDeAulas.Startup
{
    /// <summary>	
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainWindow() { DataContext = new MainWindowViewModel() };

            window.Title = "Sistema de Controle de Aulas";

            window.Visibility = Visibility.Visible;
        }
    }
}