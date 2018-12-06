using ControleDeAulas.Factory;
using ControleDeAulas.Helpers;
using ControleDeAulas.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.ViewModel
{
	public class CategoriasViewModel
	{
		public ObservableCollection<Categoria> Categorias { get; private set; }
		public Categoria Cat { get; private set; }

		public CategoriasViewModel()
		{
			Cat = new AppFactory().NewCategoria();

			AppRibbon.SetFocus("tabOperacoesCadastro");

			FillCollection();
		}

		private void FillCollection()
		{
			Categorias = new ObservableCollection<Categoria>(Cat.Get());
		}
	}
}
