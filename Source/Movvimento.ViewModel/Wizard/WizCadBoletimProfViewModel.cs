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
	public class WizCadBoletimProfViewModel : BaseViewModel
	{
		public RelayCommand SelectionProfChangedCommand { get; set; }
		public RelayCommand SelectionDiscChangedCommand { get; private set; }
		public RelayCommand AddCommand { get; private set; }
		public RelayCommand UpdateDateCommand { get; set; }

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

		public ObservableCollection<Falta> Faltas { get; set; }

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

		private bool isEdit;

		public bool IsEdit
		{
			get { return isEdit; }
			set
			{
				if (isEdit != value)
				{
					isEdit = value;
					RaisePropertyChanged("IsEdit");
				}
			}
		}

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
			IsEdit = false;

			FillCollections();
			SetProperties();

			Base_.HeaderWizard = "Alteração de Falta de Professor";
		}

		public WizCadBoletimProfViewModel(BaseSingleton baseSingleton)
		{
			Falta = new AppFactory().NewFalta();
			Base_ = baseSingleton;
			IsEdit = true;

			FillCollections();
			SetProperties();

			Base_.HeaderWizard = "Lançamento de Faltas de Professor";			
		}

		private void SetProperties()
		{
			SelectionProfChangedCommand = new RelayCommand(SelectionProfChanged);
			SelectionDiscChangedCommand = new RelayCommand(SelectionDiscChanged);
			AddCommand = new RelayCommand(Add);
			UpdateDateCommand = new RelayCommand(UpdateDate);

			UpdateDate(new object());
			Base_.SetProperties(_zIndex: 2, _wizColumnCancel: 60, _lblColumnCancel: "Cancelar", _wizColumnFinish: 60, _lblColumnFinish: "Salvar");
		}

		private void Add(object parameter)
		{
			if (Turmas.Count(t => t.Selected) == 0)
			{ MessageBox.Show("Não há turmas selecionadas", "Alerta!", MessageBoxButton.OK, MessageBoxImage.Warning); }
			else
			{
				Turmas.ToList().ForEach(t =>
				{
					if (Faltas.Count(f => f.Turma.Id == t.Turma.Id && 
									 f.Disciplina.Id == Falta.Disciplina.Id && 
									 f.Data.Date == Falta.Data.Date) == 0)
					{
						var f = new AppFactory().NewFalta();
						f.Professor = Falta.Professor;
						f.Disciplina = Falta.Disciplina;
						f.Turma = t.Turma;
						f.Data = Falta.Data;
						f.NFaltas = t.Falta.NFaltas;
						f.ProfSubs = t.Professor;
						f.NAulasSubs = t.Falta.NAulasSubs;

						Faltas.Add(f);
					}
				});
			}
		}

		private void SelectionDiscChanged(object parameter)
		{
			Turmas = new ObservableCollection<TurmaFalta>(new AppFactory().NewTurmaFalta().Get(Falta.Professor, Falta.Disciplina, Falta.Data.DayOfWeek));
			if (GetCurrentWizardPage() != null) GetCurrentWizardPage().Turmas.Items.Refresh();
		}

		private void SelectionProfChanged(object parameter)
		{
			Disciplinas = new ObservableCollection<Disciplina>(new AppFactory().NewDisciplina().Get(Falta.Professor));
			if (GetCurrentWizardPage() != null) GetCurrentWizardPage().Disciplinas.Items.Refresh();
		}

		private void UpdateDate(object parameter)
		{
			DiaDaSemana = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Falta.Data.ToString("dddd", new CultureInfo("pt-BR")));
			SelectionDiscChanged(new object());
		}

		private void FillCollections()
		{
			Faltas = new ObservableCollection<Falta>();

			Professores = new List<Professor>();
			Professores.AddRange(new AppFactory().NewProfessor().Get(1));
		}


	}
}
