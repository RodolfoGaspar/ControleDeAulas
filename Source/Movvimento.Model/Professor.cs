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

		public int Id { get; set; }
		public string Nome { get; set; }
		public string RG { get; set; }
		public Faixa Faixa { get; set; }
		public Nivel Nivel { get; set; }
		public Situacao Situacao { get; set; }
		public Categoria Categoria { get; set; }
		public List<Disciplina> Disciplinas { get; set; }
		public string FaixaNivel { get { return $"{Faixa.NFaixa}{Nivel.Nome}"; } }

		public Professor(IProfessor p, IFaixa f, INivel n, ISituacao s, ICategoria c, IDisciplina d)
		{
			_professor = p;
			_faixa = f;
			_nivel = n;
			_situacao = s;
			_categoria = c;
			_disciplina = d;

			Disciplinas = new List<Disciplina>();

			Faixa = new Faixa(f);
			Nivel = new Nivel(n);
			Situacao = new Situacao(s);
			Categoria = new Categoria(c);
		}

		public List<Professor> Get(int categoria)
		{
			var professores = new List<Professor>();
			professores.AddRange(_professor.Get(categoria));
			professores.ForEach(p => { p.Disciplinas.AddRange(_disciplina.Get(p.Id)); });

			return professores;
		}

		public List<Professor> Get()
		{
			var professores = new List<Professor>();
			professores.AddRange(_professor.Get());
			professores.ForEach(p => { p.Disciplinas.AddRange(_disciplina.Get(p.Id)); });

			return professores;
		}
	}
}
