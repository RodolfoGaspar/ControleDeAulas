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

		public Turma Turma { get; set; }
		public Falta Falta { get; set; }
		public Professor Professor { get; set; }
		public List<Professor> Professores { get; set; }

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
			var profs = new List<Professor>();

			profs.AddRange(_professor.Get(2));

			foreach (var t in _turma.Get())
			{
				var tf = new TurmaFalta(_turma, _falta, _professor);
				tf.Turma.Nome = t.Nome;
				tf.Professores.AddRange(profs);
				list.Add(tf);
			}

			return list;
		}
	}
}
