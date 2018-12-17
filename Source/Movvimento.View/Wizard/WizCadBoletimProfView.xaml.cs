using System.Windows.Controls;


namespace ControleDeAulas.View.Wizard
{
	/// <summary>
	/// Interação lógica para WizCadBoletimProfView.xam
	/// </summary>
	public partial class WizCadBoletimProfView : Page
	{
		public ComboBox Disciplinas { get; set; }
		public DataGrid Turmas { get; set; }

		public WizCadBoletimProfView()
		{
			InitializeComponent();
			Disciplinas = lstDisciplinas;
			Turmas = DtgTurmas;
		}

		
	}
}
