using ChordGeneratorMAUI.ViewModels;

namespace ChordGeneratorMAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		var vm = new ChartViewModel();
		this.ChartsTab.BindingContext = vm;
	}
}
