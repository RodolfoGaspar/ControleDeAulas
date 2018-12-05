using ControleDeAulas.Factory;
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
		public Model.Professor professor { get; private set; }

		public ProfessoresViewModel()
		{
			professor = new AppFactory().NewProfessor();

			FillCollection();
		}

		private void FillCollection()
		{
			Professores = new ObservableCollection<Professor>(professor.Get());
		}
	}
}
