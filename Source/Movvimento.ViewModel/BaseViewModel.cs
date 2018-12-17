using ControleDeAulas.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ControleDeAulas.ViewModel
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		#region Properties		
		/// <summary>
		/// Label/Content dos botões para adicionar itens selecionados.
		/// </summary>
		public string addSel { get; set; }
		/// <summary>
		/// Label/Content dos botões para adicionar todos os itens.
		/// </summary>
		public string addAll { get; set; }
		/// <summary>
		/// Label/Content dos botões para excluir itens selecionados.
		/// </summary>
		public string delSel { get; set; }
		/// <summary>
		/// Label/Content dos botões para excluir todos os itens.
		/// </summary>
		public string delAll { get; set; }

		public BaseSingleton Base_ { get; set; }

		public dynamic SelectedItem { get; set; }
		#endregion

		#region RelayCommand
		/// <summary>
		/// Acionado ao duplo click do mouse sobre o registro
		/// </summary>
		public RelayCommand MouseDoubleClickCommand { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		internal void RaisePropertyChanged(string prop)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
#if DEBUG
			Debug.Print($"Property Changed: {prop}");
#endif
		}

#endregion



		public static dynamic GetCurrentPageDataContext()
		{
			return ((Page)(Navigator.NavigationService.Content)).DataContext;
		}

		public static dynamic GetCurrentWizardPageDataContext()
		{
			return ((Page)(Navigator.WizardNavigationService.Content)).DataContext;
		}

		public static dynamic GetCurrentWizardPage()
		{
			return ((Page)(Navigator.WizardNavigationService.Content));
		}
	}
}