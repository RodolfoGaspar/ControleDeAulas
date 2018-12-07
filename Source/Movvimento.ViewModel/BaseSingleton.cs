using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAulas.ViewModel
{
	public sealed class BaseSingleton : INotifyPropertyChanged
	{
		static BaseSingleton instance = null;
		public BaseSingleton() { }
		public static BaseSingleton Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new BaseSingleton();
				}
				return instance;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
