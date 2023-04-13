using ChordGeneratorMAUI.ViewModels;

namespace ChordGeneratorMAUI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		this.BindingContext = new MainPageViewModel();
    }

    private async void btnWritingMode_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("//Charts/WritingMode");
    }

    private async void btnReadingMode_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Charts/ReadingMode");
    }
}

