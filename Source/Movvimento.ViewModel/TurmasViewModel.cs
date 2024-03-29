﻿using ControleDeAulas.Factory;
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
	public class TurmasViewModel
	{
		public ObservableCollection<Turma> Turmas { get; private set; }
		public Turma Turm { get; private set; }

		public TurmasViewModel()
		{
			Turm = new AppFactory().NewTurma();

			AppRibbon.SetFocus("tabOperacoesCadastro");

			FillCollection();
		}

		private void FillCollection()
		{
			Turmas = new ObservableCollection<Turma>(Turm.Get());
		}
	}
}
