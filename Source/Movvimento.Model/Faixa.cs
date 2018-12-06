using ControleDeAulas.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.Model
{
	public class Faixa
	{
		private IFaixa _faixa;

		public List<Faixa> Faixas { get; set; }
		public int Id { get; set; }
		public string NFaixa { get; set; }
		public string Descricao { get; set; }

		public Faixa(IFaixa f)
		{
			_faixa = f;

			Faixas = new List<Faixa>();
		}

		public List<Faixa> Get()
		{
			Faixas.AddRange(_faixa.Get());

			return Faixas;
		}
	}
}
