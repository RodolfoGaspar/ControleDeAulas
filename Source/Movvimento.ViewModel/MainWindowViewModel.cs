using ControleDeAulas.Helpers;
using ControleDeAulas.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		#endregion

		#region Constructors
		public MainWindowViewModel()
        {
			SetProperties();

			ListProfCommand = new RelayCommand(ListProf);

		}
		#endregion

		#region Functions
		private void ListProf(object parameters)
		{
			Navigator.NavigationService.Navigate(new ProfessoresView() { DataContext = new ProfessoresViewModel() });
		}

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