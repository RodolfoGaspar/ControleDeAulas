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
	public class ProfessoresViewModel
	{
		public ObservableCollection<Professor> Professores { get; private set; }
		public Professor Prof { get; private set; }

		public ProfessoresViewModel()
		{
			Prof = new AppFactory().NewProfessor();

			AppRibbon.SetFocus("tabOperacoesCadastro");

			FillCollection();
		}

		private void FillCollection()
		{
			Professores = new ObservableCollection<Professor>(Prof.Get());
		}
	}
}
