using ChordGeneratorMAUI.Helpers;
using ChordGeneratorMAUI.ViewModels;

namespace ChordGeneratorMAUI.Views;

public partial class Metronome : ContentView
{
	public Metronome()
	{
		InitializeComponent();
		this.BindingContext = new MetronomeViewModel();

        // Subscribe to relevant events
        Helpers.EventManager.Instance.EventAggregator
            .GetEvent<BeatElapsedEvent>()
            .Subscribe(PlayClickSound);
    }

    private void PlayClickSound(int beat)
    {
        if (beat == 1)
            ME_MetronomeClickHi.Play();
        else
            ME_MetronomeClickLo.Play();
    }
}