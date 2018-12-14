using ControleDeAulas.Factory;
using ControleDeAulas.Helpers;
using ControleDeAulas.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.ViewModel
{
	public class ProfessoresViewModel : BaseViewModel
	{
		public ObservableCollection<Professor> Professores { get; private set; }
		public Professor Prof { get; private set; }

		public ProfessoresViewModel(BaseSingleton baseSingleton)
		{
			Base_ = baseSingleton;

			MouseDoubleClickCommand = new RelayCommand(CurrentCellSelected);
			Prof = new AppFactory().NewProfessor();

			AppRibbon.SetFocus("tabOperacoesCadastro");

			FillCollection();
		}


		private void FillCollection()
		{
			Professores = new ObservableCollection<Professor>(Prof.Get());
		}

		private void CurrentCellSelected(object obj)
		{
			if (Prof != null)
			{
				Navigator.WizardNavigationService.Navigate(new View.Wizard.WizCadProfessorView() { DataContext = new Wizard.WizCadProfessorViewModel(Prof, Base_) });
			}
		}
	}
}
