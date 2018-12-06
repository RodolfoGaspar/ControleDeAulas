using ControleDeAulas.Factory;
using ControleDeAulas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.ViewModel.Wizard
{
	public class WizCadProfessorViewModel
	{
		public Professor Prof { get; private set; }

		public WizCadProfessorViewModel()
		{
			Prof = new AppFactory().NewProfessor();

			Prof.IdCategoria = 1;
			Prof.IdDisciplina = 1;
			Prof.IdFaixa = 1;
			Prof.IdNivel = 1;
			Prof.IdNivel = 1;
		}

		public void Save()
		{ }
		
	}
}
