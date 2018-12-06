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
	public class FaixasViewModel
	{
		public ObservableCollection<Faixa> Faixas { get; private set; }
		public Faixa Fxa { get; private set; }

		public FaixasViewModel()
		{
			Fxa = new AppFactory().NewFaixa();

			AppRibbon.SetFocus("tabOperacoesCadastro");

			FillCollection();
		}

		private void FillCollection()
		{
			Faixas = new ObservableCollection<Faixa>(Fxa.Get());
		}
	}
}
