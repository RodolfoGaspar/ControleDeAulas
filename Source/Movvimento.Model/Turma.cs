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

		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }

		public Turma(ITurma t)
		{
			_turma = t;
		}

		public List<Turma> Get()
		{
			var turmas = new List<Turma>();
			turmas.AddRange(_turma.Get());

			return turmas;
		}
	}
}
