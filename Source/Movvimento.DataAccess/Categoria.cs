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
	public class Categoria : DataHandler, ICategoria
	{
		SQLiteConnection conn;

		public Categoria()
		{
			Conexao(out conn);
		}

		public List<Model.Categoria> Get()
		{
			try
			{
				var list = new List<Model.Categoria>();

				using (var cmd = new SQLiteCommand("SELECT * FROM Categorias", conn))
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

		private void Fill(List<Model.Categoria> list, SQLiteDataAdapter da)
		{
			if (conn.State == ConnectionState.Closed) conn.Open();

			var dt = new DataTable();
			da.Fill(dt);

			Fill(list, dt);
		}

		private void Fill(List<Model.Categoria> list, DataTable dt)
		{
			foreach (DataRow dr in dt.Rows)
			{
				var c = new Model.Categoria(this)
				{
					Id = Convert.ToInt32(dr["id"]),
					Nome = Convert.ToString(dr["Nome"]),
					Descricao = dr["Descricao"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Descricao"])
				};

				list.Add(c);
			}
		}
	}
}
