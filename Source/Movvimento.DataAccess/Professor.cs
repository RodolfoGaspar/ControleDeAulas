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

				var sb = new StringBuilder();

				sb.Append("SELECT		PRF.Id, PRF.Nome, PRF.RG,");
				sb.Append("				FXA.id AS IdFaixa, FXA.NFaixa, FXA.Descricao AS DescricaoFaixa,");
				sb.Append("				NVS.id AS IdNivel, NVS.Nome AS NomeNivel,  NVS.Descricao AS DescricaoNivel,");
				sb.Append("				SIT.id AS IdSituacao, SIT.Nome AS NomeSituacao,  SIT.Descricao AS DescricaoSituacao,");
				sb.Append("				CAT.id AS IdCategoria, CAT.Nome AS NomeCategoria, CAT.Descricao AS DescricaoCategoria ");
				sb.Append("FROM			Professores		AS	PRF ");
				sb.Append("INNER JOIN	Faixas			AS	FXA ");
				sb.Append("ON			PRF.IdFaixa		=	FXA.ID ");
				sb.Append("INNER JOIN	Niveis			AS	NVS ");
				sb.Append("ON			PRF.IdNivel		=	NVS.Id ");
				sb.Append("INNER JOIN	Situacoes		AS	SIT ");
				sb.Append("ON			PRF.IdSituacao	=	SIT.Id ");
				sb.Append("INNER JOIN	Categorias		AS	CAT ");
				sb.Append("ON			PRF.IdCategoria =	CAT.Id ");

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
				var p = new Model.Professor(this, new Faixa(), new Nivel(), new Situacao(), new Categoria(), new Disciplina());

				p.Id = Convert.ToInt32(dr["id"]);
				p.Nome = Convert.ToString(dr["Nome"]);
				p.RG = Convert.ToString(dr["RG"]);
				p.Faixa.Id = Convert.ToInt32(dr["idFaixa"]);
				p.Faixa.NFaixa = Convert.ToInt32(dr["NFaixa"]);
				p.Faixa.Descricao = dr["DescricaoFaixa"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DescricaoFaixa"]);
				p.Nivel.Id = Convert.ToInt32(dr["IdNivel"]);
				p.Nivel.Nome = Convert.ToString(dr["NomeNivel"]);
				p.Nivel.Descricao = dr["DescricaoNivel"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DescricaoNivel"]);
				p.Situacao.Id = Convert.ToInt32(dr["IdSituacao"]);
				p.Situacao.Nome = Convert.ToString(dr["NomeSituacao"]);
				p.Situacao.Descricao = dr["DescricaoSituacao"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DescricaoSituacao"]);
				p.Categoria.Id = Convert.ToInt32(dr["IdCategoria"]);
				p.Categoria.Nome = Convert.ToString(dr["NomeCategoria"]);
				p.Categoria.Descricao = dr["DescricaoCategoria"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DescricaoCategoria"]);

				list.Add(p);
			}
		}
	}
}
