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

        private string _totalTimeElapsedString = "";
        public string TotalTimeElapsedString
        {
            get { return _totalTimeElapsedString; }
            set { SetProperty(ref _totalTimeElapsedString, value); }
        }

        private int _chartCount = 0;
        public int ChartCount
        {
            get { return _chartCount; }
            set { SetProperty(ref _chartCount, value); }
        }

        private int _currentBeat = 0;
        public int CurrentBeat
        {
            get { return _currentBeat; }
            set
            {
                // TODO: subscribe to TimeSignatureChangedEvent to track this value instead of hard-coding a 4
                // Constrain value to time signature
                value = value > 4 ? 1 : value;

                SetProperty(ref _currentBeat, value);

                // Don't need to play the same sound if countdown is actively doing so
                if (!IsCountdownActive && CurrentBeat > 0)
                    PlayClickSound(CurrentBeat);
            }
        }

        // COUNTDOWN PROPS

        private bool _isCountdownEnabled = true;
        public bool IsCountdownEnabled
        {
            get { return _isCountdownEnabled; }
            set { SetProperty(ref _isCountdownEnabled, value); }
        }

        private bool _isCountdownActive = false;
        public bool IsCountdownActive
        {
            get { return _isCountdownActive; }
            set
            {
                SetProperty(ref _isCountdownActive, value);
            }
        }

        private int _countdownInBeats = 4;
        public int CountdownInBeats
        {
            get { return _countdownInBeats; }
            set { SetProperty(ref _countdownInBeats, value); }
        }

        private int _countdownCurrentBeat = 0;
        public int CountdownCurrentBeat
        {
            get { return _countdownCurrentBeat; }
            set
            {
                SetProperty(ref _countdownCurrentBeat, value);

                if (CountdownCurrentBeat > 0)
                {

                     if (CountdownCurrentBeat > 4)
                    {
                        IsCountdownActive = false;

                        _totalTimer.Stop();
                        TotalTimeElapsedString = "0:00";
                        _totalTimer.Start();

                        CurrentBeat = 1;
                        return;
                    }

                    TotalTimeElapsedString = CountdownCurrentBeat.ToString();
                    PlayClickSound(CountdownCurrentBeat);
                }
            }
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
            TotalTimeElapsedString = "";
            IsCountdownActive = true;

            CurrentBeat = 0;
            CountdownCurrentBeat = 0;

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
            CurrentBeat = 0;
        }

        private void ChartGeneratedHandler()
        {
            ResetToDefaultSettings();
            StopMetronome();

            //if (ChartCount > 0)
            //    CurrentBeat = 1;

            ChartCount++;
        }

        private void OnTotalTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Don't count TotalTime while we're counting down, just show the countdown beat
            if (!IsCountdownActive)
                TotalTimeElapsed += TimeSpan.FromMilliseconds(_totalTimeInterval);
        }

        private async void OnBeatTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (IsCountdownActive)
            {
                CountdownCurrentBeat++;
                return;
            }

            CurrentBeat++;

            await Task.Factory.StartNew(() => { EventManager.Instance.EventAggregator.GetEvent<BeatElapsedEvent>().Publish(CurrentBeat); });
        }
    }
}
