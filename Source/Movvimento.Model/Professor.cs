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
		private IFaixa _faixa;
		private INivel _nivel;
		private ISituacao _situacao;
		private ICategoria _categoria;
		private IDisciplina _disciplina;

		public List<Professor> Professores { get; private set; }
		public int Id { get; set; }
		public string Nome { get; set; }
		public string RG { get; set; }
		public int IdCategoria { get; set; }
		public int IdDisciplina { get; set; }
		public int IdFaixa { get; set; }
		public int IdNivel { get; set; }
		public string FaixaNivel { get { return $"{IdFaixa}{IdNivel}"; } }
		public int IdSituacao { get; set; }

		public Professor(IProfessor p, IFaixa f, INivel n, ISituacao s, ICategoria c, IDisciplina d)
		{
			_professor = p;
			_faixa = f;
			_nivel = n;
			_situacao = s;
			_categoria = c;
			_disciplina = d;

			Professores = new List<Professor>();
		}


		public List<Professor> Get()
		{
			Professores.AddRange(_professor.Get());

			return Professores;
		}
	}
}
