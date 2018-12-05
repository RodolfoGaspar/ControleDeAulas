using ControleDeAulas.Model;
using ControleDeAulas.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.DataAccess
{
	public class Professor : DataHandler, IProfessor
	{
		SQLiteConnection conn;

		public Professor()
		{
			Conexao(out conn);
		}

		public List<Model.Professor> Get()
		{
			try
			{
				var list = new List<Model.Professor>();

				using (var cmd = new SQLiteCommand("SELECT * FROM Professores", conn))
				{
					using (var da = new SQLiteDataAdapter(cmd))
					{ Fill(list, da);}
				}

				return list;

			}
			catch (Exception ex)
			{ throw ex; }
		}

		private void Fill(List<Model.Professor> list, SQLiteDataAdapter da)
		{
			if (conn.State == ConnectionState.Closed) conn.Open();

			var dt = new DataTable();
			da.Fill(dt);

			Fill(list, dt);
		}

		private void Fill(List<Model.Professor> list, DataTable dt)
		{
			foreach (DataRow dr in dt.Rows)
			{
				var p = new Model.Professor(this);

				p.Id = Convert.ToInt32(dr["id"]);
				p.Nome = Convert.ToString(dr["Nome"]);
				p.RG = Convert.ToString(dr["RG"]);
				//p.Fn = Convert.ToString(dr["Fn"]);
				p.IdCategoria = Convert.ToInt32(dr["IdCategoria"]);
				p.IdStatus = Convert.ToInt32(dr["IdStatus"]);
				p.IdDisciplina = Convert.ToInt32(dr["IdDisciplina"]);

				list.Add(p);
			}
		}
	}
}
