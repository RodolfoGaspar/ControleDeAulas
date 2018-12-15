using ControleDeAulas.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.ViewModel
{
	public sealed class BaseSingleton : BaseViewModel
	{
		static BaseSingleton instance = null;
		public BaseSingleton() { }
		public static BaseSingleton Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new BaseSingleton();
				}
				return instance;
			}
		}
				
		private string zIndex;
		/// <summary>
		/// Define a ancoragem do Wizard (Exibe ou Oculta o Wizard).
		/// </summary>
		public string ZIndex
		{
			get { return zIndex; }
			set
			{
				if (zIndex != value)
				{
					zIndex = value;
					RaisePropertyChanged("ZIndex");
				}
			}
		}

		private string wizRightColumnCancel;
		/// <summary>
		/// Define a largura da coluna à direita do botão Cancelar e sua visibilidade.
		/// </summary>
		public string WizRightColumnCancel
		{
			get { return wizRightColumnCancel; }
			set
			{
				if (wizRightColumnCancel != value)
				{
					wizRightColumnCancel = value;
					RaisePropertyChanged("WizRightColumnCancel");
				}
			}
		}

		private string wizColumnCancel;
		/// <summary>
		/// Define a largura da coluna do botão Cancel e sua visibilidade.
		/// </summary>
		public string WizColumnCancel
		{
			get { return wizColumnCancel; }
			set
			{
				if (wizColumnCancel != value)
				{
					wizColumnCancel = value;
					RaisePropertyChanged("WizColumnCancel");
				}
			}
		}

		private string lblColumnCancel;
		/// <summary>
		/// Define o label do botão Cancel.
		/// </summary>
		public string LblColumnCancel
		{
			get { return lblColumnCancel; }
			set
			{
				if (lblColumnCancel != value)
				{
					lblColumnCancel = value;
					RaisePropertyChanged("LblColumnCancel");
				}
			}
		}

		private string wizRightColumnBack;
		/// <summary>
		/// Define a largura da coluna à direita do botão Voltar e sua visibilidade.
		/// </summary>
		public string WizRightColumnBack
		{
			get { return wizRightColumnBack; }
			set
			{
				if (wizRightColumnBack != value)
				{
					wizRightColumnBack = value;
					RaisePropertyChanged("WizRightColumnBack");
				}
			}
		}

		private string wizColumnBack;
		/// <summary>
		/// Define a largura da coluna do botão Voltar e sua visibilidade.
		/// </summary>
		public string WizColumnBack
		{
			get { return wizColumnBack; }
			set
			{
				if (wizColumnBack != value)
				{
					wizColumnBack = value;
					RaisePropertyChanged("WizColumnBack");
				}
			}
		}

		private string lblColumnBack;
		/// <summary>
		/// Define o label do botão Voltar.
		/// </summary>
		public string LblColumnBack
		{
			get { return lblColumnBack; }
			set
			{
				if (lblColumnBack != value)
				{
					lblColumnBack = value;
					RaisePropertyChanged("LblColumnBack");
				}
			}
		}

		private string wizRightColumnNext;
		/// <summary>
		/// Define a largura da coluna à direita do botão Próximo e sua visibilidade.
		/// </summary>
		public string WizRightColumnNext
		{
			get { return wizRightColumnNext; }
			set
			{
				if (wizRightColumnNext != value)
				{
					wizRightColumnNext = value;
					RaisePropertyChanged("WizRightColumnNext");
				}
			}
		}

		private string wizColumnNext;
		/// <summary>
		/// Define a largura da coluna do botão Próximo e sua visibilidade.
		/// </summary>
		public string WizColumnNext
		{
			get { return wizColumnNext; }
			set
			{
				if (wizColumnNext != value)
				{
					wizColumnNext = value;
					RaisePropertyChanged("WizColumnNext");
				}
			}
		}

		private string lblColumnNext;
		/// <summary>
		/// Define o label do botão Próximo e sua visibilidade.
		/// </summary>
		public string LblColumnNext
		{
			get { return lblColumnNext; }
			set
			{
				if (lblColumnNext != value)
				{
					lblColumnNext = value;
					RaisePropertyChanged("LblColumnNext");
				}
			}
		}

		private string wizRightColumnFinish;
		/// <summary>
		/// Define a largura da coluna à direita do botão Concluir e sua visibilidade.
		/// </summary>
		public string WizRightColumnFinish
		{
			get { return wizRightColumnFinish; }
			set
			{
				if (wizRightColumnFinish != value)
				{
					wizRightColumnFinish = value;
					RaisePropertyChanged("WizRightColumnFinish");
				}
			}
		}

		private string wizColumnFinish;
		/// <summary>
		/// Define a largura da coluna do botão Concluir e sua visibilidade.
		/// </summary>
		public string WizColumnFinish
		{
			get { return wizColumnFinish; }
			set
			{
				if (wizColumnFinish != value)
				{
					wizColumnFinish = value;
					RaisePropertyChanged("WizColumnFinish");
				}
			}
		}

		private string lblColumnFinish;
		/// <summary>
		/// Define o label do botão Concluir e sua visibilidade.
		/// </summary>
		public string LblColumnFinish
		{
			get { return lblColumnFinish; }
			set
			{
				if (lblColumnFinish != value)
				{
					lblColumnFinish = value;
					RaisePropertyChanged("LblColumnFinish");
				}
			}
		}

		private string headerWizard;
		/// <summary>
		/// Define o Título do Wizard.
		/// </summary>
		public string HeaderWizard
		{
			get { return headerWizard; }
			set
			{
				if (headerWizard != value)
				{
					headerWizard = value;
					RaisePropertyChanged("HeaderWizard");
				}
			}
		}

		/// <summary>
		/// Manipula as propriedades do Wizard e atualiza a Ribbon.
		/// </summary>
		/// <param name="_zIndex">Exibe ou oculta o Wizard.</param>
		/// <param name="_wizColumnCancel">Largura da coluna do botão Cancel.</param>
		/// <param name="_wizColumnBack">Largura da coluna do botão Voltar.</param>
		/// <param name="_wizColumnNext">Largura da coluna do botão Próximo.</param>
		/// <param name="_wizColumnFinish">Largura da coluna do botão Concluir.</param>
		public void SetProperties(int _zIndex = -1,
								  int _wizColumnCancel = 0, string _lblColumnCancel = "Cancelar",
								  int _wizColumnBack = 0, string _lblColumnBack = "Voltar",
								  int _wizColumnNext = 0, string _lblColumnNext = "Próximo",
								  int _wizColumnFinish = 0, string _lblColumnFinish = "Concluir",
								  bool isEnabled = true)
		{
			ZIndex = _zIndex.ToString();

			LblColumnCancel = _lblColumnCancel;
			LblColumnBack = _lblColumnBack;
			LblColumnNext = _lblColumnNext;
			LblColumnFinish = _lblColumnFinish;

			WizColumnBack = _wizColumnBack.ToString();
			if (_wizColumnBack > 0)
			{ WizRightColumnBack = "5"; }
			else
			{ WizRightColumnBack = "0"; }

			WizColumnCancel = _wizColumnCancel.ToString();
			if (_wizColumnCancel > 0)
			{ WizRightColumnCancel = "5"; }
			else
			{ WizRightColumnCancel = "0"; }

			WizColumnNext = _wizColumnNext.ToString();
			if (_wizColumnNext > 0)
			{ WizRightColumnNext = "5"; }
			else
			{ WizRightColumnNext = "0"; }

			WizColumnFinish = _wizColumnFinish.ToString();
			if (_wizColumnFinish > 0)
			{ WizRightColumnFinish = "5"; }
			else
			{ WizRightColumnFinish = "0"; }

			//if (AppStatus.TextUsuario != null) ManagerView(AppStatus.TextUsuario.Content.ToString());
			//AppRibbon.SetVisibility("tabOperacoesCadastro", Visibility.Collapsed);
			//if (isEnabled) AppRibbon.SetEnable("AllRibbonElements");
		}
	}
}
