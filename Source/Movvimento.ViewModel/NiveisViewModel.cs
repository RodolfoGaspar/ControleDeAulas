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
	public class NiveisViewModel
	{
		public ObservableCollection<Nivel> Niveis { get; private set; }
		public Nivel Niv { get; private set; }

		public NiveisViewModel()
		{
			Niv = new AppFactory().NewNivel();

			AppRibbon.SetFocus("tabOperacoesCadastro");

			FillCollection();
		}

		private void FillCollection()
		{
			Niveis = new ObservableCollection<Nivel>(Niv.Get());
		}
	}
}
