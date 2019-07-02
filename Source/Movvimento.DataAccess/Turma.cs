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
	public class Turma : DataHandler, ITurma
	{
		SQLiteConnection conn;

		public Turma()
		{
			Conexao(out conn);
		}

		public List<Model.Turma> Get()
		{
			try
			{
				var list = new List<Model.Turma>();

				using (var cmd = new SQLiteCommand(GetTSql().ToString(), conn))
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

		public List<Model.Turma> Get(Model.Professor p, Model.Disciplina d, DayOfWeek dw)
		{
			try
			{
				var list = new List<Model.Turma>();

				using (var cmd = new SQLiteCommand(GetTSql(p, d, dw).ToString(), conn))
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
		
		private static StringBuilder GetTSql()
		{
			var sb = new StringBuilder();
			sb.Append("SELECT		Id, Nome, Descricao ");
			sb.Append("FROM			Turmas");
			return sb;
		}

		private object GetTSql(Model.Professor p, Model.Disciplina d, DayOfWeek dw)
		{
			var sb = new StringBuilder();
			sb.Append($"SELECT		TUR.Id, TUR.Nome,");
			sb.Append($"			TUR.Descricao ");
			sb.Append($"FROM		Turmas				as	TUR ");
			sb.Append($"INNER JOIN  Calendário			as	CAL ");
			sb.Append($"ON			TUR.id				=	CAL.idTurma ");
			sb.Append($"WHERE		CAL.idprofessor		=	{p.Id} ");
			sb.Append($"AND			CAL.iddisciplina	=	{d.Id} ");
			sb.Append($"AND			CAL.diadasemana		=	{(int)dw} ");			
			return sb;
		}

		private void Fill(List<Model.Turma> list, SQLiteDataAdapter da)
		{
			if (conn.State == ConnectionState.Closed) conn.Open();

			var dt = new DataTable();
			da.Fill(dt);

			Fill(list, dt);
		}

		private void Fill(List<Model.Turma> list, DataTable dt)
		{
			foreach (DataRow dr in dt.Rows)
			{
				var t = new Model.Turma(this)
				{
					Id = Convert.ToInt32(dr["id"]),
					Nome = Convert.ToString(dr["Nome"]),
					Descricao = dr["Descricao"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Descricao"])
				};

				list.Add(t);
			}
		}
	}
}
