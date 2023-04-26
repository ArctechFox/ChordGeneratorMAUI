using ChordGeneratorMAUI.Helpers;
using ChordGeneratorMAUI.ViewModels;
using CommunityToolkit.Maui.Views;

namespace ChordGeneratorMAUI.Views;

public partial class ReadingMode : ContentPage
{
	public ReadingMode()
	{
		InitializeComponent();
    }

    private async void SettingsButton_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ChartSettingsPage() { BindingContext = this.BindingContext });
    }
}