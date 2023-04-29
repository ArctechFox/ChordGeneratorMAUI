using CommunityToolkit.Maui.Views;
namespace ChordGeneratorMAUI.Views;

public partial class ChordBuilderPopup : Popup
{
	public ChordBuilderPopup()
	{
		InitializeComponent();
	}

    private void btnInsertChord_Clicked(object sender, EventArgs e)
    {
		this.Close();
    }

    private void btnEmptyChord_Clicked(object sender, EventArgs e)
    {
        this.Close();
    }
}