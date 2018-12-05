using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.Factory
{
	public class AppFactory
	{
		public Model.Professor NewProfessor()
		{
			return new Model.Professor(new DataAccess.Professor());
		}
	}
}
