using ControleDeAulas.Model;
using ControleDeAulas.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.DataAccess
{
	public class Falta : DataHandler, IFalta
	{
		SQLiteConnection conn;

		public Falta()
		{
			Conexao(out conn);
		}

		public bool Add(List<Model.Falta> faltas)
		{
			try
			{
				faltas.ForEach(f =>
				{
					var sb = new StringBuilder();
					sb.Append($"	insert into BoletimDeFaltas (idprofessor, data, IdDisciplina, idturma, nfaltas, idprofsubs, naulassubs)");
					sb.Append($"	values(");
					if (f.Professor != null)
					{ sb.Append($"			{f.Professor.Id}, "); }
					else
					{ sb.Append($"			{DBNull.Value}, "); }
					sb.Append($"		   '{f.Data.ToShortDateString()}', ");
					if (f.Disciplina != null)
					{ sb.Append($"			{f.Disciplina.Id}, "); }
					else
					{ sb.Append($"			{DBNull.Value}, "); }
					if (f.Turma != null)
					{ sb.Append($"			{f.Turma.Id}, "); }
					else
					{ sb.Append($"			{DBNull.Value}, "); }
					sb.Append($"			{f.NFaltas}, ");
					if (f.ProfSubs != null)
					{ sb.Append($"			{f.ProfSubs.Id}, "); }
					else
					{ sb.Append($"			{DBNull.Value}, "); }
					sb.Append($"			{f.NAulasSubs})");

					using (var cmd = new SQLiteCommand(sb.ToString(), conn))
					{
						if (conn.State == ConnectionState.Closed) conn.Open();
						cmd.ExecuteNonQuery();						
					}					
				});
				return true;
			}
			catch (Exception ex)
			{
				return false;
				throw ex;				
			}
			finally { conn.Close(); }
		}

		public List<Model.Falta> Get()
		{
			try
			{
				var list = new List<Model.Falta>();

				var sb = new StringBuilder();
				sb.Append("SELECT		BDF.IdProfessor, PRF.Nome AS NomeProfessor, ");
				sb.Append("				BDF.Data, ");
				sb.Append("				BDF.IdDISciplina, DIS.Nome AS NomeDisciplina, ");
				sb.Append("				BDF.IdTurma, TRM.Nome AS NomeTurma, ");
				sb.Append("				BDF.NFaltas, ");
				sb.Append("				BDF.IdProfSubs, PSB.Nome AS NomeProfSubs, ");
				sb.Append("				BDF.NAulasSubs ");
				sb.Append("FROM			BoletimDeFaltas					AS	BDF ");
				sb.Append("LEFT JOIN   (SELECT	* ");
				sb.Append("				FROM	Professores ");
				sb.Append("				WHERE	idCategoria		=	1)	AS	PRF ");
				sb.Append("ON			BDF.idProfessor			=	PRF.id ");
				sb.Append("LEFT JOIN	Turmas							AS	TRM ");
				sb.Append("ON			BDF.idturma						=	TRM.id ");
				sb.Append("LEFT JOIN	DISciplinas						AS	DIS ");
				sb.Append("ON			BDF.IdDISciplina				=	DIS.Id ");
				sb.Append("LEFT JOIN   (SELECT	* ");
				sb.Append("				FROM	Professores ");
				sb.Append("				WHERE	idCategoria		=	2)	AS	PSB ");
				sb.Append("ON			BDF.idProfSubs					=	PSB.id ");

				using (var cmd = new SQLiteCommand(sb.ToString(), conn))
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

		private void Fill(List<Model.Falta> list, SQLiteDataAdapter da)
		{
			if (conn.State == ConnectionState.Closed) conn.Open();

			var dt = new DataTable();
			da.Fill(dt);

			Fill(list, dt);
		}

		private void Fill(List<Model.Falta> list, DataTable dt)
		{
			foreach (DataRow dr in dt.Rows)
			{
				var f = new Model.Falta(this);

				f.Professor = new Model.Professor(new Professor(), new Faixa(), new Nivel(), new Situacao(), new Categoria(), new Disciplina());
				f.Professor.Id = Convert.ToInt32(dr["idProfessor"]);
				f.Professor.Nome = dr["NomeProfessor"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NomeProfessor"]);
				f.Data = dr["Data"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["Data"]);
				f.Disciplina = new Model.Disciplina(new Disciplina());
				f.Disciplina.Id = Convert.ToInt32(dr["idDisciplina"]);
				f.Disciplina.Nome = dr["NomeDisciplina"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NomeDisciplina"]);
				f.Turma = new Model.Turma(new Turma());
				f.Turma.Id = Convert.ToInt32(dr["idTurma"]);
				f.Turma.Nome = dr["NomeTurma"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NomeTurma"]);
				f.NFaltas = dr["NFaltas"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NFaltas"]);
				if (dr["IdProfSubs"] != DBNull.Value)
				{
					f.ProfSubs = new Model.Professor(new Professor(), new Faixa(), new Nivel(), new Situacao(), new Categoria(), new Disciplina());
					f.ProfSubs.Id = Convert.ToInt32(dr["IdProfSubs"]);
					f.ProfSubs.Nome = dr["NomeProfSubs"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NomeProfSubs"]);
				}

				f.NAulasSubs = dr["NAulasSubs"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NAulasSubs"]);

				list.Add(f);
			}
		}
	}
}
