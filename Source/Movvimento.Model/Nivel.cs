using ControleDeAulas.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.Model
{
	public class Nivel
	{
		private INivel _nivel;

		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }

		public Nivel(INivel n)
		{
			_nivel = n;
		}

		public List<Nivel> Get()
		{
			var niveis = new List<Nivel>();
			niveis.AddRange(_nivel.Get());

			return niveis;
		}
	}
}
