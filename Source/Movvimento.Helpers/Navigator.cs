using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Navigation;
using System.Threading.Tasks;

namespace ControleDeAulas.Helpers
{
	public sealed class Navigator
	{
		private static readonly Navigator instance = new Navigator();
		private Navigator() { }
		public static NavigationService NavigationService { get; set; }
		public static NavigationService WizardNavigationService { get; set; }
		//async public static void Cancel(bool pConfirm)
		//{
		//	if (pConfirm)
		//	{
		//		MessageDialogResult msgResp = await AppDialogs.Dialog.Message((MetroWindow)App.Current.MainWindow, "Alerta do Sistema", "Deseja Realmente Encerrar o Sistema?", "Sim", "Não");
		//		if (msgResp == MessageDialogResult.Affirmative)
		//			App.Current.Shutdown();
		//	}
		//	else
		//	{
		//		App.Current.Shutdown();
		//	}
		//}
	}
}
