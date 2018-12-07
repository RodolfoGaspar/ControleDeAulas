using ControleDeAulas.Factory;
using ControleDeAulas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.ViewModel.Wizard
{
	public class WizCadProfessorViewModel : BaseViewModel
	{
		public Professor Prof { get; private set; }
		public List<Faixa> Faixas { get; set; }
		public List<Nivel> Niveis { get; set; }
		public List<Situacao> Situacoes { get; set; }
		public List<Categoria> Categorias { get; set; }
		public List<Disciplina> Disciplinas { get; set; }

		public WizCadProfessorViewModel()
		{
			Prof = new AppFactory().NewProfessor();
			FillCollections();
			SetProperties();
		}
				
		public WizCadProfessorViewModel(Professor prof)
		{
			Prof = prof;
			FillCollections();
			SetProperties();
		}

		private void FillCollections()
		{
			Faixas = new List<Faixa>();
			Niveis = new List<Nivel>();
			Situacoes = new List<Situacao>();
			Categorias = new List<Categoria>();

			Faixas.AddRange(new AppFactory().NewFaixa().Get());
			Niveis.AddRange(new AppFactory().NewNivel().Get());
			Situacoes.AddRange(new AppFactory().NewSituacao().Get());
			Categorias.AddRange(new AppFactory().NewCategoria().Get());
		}

		private void SetProperties()
		{
			SetProperties(_zIndex: 2, _wizColumnCancel: 60, _wizColumnFinish:60, _lblColumnFinish: "Salvar");
		}


		public void Save()
		{ }
		
	}
}
