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
		#region Properties
		private string _zIndex;
		/// <summary>
		/// Define a ancoragem do Wizard (Exibe ou Oculta o Wizard).
		/// </summary>
		public string zIndex
		{
			get { return _zIndex; }
			set
			{
				if (_zIndex != value)
				{
					_zIndex = value;
					RaisePropertyChanged("zIndex");
				}
			}
		}

		private string _wizRightColumnCancel;
		/// <summary>
		/// Define a largura da coluna à direita do botão Cancelar e sua visibilidade.
		/// </summary>
		public string wizRightColumnCancel
		{
			get { return _wizRightColumnCancel; }
			set
			{
				if (_wizRightColumnCancel != value)
				{
					_wizRightColumnCancel = value;
					RaisePropertyChanged("wizRightColumnCancel");
				}
			}
		}

		private string _wizColumnCancel;
		/// <summary>
		/// Define a largura da coluna do botão Cancel e sua visibilidade.
		/// </summary>
		public string wizColumnCancel
		{
			get { return _wizColumnCancel; }
			set
			{
				if (_wizColumnCancel != value)
				{
					_wizColumnCancel = value;
					RaisePropertyChanged("wizColumnCancel");
				}
			}
		}

		private string _wizRightColumnBack;
		/// <summary>
		/// Define a largura da coluna à direita do botão Voltar e sua visibilidade.
		/// </summary>
		public string wizRightColumnBack
		{
			get { return _wizRightColumnBack; }
			set
			{
				if (_wizRightColumnBack != value)
				{
					_wizRightColumnBack = value;
					RaisePropertyChanged("wizRightColumnBack");
				}
			}
		}

		private string _wizColumnBack;
		/// <summary>
		/// Define a largura da coluna do botão Voltar e sua visibilidade.
		/// </summary>
		public string wizColumnBack
		{
			get { return _wizColumnBack; }
			set
			{
				if (_wizColumnBack != value)
				{
					_wizColumnBack = value;
					RaisePropertyChanged("wizColumnBack");
				}
			}
		}

		private string _wizRightColumnNext;
		/// <summary>
		/// Define a largura da coluna à direita do botão Próximo e sua visibilidade.
		/// </summary>
		public string wizRightColumnNext
		{
			get { return _wizRightColumnNext; }
			set
			{
				if (_wizRightColumnNext != value)
				{
					_wizRightColumnNext = value;
					RaisePropertyChanged("wizRightColumnNext");
				}
			}
		}

		private string _wizColumnNext;
		/// <summary>
		/// Define a largura da coluna do botão Próximo e sua visibilidade.
		/// </summary>
		public string wizColumnNext
		{
			get { return _wizColumnNext; }
			set
			{
				if (_wizColumnNext != value)
				{
					_wizColumnNext = value;
					RaisePropertyChanged("wizColumnNext");
				}
			}
		}

		private string _wizRightColumnFinish;
		/// <summary>
		/// Define a largura da coluna à direita do botão Concluir e sua visibilidade.
		/// </summary>
		public string wizRightColumnFinish
		{
			get { return _wizRightColumnFinish; }
			set
			{
				if (_wizRightColumnFinish != value)
				{
					_wizRightColumnFinish = value;
					RaisePropertyChanged("wizRightColumnFinish");
				}
			}
		}

		private string _wizColumnFinish;
		/// <summary>
		/// Define a largura da coluna do botão Concluir e sua visibilidade.
		/// </summary>
		public string wizColumnFinish
		{
			get { return _wizColumnFinish; }
			set
			{
				if (_wizColumnFinish != value)
				{
					_wizColumnFinish = value;
					RaisePropertyChanged("wizColumnFinish");
				}
			}
		}

		private string _headerWizard;
		/// <summary>
		/// Define o Título do Wizard.
		/// </summary>
		public string headerWizard
		{
			get { return _headerWizard; }
			set
			{
				if (_headerWizard != value)
				{
					_headerWizard = value;
					RaisePropertyChanged("headerWizard");
				}
			}
		}
		#endregion

		#region RelayCommands
		#region Wizard
		/// <summary>
		/// Command do botão Cancel do Wizard.
		/// </summary>
		public RelayCommand wizCancelCommand { get; set; }
		/// <summary>
		/// Command do botão Voltar do Wizard.
		/// </summary>
		public RelayCommand wizBackCommand { get; set; }
		/// <summary>
		/// Command do botão Próximo do Wizard.
		/// </summary>
		public RelayCommand wixNextCommand { get; set; }
		/// <summary>
		/// Command do botão Concluir do Wizard.
		/// </summary>
		public RelayCommand wizFinishCommand { get; set; }
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
		public MainWindowViewModel()
		{
			SetProperties();

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

			wizFinishCommand = new RelayCommand(Save);
			wizCancelCommand = new RelayCommand(Cancel);
			wizBackCommand = new RelayCommand(Back);
			wixNextCommand = new RelayCommand(Next);
		}
		#endregion

		#region Functions
		private void ListProf(object parameters) => Navigator.NavigationService.Navigate(new ProfessoresView() { DataContext = new ProfessoresViewModel() });

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
			SetProperties();
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
			SetProperties(_zIndex: 2, _wizColumnCancel: 60, _wizColumnNext: 60);
			switch (Navigator.NavigationService.Content.ToString())
			{
				case ("ControleDeAulas.View.ProfessoresView"):
					Navigator.WizardNavigationService.Navigate(new View.Wizard.WizCadProfessorView() { DataContext = new Wizard.WizCadProfessorViewModel() });
					break;
			}
		}
		#endregion

		/// <summary>
		/// Manipula as propriedades do Wizard e atualiza a Ribbon.
		/// </summary>
		/// <param name="_zIndex">Exibe ou oculta o Wizard.</param>
		/// <param name="_wizColumnCancel">Largura da coluna do botão Cancel.</param>
		/// <param name="_wizColumnBack">Largura da coluna do botão Voltar.</param>
		/// <param name="_wizColumnNext">Largura da coluna do botão Próximo.</param>
		/// <param name="_wizColumnFinish">Largura da coluna do botão Concluir.</param>
		public void SetProperties(int _zIndex = -1, int _wizColumnCancel = 0, int _wizColumnBack = 0, int _wizColumnNext = 0, int _wizColumnFinish = 0, bool isEnabled = true)
		{
			zIndex = _zIndex.ToString();

			wizColumnBack = _wizColumnBack.ToString();
			if (_wizColumnBack > 0)
			{ wizRightColumnBack = "5"; }
			else
			{ wizRightColumnBack = "0"; }

			wizColumnCancel = _wizColumnCancel.ToString();
			if (_wizColumnCancel > 0)
			{ wizRightColumnCancel = "5"; }
			else
			{ wizRightColumnCancel = "0"; }

			wizColumnNext = _wizColumnNext.ToString();
			if (_wizColumnNext > 0)
			{ wizRightColumnNext = "5"; }
			else
			{ wizRightColumnNext = "0"; }

			wizColumnFinish = _wizColumnFinish.ToString();
			if (_wizColumnFinish > 0)
			{ wizRightColumnFinish = "5"; }
			else
			{ wizRightColumnFinish = "0"; }

			//if (AppStatus.TextUsuario != null) ManagerView(AppStatus.TextUsuario.Content.ToString());
			//AppRibbon.SetVisibility("tabOperacoesCadastro", Visibility.Collapsed);
			//if (isEnabled) AppRibbon.SetEnable("AllRibbonElements");
		}
		#endregion
	}
}