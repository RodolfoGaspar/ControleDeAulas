﻿using ControleDeAulas.Helpers;
using ControleDeAulas.View;
using ControleDeAulas.ViewModel;
using System;
using System.Globalization;
using System.Threading;
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
						
			var window = new MainWindow() { DataContext = new MainWindowViewModel(new BaseSingleton()) };

			window.Title = "Sistema de Controle de Aulas";

			window.Visibility = Visibility.Visible;

			AppRibbon.Ribbon = window.MyRibbon;

			AppProperties.AppPath = Environment.CurrentDirectory;
			AppProperties.BdPath = ControleDeAulas.Startup.Properties.Settings.Default.BaseDados;

			Navigator.NavigationService = window.MyConteudo.NavigationService;
			Navigator.WizardNavigationService = window.MyConteudoWizard.NavigationService;

			Navigator.NavigationService.Navigate(new HomeView() { DataContext = new HomeViewModel() });
		}
	}
}