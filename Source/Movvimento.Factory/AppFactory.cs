using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeAulas.Model;

namespace ControleDeAulas.Factory
{
	public class AppFactory
	{
		public Professor NewProfessor()
		{
			return new Professor(new DataAccess.Professor(), new DataAccess.Faixa(), 
								 new DataAccess.Nivel(), new DataAccess.Situacao(), 
								 new DataAccess.Categoria(), new DataAccess.Disciplina());
		}

		public Faixa NewFaixa() => new Faixa(new DataAccess.Faixa());

		public Nivel NewNivel() => new Nivel(new DataAccess.Nivel());

		public Situacao NewSituacao() => new Situacao(new DataAccess.Situacao());

		public Categoria NewCategoria() => new Categoria(new DataAccess.Categoria());

		public Disciplina NewDisciplina() => new Disciplina(new DataAccess.Disciplina());

		public Turma NewTurma() => new Turma(new DataAccess.Turma());
	}
}
