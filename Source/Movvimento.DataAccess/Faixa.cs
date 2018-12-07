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
	public class Faixa : DataHandler, IFaixa
	{
		SQLiteConnection conn;

		public Faixa()
		{
			Conexao(out conn);
		}

		public List<Model.Faixa> Get()
		{
			try
			{
				var list = new List<Model.Faixa>();

				using (var cmd = new SQLiteCommand("SELECT * FROM Faixas", conn))
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

		private void Fill(List<Model.Faixa> list, SQLiteDataAdapter da)
		{
			if (conn.State == ConnectionState.Closed) conn.Open();

			var dt = new DataTable();
			da.Fill(dt);

			Fill(list, dt);
		}

		private void Fill(List<Model.Faixa> list, DataTable dt)
		{
			foreach (DataRow dr in dt.Rows)
			{
				var n = new Model.Faixa(this)
				{
					Id = Convert.ToInt32(dr["id"]),
					NFaixa = Convert.ToInt32(dr["NFaixa"]),
					Descricao = dr["Descricao"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Descricao"])
				};

				list.Add(n);
			}
		}
	}
}
