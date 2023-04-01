using ChordGeneratorMAUI.ViewModels;

namespace ChordGeneratorMAUI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		this.BindingContext = new MainPageViewModel();
	}
}

