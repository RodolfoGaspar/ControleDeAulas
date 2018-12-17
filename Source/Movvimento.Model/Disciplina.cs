using ControleDeAulas.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.Model
{
	public class Disciplina
	{
		private IDisciplina _disciplina;

		public int Id { get; set; }
		public string Nome { get; set; }

		public Disciplina(IDisciplina d)
		{
			_disciplina = d;
		}

		public List<Disciplina> Get()
		{
			var disciplinas = new List<Disciplina>();
			disciplinas.AddRange(_disciplina.Get());

			return disciplinas;
		}

		public List<Disciplina> Get(Professor p)
		{
			var disciplinas = new List<Disciplina>();
			disciplinas.AddRange(_disciplina.Get(p));

			return disciplinas;
		}
	}
}
