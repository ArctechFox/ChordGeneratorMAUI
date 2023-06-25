using ChordGeneratorMAUI.Helpers;
using CommunityToolkit.Maui.Views;
using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using TimeSpan = System.TimeSpan;

namespace ChordGeneratorMAUI.ViewModels
{
    public sealed class MetronomeViewModel : BindableBase
    {
        private static readonly Lazy<MetronomeViewModel> lazy = new Lazy<MetronomeViewModel>(() => new MetronomeViewModel());
        public static MetronomeViewModel Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        // METRONOME SOUNDS
        private readonly string _metronome_practicePad_hi = "Perc_PracticePad_hi.wav";
        private readonly string _metronome_practicePad_lo = "Perc_PracticePad_lo.wav";

        private IAudioPlayer _audioPlayer_metronome_practicePad_lo;
        private IAudioPlayer _audioPlayer_metronome_practicePad_hi;

        // TIMERS
        private System.Timers.Timer _totalTimer;
        private System.Timers.Timer _beatTimer;

        // In miliseconds
        private readonly double _totalTimeInterval = 1000;

        private MetronomeViewModel()
        {
            SetupAudioPlayers();

            // Timers setup
            _totalTimer = new System.Timers.Timer();
            _totalTimer.Interval = _totalTimeInterval;
            _totalTimer.Elapsed += new ElapsedEventHandler(OnTotalTimerElapsed);

            _beatTimer = new System.Timers.Timer();
            _beatTimer.AutoReset = true;
            _beatTimer.Elapsed += new ElapsedEventHandler(OnBeatTimerElapsed);

            // Subscribe to relevant events
            Helpers.EventManager.Instance.EventAggregator
                .GetEvent<ChartGeneratedEvent>()
                .Subscribe(ChartGeneratedHandler);

            Helpers.EventManager.Instance.EventAggregator
                .GetEvent<TimerStartEvent>()
                .Subscribe(StartTotalTimer);

            Helpers.EventManager.Instance.EventAggregator
                .GetEvent<TimerPauseEvent>()
                .Subscribe(PauseTotalTimer);

            Helpers.EventManager.Instance.EventAggregator
                .GetEvent<ResetToDefaultSettingsEvent>()
                .Subscribe(ResetToDefaultSettings);

            Helpers.EventManager.Instance.EventAggregator
                .GetEvent<BPMChangedEvent>()
                .Subscribe(BPMChangedHandler);

            //Helpers.EventManager.Instance.EventAggregator
            //    .GetEvent<BeatElapsedEvent>()
            //    .Subscribe(PlayClickSound);

        }
        ~MetronomeViewModel() // TODO: Hmm... ¯\_(ツ)_/¯
        {
            _audioPlayer_metronome_practicePad_hi.Dispose();
            _audioPlayer_metronome_practicePad_lo.Dispose();
        }

        private TimeSpan _totalTimeElapsed = TimeSpan.Zero;
        public TimeSpan TotalTimeElapsed
        {
            get { return _totalTimeElapsed; }
            set
            {
                SetProperty(ref _totalTimeElapsed, value);

                string formatString;
                if (value.TotalHours >= 1)
                {
                    formatString = @"{0:h\:mm\:ss}";
                }
                else if (value.TotalMinutes >= 10)
                {
                    formatString = @"{0:mm\:ss}";
                }
                else
                {
                    formatString = @"{0:m\:ss}";
                }

                TotalTimeElapsedString = string.Format(formatString, _totalTimeElapsed);
            }
        }

        private string _totalTimeElapsedString = "0:00";
        public string TotalTimeElapsedString
        {
            get { return _totalTimeElapsedString; }
            set { SetProperty(ref _totalTimeElapsedString, value); }
        }

        private int _currentBeat = 0;
        public int CurrentBeat
        {
            get { return _currentBeat; }
            set
            {
                // TODO: subscribe to TimeSignatureChangedEvent to track this value instead of hard-coding a 4
                value = value > 4 ? 1 : value;
                SetProperty(ref _currentBeat, value);
            }
        }

        private int _chartCount = 0;
        public int ChartCount
        {
            get { return _chartCount; }
            set { SetProperty(ref _chartCount, value); }
        }

        /////////////////////////////////////////////////////////////////////////

        private async void SetupAudioPlayers()
        {
            _audioPlayer_metronome_practicePad_hi = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(_metronome_practicePad_hi));
            _audioPlayer_metronome_practicePad_lo = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(_metronome_practicePad_lo));

            _audioPlayer_metronome_practicePad_hi.Volume = 1;
            _audioPlayer_metronome_practicePad_lo.Volume = 1;
        }

        private async void PlayClickSound(int beat)
        {
            if (beat == 1)
            {
                await Task.Factory.StartNew(_audioPlayer_metronome_practicePad_hi.Play);
            }
            else
            {
                await Task.Factory.StartNew(_audioPlayer_metronome_practicePad_lo.Play);
            }
        }

        private void StartMetronome()
        {
            CurrentBeat = 0;
            _beatTimer.Start();
        }

        private void StopMetronome()
        {
            _beatTimer.Stop();
        }

        private void StartTotalTimer()
        {
            _totalTimer.Start();
            StartMetronome();
        }

        private void PauseTotalTimer()
        {
            _totalTimer.Stop();
            StopMetronome();
        }

        private void ResetToDefaultSettings()
        {
            CurrentBeat = 0;
            TotalTimeElapsed = TimeSpan.Zero;
            //ChartCount = ChartCount <= 0 ? 0 : ChartCount-1;
        }

        private void BPMChangedHandler(int bpm)
        {
            _beatTimer.Interval = 60000 / bpm;
        }

        private void ChartGeneratedHandler()
        {
            ResetToDefaultSettings();
            StopMetronome();

            ChartCount++;
        }

        private void OnTotalTimerElapsed(object sender, ElapsedEventArgs e)
        {
            TotalTimeElapsed += TimeSpan.FromMilliseconds(_totalTimeInterval);
        }

        private async void OnBeatTimerElapsed(object sender, ElapsedEventArgs e)
        {
            CurrentBeat++;
            PlayClickSound(CurrentBeat);

            await Task.Factory.StartNew(() => { EventManager.Instance.EventAggregator.GetEvent<BeatElapsedEvent>().Publish(CurrentBeat); });

            //Application.Current?.Dispatcher.Dispatch(() =>
            //{
            //    EventManager.Instance.EventAggregator.GetEvent<BeatElapsedEvent>().Publish(CurrentBeat);
            //});
        }
    }
}
