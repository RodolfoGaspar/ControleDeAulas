using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.Model.Interfaces
{
	public interface ITurma
	{
		List<Turma> Get();
		List<Turma> Get(Professor p, Disciplina d, DayOfWeek dw);
	}
}
