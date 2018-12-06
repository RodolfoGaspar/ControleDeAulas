using ControleDeAulas.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.Model
{
	public class Situacao
	{
		private ISituacao _situacao;

		public List<Situacao> Situacoes { get; set; }
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }

		public Situacao(ISituacao s)
		{
			_situacao = s;

			Situacoes = new List<Situacao>();
		}

		public List<Situacao> Get()
		{
			Situacoes.AddRange(_situacao.Get());

			return Situacoes;
		}
	}
}
