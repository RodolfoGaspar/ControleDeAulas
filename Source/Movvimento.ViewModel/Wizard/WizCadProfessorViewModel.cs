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
		}

		public void Save()
		{ }
		
	}
}
