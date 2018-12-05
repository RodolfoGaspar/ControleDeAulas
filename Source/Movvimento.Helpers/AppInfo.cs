using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.Helpers
{
	/// <summary>
	/// Retorna informações de compilação do Aplicativo (Assembly Informations).
	/// </summary>
	public static class AppInfo
	{
		/// <summary>
		/// Retorna a versão em execução do Aplicativo.
		/// </summary>
		public static Version Version { get { return Assembly.GetCallingAssembly().GetName().Version; } }
		/// <summary>
		/// Retorna o Título do Aplicativo.
		/// </summary>
		public static string Title
		{
			get
			{
				object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0)
				{
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title.Length > 0) return titleAttribute.Title;
				}
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}
		/// <summary>
		/// Retorna o Nome do Aplicativo ou Produto.
		/// </summary>
		public static string ProductName
		{
			get
			{
				object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				return attributes.Length == 0 ? "" : ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}
		/// <summary>
		/// Retorna a Descrição do Aplicativo.
		/// </summary>
		public static string Description
		{
			get
			{
				object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				return attributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}
		/// <summary>
		/// Retorna as informações de Registro de Patente, Direitos Autorais e de Propriedade.
		/// </summary>
		public static string CopyrightHolder
		{
			get
			{
				object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}
		/// <summary>
		/// Retorna o nome da Companhia Proprietaria do Aplicativo
		/// </summary>
		public static string CompanyName
		{
			get
			{
				object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				return attributes.Length == 0 ? "" : ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}

	}
}
