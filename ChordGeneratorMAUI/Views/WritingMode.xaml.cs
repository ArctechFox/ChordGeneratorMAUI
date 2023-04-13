using ChordGeneratorMAUI.Helpers;
using ChordGeneratorMAUI.ViewModels;

namespace ChordGeneratorMAUI.Views;

public partial class WritingMode : ContentPage
{
	public WritingMode()
	{
		InitializeComponent();
    }

    private async void SettingsButton_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ChartSettingsPage() { BindingContext = this.BindingContext });
        //await Shell.Current.GoToAsync("//Charts/ChartSettings");
    }
}