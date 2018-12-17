using ControleDeAulas.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.Model
{
	public class TurmaFalta
	{
		private ITurma _turma;
		private IFalta _falta;
		private IProfessor _professor;

		public bool Selected { get; set; }
		public Turma Turma { get; set; }
		public Falta Falta { get; set; }
		public Professor Professor { get; set; }
		public Disciplina Disciplina { get; set; }
		public List<Professor> Professores { get; set; }
		public List<Professor> Substitutos { get; private set; }

		public TurmaFalta(ITurma t, IFalta f, IProfessor p)
		{
			_turma = t;
			_falta = f;
			_professor = p;

			Turma = new Turma(t);
			Falta = new Falta(f);

			Professores = new List<Professor>();
		}

		public List<TurmaFalta> Get()
		{
			var list = new List<TurmaFalta>();

			SetSubstitutos();

			foreach (var t in _turma.Get())
			{
				var tf = new TurmaFalta(_turma, _falta, _professor);
				tf.Turma.Nome = t.Nome;
				tf.Professores.AddRange(Substitutos);
				list.Add(tf);
			}

			return list;
		}

		public List<TurmaFalta> Get(Professor p, Disciplina d, DayOfWeek dw)
		{
			var list = new List<TurmaFalta>();

			if (p != null && d != null)
			{
				SetSubstitutos();
				var turmas = _turma.Get(p, d, dw);

				foreach (var t in turmas)
				{
					if (!list.Where(l => l.Turma.Id == t.Id).Any())
					{
						var tf = new TurmaFalta(_turma, _falta, _professor);
						tf.Turma.Id = t.Id;
						tf.Turma.Nome = t.Nome;
						tf.Falta.NFaltas = turmas.Count();
						tf.Professores.AddRange(Substitutos);
						list.Add(tf);
					}
				}
			}

			return list;
		}

		private void SetSubstitutos()
		{
			Substitutos = new List<Professor>();
			Substitutos.AddRange(_professor.Get(2));
		}
	}
}
