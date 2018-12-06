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

		public List<Nivel> Niveis { get; set; }
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }

		public Nivel(INivel n)
		{
			_nivel = n;

			Niveis = new List<Nivel>();
		}

		public List<Nivel> Get()
		{
			Niveis.AddRange(_nivel.Get());

			return Niveis;
		}
	}
}
