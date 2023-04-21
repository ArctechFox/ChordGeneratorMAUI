using ChordGeneratorMAUI.Helpers;
using ChordGeneratorMAUI.Models;
using ChordGeneratorMAUI.ViewModels;
using CommunityToolkit.Maui.Views;

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
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var popup = new ChordBuilderPopup();
        //popup.Closed += (o, e) => { (sender as CollectionView).SelectedItem = null; };
        this.ShowPopup(popup);
    }
}