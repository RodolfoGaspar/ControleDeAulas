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
	public class BoletimDiarioViewModel : BaseViewModel
	{
		public ObservableCollection<Falta> Faltas { get; private set; }
		public Falta Falta { get; set; }

		public BoletimDiarioViewModel(BaseSingleton baseSingleton)
		{
			Base_ = baseSingleton;
			Falta = new AppFactory().NewFalta();

			MouseDoubleClickCommand = new RelayCommand(CurrentCellSelected);
			AppRibbon.SetFocus("tabOperacoesCadastro");

			FillCollection();
		}

		private void FillCollection()
		{
			Faltas = new ObservableCollection<Falta>(Falta.Get());
		}

		private void CurrentCellSelected(object paramenter)
		{
			if (SelectedItem != null)
			{
				Navigator.WizardNavigationService.Navigate(new View.Wizard.WizAltBoletimProfView() { DataContext = new Wizard.WizAltBoletimProfViewModel(SelectedItem, Base_) });
			}
		}
	}
}
