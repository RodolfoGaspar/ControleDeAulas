using ControleDeAulas.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.DataAccess
{
	public class DataHandler
	{
		/// <summary>
		/// Obtém string de conexão com o banco de dados.
		/// </summary>
		/// <param name="conn">Conexão.</param>
		public static void Conexao(out SQLiteConnection conn)
		{
			conn = null;
			try
			{
				conn = new SQLiteConnection($"Data Source={Path.Combine(AppProperties.AppPath, AppProperties.BdPath)};Version=3;");
			}
			catch (Exception ex)
			{ throw ex; }
		}
	}
}
