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

        // Ugh fuck this on mac. Audio player just cant keep up
        ME_MetronomeClickHi.SeekCompleted += ((object sender, EventArgs e) =>
        {
            Application.Current?.Dispatcher.Dispatch(() =>
            {
                ME_MetronomeClickHi.Play();
            });
        });

        ME_MetronomeClickLo.SeekCompleted += ((object sender, EventArgs e) =>
        {
            Application.Current?.Dispatcher.Dispatch(() =>
            {
                ME_MetronomeClickLo.Play();
            });
        });
    }

    private void PlayClickSound(int beat)
    {
        if (beat == 1)
        {
            ME_MetronomeClickHi.SeekTo(TimeSpan.Zero);
        }
            
        else
        {
            ME_MetronomeClickLo.SeekTo(TimeSpan.Zero);
        }  
    }
}