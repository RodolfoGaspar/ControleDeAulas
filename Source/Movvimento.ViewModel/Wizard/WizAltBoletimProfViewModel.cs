using ControleDeAulas.Factory;
using ControleDeAulas.Helpers;
using ControleDeAulas.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ControleDeAulas.ViewModel.Wizard
{
	public class WizAltBoletimProfViewModel : BaseViewModel
	{
		private ObservableCollection<TurmaFalta> turmas;

		public ObservableCollection<TurmaFalta> Turmas
		{
			get { return turmas; }
			set
			{
				if (turmas != value)
				{
					turmas = value;
					RaisePropertyChanged("Turmas");
				}
			}
		}

		private ObservableCollection<Disciplina> disciplinas;

		public ObservableCollection<Disciplina> Disciplinas
		{
			get { return disciplinas; }
			set
			{
				if (disciplinas != value)
				{
					disciplinas = value;
					RaisePropertyChanged("Disciplinas");
				}
			}
		}

		public List<Professor> Professores { get; set; }

		private string diaDaSemana;

		public string DiaDaSemana
		{
			get { return diaDaSemana; }
			set
			{
				if (diaDaSemana != value && !string.IsNullOrEmpty(value))
				{
					diaDaSemana = value;
					RaisePropertyChanged("DiaDaSemana");
				}
			}
		}

		private Falta falta;

		public Falta Falta
		{
			get { return falta; }
			set
			{
				if (falta != value)
				{
					falta = value;
					RaisePropertyChanged("Falta");
				}
			}
		}

		public WizAltBoletimProfViewModel(Falta falta, BaseSingleton baseSingleton)
		{
			Falta = falta;
			Base_ = baseSingleton;

			Turmas = new ObservableCollection<TurmaFalta>();
			var t = new AppFactory().NewTurmaFalta();
			t.Turma = falta.Turma;
			t.Falta.NFaltas = falta.NFaltas;
			t.Professores = new AppFactory().NewProfessor().Get(2);
			t.Professor = falta.ProfSubs;
			t.Falta.NAulasSubs = falta.NAulasSubs;
			t.Selected = true;


			Turmas.Add(t);

			SetProperties();

			Base_.HeaderWizard = "Alteração de Falta de Professor";
		}

		private void SetProperties()
		{
			DiaDaSemana = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Falta.Data.ToString("dddd", new CultureInfo("pt-BR")));
			Base_.SetProperties(_zIndex: 2, _wizColumnCancel: 60, _lblColumnCancel: "Cancelar", _wizColumnFinish: 60, _lblColumnFinish: "Salvar");
		}

	}
}
