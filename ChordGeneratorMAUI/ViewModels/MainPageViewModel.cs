using ChordGeneratorMAUI.DataAccess;
using ChordGeneratorMAUI.Helpers;
using ChordGeneratorMAUI.Models;
using Manufaktura.Controls.Extensions;
using Manufaktura.Controls.Model;
using Manufaktura.Music.Model;
using Manufaktura.Music.Model.Harmony;
using Manufaktura.Music.Model.MajorAndMinor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordGeneratorMAUI.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private int _barCount;

        private bool _isPaused = false;
        public bool IsPaused
        {
            get { return _isPaused; }
            set { SetProperty(ref _isPaused, value); }
        }

        private bool _isChordChartActive = false;
        public bool IsChordChartActive
        {
            get { return _isChordChartActive; }
            set { SetProperty(ref _isChordChartActive, value); }
        }

        private Score _musicScore = new Score();
        public Score MusicScore
        {
            get { return _musicScore; }
            set
            {
                SetProperty(ref _musicScore, value);
            }
        }

        private ObservableCollection<ChordModel> _chordChart = new ObservableCollection<ChordModel>();
        public ObservableCollection<ChordModel> ChordChart
        {
            get { return _chordChart; }
            set { SetProperty(ref _chordChart, value); }
        }

        public DelegateCommand GenerateChordsCommand { get; set; }
        public DelegateCommand PauseToggleCommand { get; set; }
        public DelegateCommand ResetCommand { get; set; }

        public MainPageViewModel()
        {
            GenerateChordsCommand = new DelegateCommand(() =>
            {
                ClearChordChart();

                for (int i = 0; i < _barCount; i++)
                {
                    Random r = new Random();
                    int n = r.Next(0, ChordDatabase.Chords.Count);

                    GenerateStaff(ChordDatabase.Chords.ElementAt(n).Value);
                }

                Application.Current?.Dispatcher.Dispatch(() =>
                {
                    Helpers.EventManager.Instance.EventAggregator.GetEvent<ChartGeneratedEvent>().Publish();
                });

                IsPaused = false;
                IsChordChartActive = true;
            });

            PauseToggleCommand = new DelegateCommand(() =>
            {
                // Toggle boolean
                IsPaused = !IsPaused;

                if (IsPaused)
                {
                    Application.Current?.Dispatcher.Dispatch(() =>
                    {
                        Helpers.EventManager.Instance.EventAggregator.GetEvent<TimerPauseEvent>().Publish();
                    });
                }
                else
                {
                    Application.Current?.Dispatcher.Dispatch(() =>
                    {
                        Helpers.EventManager.Instance.EventAggregator.GetEvent<TimerStartEvent>().Publish();
                    });
                }                
            });

            ResetCommand = new DelegateCommand(() =>
            {
                Application.Current?.Dispatcher.Dispatch(() =>
                {
                    Helpers.EventManager.Instance.EventAggregator.GetEvent<ResetToDefaultSettingsEvent>().Publish();
                    Helpers.EventManager.Instance.EventAggregator.GetEvent<TimerPauseEvent>().Publish();
                });

                ClearChordChart();
            });

            // Event Subscriptions
            Helpers.EventManager.Instance.EventAggregator
                .GetEvent<BarCountChangedEvent>()
                .Subscribe((int c) => { _barCount = c; });
        }

        private void GenerateStaff(Chord chord)
        {
            Staff newStaff = new Staff()
                .AddTimeSignature(TimeSignatureType.Common, 4, 4)
                .Add(Clef.Treble);

            List<Note> notes = new List<Note>();
            foreach (var p in chord.Pitches)
            {
                notes.Add(new Note(p, RhythmicDuration.Quarter));
            }

            newStaff.AddRange(StaffBuilder.MakeChord(notes));

            newStaff.AddBarline();
            MusicScore.FirstStaff.Elements.Add(newStaff);
        }

        private void ClearChordChart()
        {
            ChordChart.Clear();
            IsChordChartActive = false;
        }
    }
}
