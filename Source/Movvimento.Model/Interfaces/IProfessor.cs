﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.Model.Interfaces
{
	public interface IProfessor
	{
		List<Professor> Get();
		List<Professor> Get(int categoria);
	}
}
