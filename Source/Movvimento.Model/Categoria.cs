using ControleDeAulas.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.Model
{
	public class Categoria
	{
		private ICategoria _categoria;
				
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }

		public Categoria(ICategoria c)
		{
			_categoria = c;
		}

		public List<Categoria> Get()
		{
			var categorias = new List<Categoria>();
			categorias.AddRange(_categoria.Get());

			return categorias;
		}
	}
}
