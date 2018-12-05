using ControleDeAulas.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.Model
{
	public class Professor
	{
		private IProfessor _professor;

		public List<Professor> Professores { get; private set; }
		public int Id { get; set; }
		public string Nome { get; set; }
		public string RG { get; set; }
		public string Fn { get; set; }
		public int IdCategoria { get; set; }
		public int IdStatus { get; set; }
		public int IdDisciplina { get; set; }

		public Professor(IProfessor p)
		{
			_professor = p;

			Professores = new List<Professor>();
		}


		public List<Professor> Get()
		{
			Professores.AddRange(_professor.Get());

			return Professores;
		}
	}
}
