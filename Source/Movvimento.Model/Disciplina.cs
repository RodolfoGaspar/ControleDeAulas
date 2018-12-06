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

		public List<Disciplina> Disciplinas { get; set; }
		public int Id { get; set; }
		public string Nome { get; set; }

		public Disciplina(IDisciplina d)
		{
			_disciplina = d;

			Disciplinas = new List<Disciplina>();
		}

		public List<Disciplina> Get()
		{
			Disciplinas.AddRange(_disciplina.Get());

			return Disciplinas;
		}
	}
}
