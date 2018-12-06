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
	public class Situacao : DataHandler, ISituacao
	{
		SQLiteConnection conn;

		public Situacao()
		{
			Conexao(out conn);
		}

		public List<Model.Situacao> Get()
		{
			try
			{
				var list = new List<Model.Situacao>();

				using (var cmd = new SQLiteCommand("SELECT * FROM Situacoes", conn))
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

		private void Fill(List<Model.Situacao> list, SQLiteDataAdapter da)
		{
			if (conn.State == ConnectionState.Closed) conn.Open();

			var dt = new DataTable();
			da.Fill(dt);

			Fill(list, dt);
		}

		private void Fill(List<Model.Situacao> list, DataTable dt)
		{
			foreach (DataRow dr in dt.Rows)
			{
				var s = new Model.Situacao(this)
				{
					Id = Convert.ToInt32(dr["id"]),
					Nome = Convert.ToString(dr["Nome"]),
					Descricao = dr["Descricao"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Descricao"])
				};

				list.Add(s);
			}
		}
	}
}
