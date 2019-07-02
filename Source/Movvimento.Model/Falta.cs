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
						
			SetData();
		}

		private void SetData()
		{
			switch (DateTime.Now.DayOfWeek)
			{
				case DayOfWeek.Sunday: Data = DateTime.Now.AddDays(-2); break;
				case DayOfWeek.Monday: Data = DateTime.Now.AddDays(-3); break;
				default: Data = DateTime.Now.AddDays(-1); break;
			}
		}

		public List<Falta> Get()
		{ return _falta.Get(); }

		public bool Add(List<Falta> faltas)
		{
			return _falta.Add(faltas);
		}
	}
}
