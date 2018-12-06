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
	public class DisciplinasViewModel
	{
		public ObservableCollection<Disciplina> Disciplinas { get; private set; }
		public Disciplina Disc { get; private set; }

		public DisciplinasViewModel()
		{
			Disc = new AppFactory().NewDisciplina();

			AppRibbon.SetFocus("tabOperacoesCadastro");

			FillCollection();
		}

		private void FillCollection()
		{
			Disciplinas = new ObservableCollection<Disciplina>(Disc.Get());
		}
	}
}
