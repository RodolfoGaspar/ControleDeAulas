using ControleDeAulas.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.Model
{
	public class Falta
	{
		private IFalta _falta;

		public Professor Professor { get; set; }	
		public DateTime Data { get; set; }
		public Disciplina Disciplina { get; set; }
		public Turma Turma { get; set; }
		public int NFaltas { get; set; }
		public Professor ProfSubs { get; set; }
		public int NAulasSubs { get; set; }

		public Falta(IFalta f)
		{
			_falta = f;
			Data = DateTime.Now.AddDays(-1);
		}

		public List<Falta> Get()
		{ return _falta.Get(); }
	}
}
