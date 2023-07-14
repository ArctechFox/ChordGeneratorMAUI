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
        MetronomeControl.BindingContext = MetronomeViewModel.Instance;
    }

    private async void SettingsButton_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ChartSettingsPage() { BindingContext = this.BindingContext });
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var collectionView = (sender as CollectionView);

        if (e.CurrentSelection.Count == 0) return;

        if (e.PreviousSelection.Count == 0 || e.CurrentSelection[0] != e.PreviousSelection[0])
        {
            var popup = new ChordBuilderPopup();
            popup.Closed += (o, e) => { collectionView.SelectedItem = null; };

            await this.ShowPopupAsync(popup);
        }
    }

    private async void btnRead_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Charts/ReadingMode");
    }
}