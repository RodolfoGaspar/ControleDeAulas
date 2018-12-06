using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Linq;

namespace ControleDeAulas.Helpers
{
	public sealed class AppRibbon
	{
		public AppRibbon() { }
		public static Ribbon Ribbon { get; set; }
		public Control Loaded { get; set; }

		public static void SetVisibility(string pRibbonElementName, Visibility pVisibility)
		{
			if (AppRibbon.Ribbon != null)
			{
				foreach (var tabItem in AppRibbon.Ribbon.Items.OfType<RibbonTab>())
				{
					if (pRibbonElementName == tabItem.Name || pRibbonElementName == "AllRibbonElements")
						tabItem.Visibility = pVisibility;
					foreach (var groupItem in tabItem.Items.OfType<RibbonGroup>())
					{
						if (pRibbonElementName == groupItem.Name || pRibbonElementName == "AllRibbonElements")
							groupItem.Visibility = pVisibility;
						foreach (var buttonItem in groupItem.Items.OfType<RibbonButton>())
						{
							if (pRibbonElementName == buttonItem.Name || pRibbonElementName == "AllRibbonElements")
							{
								((RibbonTab)((RibbonGroup)buttonItem.Parent).Parent).Visibility = pVisibility;
								((RibbonGroup)buttonItem.Parent).Visibility = pVisibility;
								buttonItem.Visibility = pVisibility;
							}
						}
					}
				}
			}
		}

		public static void SetFocus(string pRibbonElementName)
		{
			if (AppRibbon.Ribbon != null)
			{
				foreach (var tabItem in AppRibbon.Ribbon.Items.OfType<RibbonTab>())
				{
					if (pRibbonElementName == tabItem.Name || pRibbonElementName == "AllRibbonElements")
						tabItem.IsSelected = true;
				}
			}
		}

		public static void SetEnable(string pRibbonElementName)
		{
			if (AppRibbon.Ribbon != null)
			{
				foreach (var tabItem in AppRibbon.Ribbon.Items.OfType<RibbonTab>())
				{
					if (pRibbonElementName == tabItem.Name || pRibbonElementName == "AllRibbonElements")
						tabItem.IsEnabled = true;
					foreach (var groupItem in tabItem.Items.OfType<RibbonGroup>())
					{
						if (pRibbonElementName == groupItem.Name || pRibbonElementName == "AllRibbonElements")
							groupItem.IsEnabled = true;
						foreach (var buttonItem in groupItem.Items.OfType<RibbonButton>())
						{
							if (pRibbonElementName == buttonItem.Name || pRibbonElementName == "AllRibbonElements")
							{
								buttonItem.IsEnabled = true;
							}
						}
					}
				}
			}
		}

		public static void SetDisable(string pRibbonElementName)
		{
			if (AppRibbon.Ribbon != null)
			{
				foreach (var tabItem in AppRibbon.Ribbon.Items.OfType<RibbonTab>())
				{
					if (pRibbonElementName == tabItem.Name || pRibbonElementName == "AllRibbonElements")
						tabItem.IsEnabled = false;
					foreach (var groupItem in tabItem.Items.OfType<RibbonGroup>())
					{
						if (pRibbonElementName == groupItem.Name || pRibbonElementName == "AllRibbonElements")
							groupItem.IsEnabled = false;
						foreach (var buttonItem in groupItem.Items.OfType<RibbonButton>())
						{
							if (pRibbonElementName == buttonItem.Name || pRibbonElementName == "AllRibbonElements")
							{
								buttonItem.IsEnabled = false;
							}
						}
					}
				}
			}
		}
	}
}
