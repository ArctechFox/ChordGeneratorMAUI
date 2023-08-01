using CommunityToolkit.Maui.Views;
namespace ChordGeneratorMAUI.Views;

public partial class ChartSettingsPopup : Popup
{
    public ChartSettingsPopup()
    {
        InitializeComponent();
    }

    private void btnOk_Clicked(object sender, EventArgs e)
    {
        this.Close();
    }
}