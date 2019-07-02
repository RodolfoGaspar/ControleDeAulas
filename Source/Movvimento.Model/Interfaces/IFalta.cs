using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.Model.Interfaces
{
	public interface IFalta
	{
		List<Falta> Get();
		bool Add(List<Falta> faltas);
	}
}
