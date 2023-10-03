using CommunityToolkit.Maui.Views;
namespace ChordGeneratorMAUI.Views;

public partial class TrackSettingsPopup : Popup
{
    public TrackSettingsPopup()
    {
        InitializeComponent();
    }

    private void btnOk_Clicked(object sender, EventArgs e)
    {
        this.Close();
    }
}