﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.Model.Interfaces
{
	public interface IDisciplina
	{
		List<Disciplina> Get();		
		List<Disciplina> Get(Professor p);
	}
}
