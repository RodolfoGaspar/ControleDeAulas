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
	public class Disciplina : DataHandler, IDisciplina
	{
		SQLiteConnection conn;

		public Disciplina()
		{
			Conexao(out conn);
		}

		public List<Model.Disciplina> Get()
		{
			try
			{
				var list = new List<Model.Disciplina>();

				using (var cmd = new SQLiteCommand("SELECT * FROM Disciplinas", conn))
				{
					using (var da = new SQLiteDataAdapter(cmd))
					{ Fill(list, da); }
				}

				return list;

			}
			catch (Exception ex)
			{ throw ex; }
			finally { conn.Close(); }
		}

		private void Fill(List<Model.Disciplina> list, SQLiteDataAdapter da)
		{
			if (conn.State == ConnectionState.Closed) conn.Open();

			var dt = new DataTable();
			da.Fill(dt);

			Fill(list, dt);
		}

		private void Fill(List<Model.Disciplina> list, DataTable dt)
		{
			foreach (DataRow dr in dt.Rows)
			{
				var n = new Model.Disciplina(this)
				{
					Id = Convert.ToInt32(dr["id"]),
					Nome= Convert.ToString(dr["Nome"])					
				};

				list.Add(n);
			}
		}
	}
}
