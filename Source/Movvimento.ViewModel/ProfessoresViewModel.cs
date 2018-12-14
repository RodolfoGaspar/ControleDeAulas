using ControleDeAulas.Factory;
using ControleDeAulas.Helpers;
using ControleDeAulas.Model;
using System.Collections.ObjectModel;

namespace ControleDeAulas.ViewModel
{
	public class ProfessoresViewModel : BaseViewModel
	{
		public ObservableCollection<Professor> Professores { get; private set; }
		public Professor Prof { get; set; }

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

		private void CurrentCellSelected(object paramenter)
		{
			if (SelectedItem != null)
			{
				Navigator.WizardNavigationService.Navigate(new View.Wizard.WizCadProfessorView() { DataContext = new Wizard.WizCadProfessorViewModel(SelectedItem, Base_) });
			}
		}
	}
}
