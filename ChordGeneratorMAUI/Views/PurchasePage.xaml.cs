using ChordGeneratorMAUI.DataAccess;

namespace ChordGeneratorMAUI.Views;

public partial class PurchasePage : ContentPage
{
	public PurchasePage()
	{
		InitializeComponent();
	}

    private async void PurchaseButton_Clicked(object sender, EventArgs e)
    {
        await PurchaseManager.Instance.MakePurchase();
    }

    private void RestoreButton_Clicked(object sender, EventArgs e)
    {
        // TODO: restore purchase
    }
}