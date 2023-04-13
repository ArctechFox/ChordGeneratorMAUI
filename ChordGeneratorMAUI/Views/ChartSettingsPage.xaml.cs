namespace ChordGeneratorMAUI.Views;

public partial class ChartSettingsPage : ContentPage
{
	public ChartSettingsPage()
	{
		InitializeComponent();
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