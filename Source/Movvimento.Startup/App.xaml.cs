using ControleDeAulas.Helpers;
using ControleDeAulas.View;
using ControleDeAulas.ViewModel;
using System;
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

			AppProperties.AppPath = Environment.CurrentDirectory;
			AppProperties.BdPath = ControleDeAulas.Startup.Properties.Settings.Default.BaseDados;

			Navigator.NavigationService = window.MyConteudo.NavigationService;
			Navigator.WizardNavigationService = window.MyConteudoWizard.NavigationService;

			Navigator.NavigationService.Navigate(new View.HomeView() { DataContext = new HomeViewModel() });
		}
    }
}