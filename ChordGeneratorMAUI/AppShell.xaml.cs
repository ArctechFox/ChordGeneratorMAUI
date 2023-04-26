using ChordGeneratorMAUI.ViewModels;

namespace ChordGeneratorMAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		// TODO: Load user data from device
		var vm = new ChartViewModel();
		this.ChartsTab.BindingContext = vm;
	}
}
