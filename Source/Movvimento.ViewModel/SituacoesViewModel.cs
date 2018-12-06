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
	public class SituacoesViewModel
	{
		public ObservableCollection<Situacao> Situacoes { get; private set; }
		public Situacao Sit { get; private set; }

		public SituacoesViewModel()
		{
			Sit = new AppFactory().NewSituacao();

			AppRibbon.SetFocus("tabOperacoesCadastro");

			FillCollection();
		}

		private void FillCollection()
		{
			Situacoes = new ObservableCollection<Situacao>(Sit.Get());
		}
	}
}
