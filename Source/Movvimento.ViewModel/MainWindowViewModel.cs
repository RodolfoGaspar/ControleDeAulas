using ControleDeAulas.Helpers;
using ControleDeAulas.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ControleDeAulas.ViewModel
{
	public class MainWindowViewModel : BaseViewModel
	{
		#region RelayCommands
		#region Wizard
		/// <summary>
		/// Command do botão Cancel do Wizard.
		/// </summary>
		public RelayCommand WizCancelCommand { get; set; }
		/// <summary>
		/// Command do botão Voltar do Wizard.
		/// </summary>
		public RelayCommand WizBackCommand { get; set; }
		/// <summary>
		/// Command do botão Próximo do Wizard.
		/// </summary>
		public RelayCommand WixNextCommand { get; set; }
		/// <summary>
		/// Command do botão Concluir do Wizard.
		/// </summary>
		public RelayCommand WizFinishCommand { get; set; }
		#endregion

		public RelayCommand ListProfCommand { get; set; }
		public RelayCommand ListFaixaCommand { get; set; }
		public RelayCommand ListNivelCommand { get; set; }
		public RelayCommand ListSituacaoCommand { get; set; }
		public RelayCommand ListCategoriaCommand { get; set; }
		public RelayCommand ListMateriasCommand { get; set; }
		public RelayCommand ListTurmasCommand { get; set; }

		public RelayCommand NovoCommand { get; set; }
		public RelayCommand DeleteCommand { get; private set; }
		public RelayCommand ClosedCommand { get; }		
		#endregion

		#region Constructors
		public MainWindowViewModel(BaseSingleton baseSingleton)
		{
			Base_ = baseSingleton;
				
			baseSingleton.SetProperties();

			AppRibbon.SetVisibility("tabOperacoesCadastro", Visibility.Collapsed);

			ListProfCommand = new RelayCommand(ListProf);
			ListFaixaCommand = new RelayCommand(ListFaixa);
			ListNivelCommand = new RelayCommand(ListNivel);
			ListSituacaoCommand = new RelayCommand(ListSituacao);
			ListCategoriaCommand = new RelayCommand(ListCategoria);
			ListMateriasCommand = new RelayCommand(ListMaterias);
			ListTurmasCommand = new RelayCommand(ListTurmas);

			NovoCommand = new RelayCommand(Add);
			DeleteCommand = new RelayCommand(Delete);
			//ClosedCommand = new RelayCommand(EncerraApp);

			WizFinishCommand = new RelayCommand(Save);
			WizCancelCommand = new RelayCommand(Cancel);
			WizBackCommand = new RelayCommand(Back);
			WixNextCommand = new RelayCommand(Next);
		}
		#endregion

		#region Functions
		private void ListProf(object parameters) => Navigator.NavigationService.Navigate(new ProfessoresView() { DataContext = new ProfessoresViewModel(Base_) });

		private void ListFaixa(object parameters) => Navigator.NavigationService.Navigate(new FaixasView() { DataContext = new FaixasViewModel() });

		private void ListNivel(object parameters) => Navigator.NavigationService.Navigate(new NiveisView() { DataContext = new NiveisViewModel() });
				
		private void ListSituacao(object parameters) => Navigator.NavigationService.Navigate(new SituacoesView() { DataContext = new SituacoesViewModel() });

		private void ListCategoria(object parameters) => Navigator.NavigationService.Navigate(new CategoriasView() { DataContext = new CategoriasViewModel() });

		private void ListMaterias(object parameter) => Navigator.NavigationService.Navigate(new MateriasView() { DataContext = new DisciplinasViewModel() });

		private void ListTurmas(object parameters) => Navigator.NavigationService.Navigate(new TurmasView() { DataContext = new TurmasViewModel() });

		#region Functions Wizard
		/// <summary>
		/// Navega à próxima page do Wizard.
		/// </summary>
		/// <param name="parameter"></param>
		private void Next(object parameter)
		{
			Mouse.OverrideCursor = Cursors.Wait;
			switch (Navigator.WizardNavigationService.Content.ToString())
			{
				default: break;
			}
			Mouse.OverrideCursor = Cursors.Arrow;
		}
		/// <summary>
		/// Navega à page anterior do Wizard.
		/// </summary>
		/// <param name="parameter"></param>
		private void Back(object parameter)
		{
			Mouse.OverrideCursor = Cursors.Wait;
			if (Navigator.WizardNavigationService.CanGoBack)
			{
				Navigator.WizardNavigationService.GoBack();
				switch (Navigator.WizardNavigationService.Content.ToString())
				{
					default: break;
				}
			}
			Mouse.OverrideCursor = Cursors.Arrow;
		}
		/// <summary>
		/// Cancela e desfaz as operações do Wizard.
		/// </summary>
		/// <param name="parameter"></param>
		private void Cancel(object parameter)
		{
			Mouse.OverrideCursor = Cursors.Wait;
			//SetProperties();
			Mouse.OverrideCursor = Cursors.Arrow;
		}
		/// <summary>
		/// Salva as operações do Wizard
		/// </summary>
		/// <param name="parameter"></param>
		private void Save(object parameter)
		{
			Mouse.OverrideCursor = Cursors.Wait;
			string wizard = Navigator.WizardNavigationService.Content.ToString();
			switch (wizard)
			{
				default: break;
			}
			Mouse.OverrideCursor = Cursors.Arrow;
			//AppStatus.StopAppStatus();
		}
		#endregion

		#region Ribbon Cadastro
		/// <summary>
		/// Exclui o registro selecionado.
		/// </summary>
		/// <param name="parameter"></param>
		private void Delete(object parameter)
		{
			GetCurrentPageDataContext().Delete();
		}

		/// <summary>
		/// Inicia o Wizard para inclusão de novo registro.
		/// </summary>
		/// <param name="parameter"></param>
		private void Add(object parameter)
		{
			//SetProperties(_zIndex: 2, _wizColumnCancel: 60, _wizColumnNext: 60);
			switch (Navigator.NavigationService.Content.ToString())
			{
				case ("ControleDeAulas.View.ProfessoresView"):
					Navigator.WizardNavigationService.Navigate(new View.Wizard.WizCadProfessorView() { DataContext = new Wizard.WizCadProfessorViewModel(Base_) });
					break;
			}
		}
		#endregion		
		#endregion
	}
}