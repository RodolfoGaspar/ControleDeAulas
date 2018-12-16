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

namespace ControleDeAulas.ViewModel.Wizard
{
	public class WizCadBoletimProfViewModel : BaseViewModel
	{
		public RelayCommand UpdateDateCommand { get; set; }

		public ObservableCollection<TurmaFalta> Turmas { get; set; }
		public ObservableCollection<Falta> Faltas { get; set; }
		public List<Disciplina> Disciplinas { get; set; }
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


		public WizCadBoletimProfViewModel(Falta falta, BaseSingleton baseSingleton)
		{
			Falta = falta;
			Base_ = baseSingleton;

			FillCollections();
			SetProperties();
		}

		public WizCadBoletimProfViewModel(BaseSingleton baseSingleton)
		{
			Falta = new AppFactory().NewFalta();
			Base_ = baseSingleton;

			FillCollections();
			SetProperties();
		}

		private void FillCollections()
		{
			Turmas = new ObservableCollection<TurmaFalta>(new AppFactory().NewTurmaFalta.Get());
			Faltas = new ObservableCollection<Falta>();

			Disciplinas = new List<Disciplina>();
			Disciplinas.AddRange(new AppFactory().NewDisciplina().Get());

			Professores = new List<Professor>();
			Professores.AddRange(new AppFactory().NewProfessor().Get(1));
		}

		private void SetProperties()
		{
			UpdateDate(new object());
			UpdateDateCommand = new RelayCommand(UpdateDate);
			Base_.SetProperties(_zIndex: 2, _wizColumnCancel: 60, _lblColumnCancel: "Cancelar", _wizColumnFinish: 60, _lblColumnFinish: "Salvar");
		}

		private void UpdateDate(object parameter)
		{
			DiaDaSemana = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Falta.Data.ToString("dddd", new CultureInfo("pt-BR")));
		}
	}
}
