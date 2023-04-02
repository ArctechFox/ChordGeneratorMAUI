using ChordGeneratorMAUI.ViewModels;

namespace ChordGeneratorMAUI.Views;

public partial class Metronome : ContentView
{
	public Metronome()
	{
		InitializeComponent();
		this.BindingContext = new MetronomeViewModel();
	}
}