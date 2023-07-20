using ChordGeneratorMAUI.Helpers;
using ChordGeneratorMAUI.Models;
using ChordGeneratorMAUI.ViewModels;
using CommunityToolkit.Maui.Views;

namespace ChordGeneratorMAUI.Views;

public partial class ChartPage : ContentPage
{
    public ChartPage()
    {
        InitializeComponent();
        MetronomeControl.BindingContext = MetronomeViewModel.Instance;

        List<int> bpmPickerSteps = new List<int>();

        // Increments of 5 for the picker, max of 300 for now
        for (int i = 5; i <= 300; i += 5)
        {
            bpmPickerSteps.Add(i);
        }

        pickerBPM.ItemsSource = bpmPickerSteps;
    }

    private async void HomeButton_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//Home");
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

    private void btnBPM_minus_Clicked(object sender, EventArgs e)
    {
        int value = Int32.Parse(lblBPM_text.Text);
        if (value > 0)
            value--;

        lblBPM_text.Text = value.ToString();
    }

    private void btnBPM_plus_Clicked(object sender, EventArgs e)
    {
        int value = Int32.Parse(lblBPM_text.Text);
        if (value < 300)
            value++;

        lblBPM_text.Text = value.ToString();
    }
}