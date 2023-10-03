using CommunityToolkit.Maui.Views;

namespace ChordGeneratorMAUI.Views;

public partial class TrackSelector : ContentView
{
	public TrackSelector()
	{
		InitializeComponent();
	}

    async void TrackSettingsButton_Tapped(System.Object sender, TappedEventArgs e)
    {
        var popup = new TrackSettingsPopup();
        await (this.Parent as ContentPage).ShowPopupAsync(popup);
    }
}