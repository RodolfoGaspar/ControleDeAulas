using ControleDeAulas.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.Model
{
	public class Turma
	{
		private ITurma _turma;

		public List<Turma> Turmas { get; set; }
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }

		public Turma(ITurma t)
		{
			_turma = t;

			Turmas = new List<Turma>();
		}

		public List<Turma> Get()
		{
			Turmas.AddRange(_turma.Get());

			return Turmas;
		}
	}
}
