using ChordGeneratorMAUI.ViewModels;
using Plugin.Maui.Audio;

namespace ChordGeneratorMAUI;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
		InitializeComponent();
		this.BindingContext = new MainPageViewModel();    
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var animation = new Animation(v => lblAnimatedLogo.Shadow.Radius = (float)v, 5, 0);
        animation.Commit(this, "ShadowFadeInAnimation", 10, 650, Easing.CubicOut, (v, c) => lblAnimatedLogo.Shadow.Radius = 0, () => false);
    }

    private async void btnWritingMode_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("//Charts/WritingMode");
    }

    private async void btnReadingMode_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Charts/ReadingMode");
    }

    private async void btnPurchase_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Purchase");
    }
}

