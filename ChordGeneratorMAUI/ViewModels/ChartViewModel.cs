﻿using ChordGeneratorMAUI.DataAccess;
using ChordGeneratorMAUI.Helpers;
using ChordGeneratorMAUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordGeneratorMAUI.ViewModels
{
    public class ChartViewModel : BindableBase
    {
        private ChartModel _chordChart = new ChartModel();
        public ChartModel ChordChart
        {
            get { return _chordChart; }
            set { SetProperty(ref _chordChart, value); }
        }

        private List<ChartModel> _chartHistory = new List<ChartModel>();
        public List<ChartModel> ChartHistory
        {
            get { return _chartHistory; }
            set { SetProperty(ref _chartHistory, value); }
        }

        private bool _isPreviousEnabled = false;
        public bool IsPreviousEnabled
        {
            get { return _isPreviousEnabled; }
            set { SetProperty(ref _isPreviousEnabled, value); }
        }

        private bool _writeOnlyChordsInKey = false;
        public bool WriteOnlyChordsInKey
        {
            get { return _writeOnlyChordsInKey; }
            set 
            { 
                SetProperty(ref _writeOnlyChordsInKey, value);
                SearchChordsCommand.Execute(ChordSearchQuery);
            }
        }

        public List<ChordModel> ChordBuilderChords
        {
            get
            { 
                if (WriteOnlyChordsInKey)
                {
                    #region Filter by Key
                    switch (ChordChart.SelectedKey)
                    {
                        case "All": return ChordDatabase.AllChords;

                        case "Ab Major": return ChordDatabase.Key_Ab_Major_Chords;
                        case "A Major":  return ChordDatabase.Key_A_Major_Chords;
                        case "Ab Minor":  return ChordDatabase.Key_Ab_Minor_Chords;
                        case "A Minor":  return ChordDatabase.Key_A_Minor_Chords;
                        case "A# Minor": return ChordDatabase.Key_ASharp_Minor_Chords;

                        case "Bb Major": return ChordDatabase.Key_Bb_Major_Chords;
                        case "B Major": return ChordDatabase.Key_B_Major_Chords;
                        case "Bb Minor": return ChordDatabase.Key_Bb_Minor_Chords;
                        case "B Minor": return ChordDatabase.Key_B_Minor_Chords;

                        case "Cb Major": return ChordDatabase.Key_Cb_Major_Chords;
                        case "C Major": return ChordDatabase.Key_C_Major_Chords;
                        case "C# Major": return ChordDatabase.Key_CSharp_Major_Chords;
                        case "C Minor": return ChordDatabase.Key_C_Minor_Chords;
                        case "C# Minor": return ChordDatabase.Key_CSharp_Minor_Chords;

                        case "Db Major": return ChordDatabase.Key_Db_Major_Chords;
                        case "D Major": return ChordDatabase.Key_D_Major_Chords;
                        case "D Minor": return ChordDatabase.Key_D_Minor_Chords;
                        case "D# Minor": return ChordDatabase.Key_DSharp_Minor_Chords;

                        case "Eb Major": return ChordDatabase.Key_Eb_Major_Chords;
                        case "E Major": return ChordDatabase.Key_E_Major_Chords;
                        case "Eb Minor": return ChordDatabase.Key_Eb_Minor_Chords;
                        case "E Minor": return ChordDatabase.Key_E_Minor_Chords;

                        case "F Major": return ChordDatabase.Key_F_Major_Chords;
                        case "F# Major": return ChordDatabase.Key_FSharp_Major_Chords;
                        case "F Minor": return ChordDatabase.Key_F_Minor_Chords;
                        case "F# Minor": return ChordDatabase.Key_FSharp_Minor_Chords;

                        case "Gb Major": return ChordDatabase.Key_Gb_Major_Chords;
                        case "G Major": return ChordDatabase.Key_G_Major_Chords;
                        case "G Minor": return ChordDatabase.Key_G_Minor_Chords;
                        case "G# Minor": return ChordDatabase.Key_GSharp_Minor_Chords;

                        case "8==D": return ChordDatabase.Key_D_Major_Chords; // ;)
                    }

                    #endregion
                }

                return ChordDatabase.AllChords;
            }
        }

        private string _chordSearchQuery;
        public string ChordSearchQuery
        {
            get { return _chordSearchQuery; }
            set { SetProperty(ref _chordSearchQuery, value); SearchChordsCommand.Execute(_chordSearchQuery); }
        }

        private ObservableCollection<ChordModel> _chordBuilderSearchResults = new ObservableCollection<ChordModel>();
        public ObservableCollection<ChordModel> ChordBuilderSearchResults
        {
            get { return _chordBuilderSearchResults; }
            set { SetProperty(ref _chordBuilderSearchResults, value); }
        }

        private ChordModel _selectedChordBuilderChord = new ChordModel();
        public ChordModel SelectedChordBuilderChord
        {
            get { return _selectedChordBuilderChord; }
            set { SetProperty(ref _selectedChordBuilderChord, value); }
        }

        private ChordModel _selectedWritingModeChord;
        public ChordModel SelectedWritingModeChord
        {
            get { return _selectedWritingModeChord; }
            set 
            { 
                if (value != null) 
                {
                    SetProperty(ref _selectedWritingModeChord, value); 

                    if (!ChordChart.IsPaused)
                        PauseToggleCommand.Execute();

                    ChordSearchQuery = _selectedWritingModeChord.Name; 
                }
            }
        }

        // /////////////////////////////////////////////////////////////////////////////////////////

        public DelegateCommand GenerateChordsCommand { get; set; }
        public DelegateCommand<string> SearchChordsCommand { get; set; }
        public DelegateCommand WriteNewChordCommand { get; set; }
        public DelegateCommand PauseToggleCommand { get; set; }
        public DelegateCommand ResetCommand { get; set; }
        public DelegateCommand PreviousChartCommand { get; set; }
        public DelegateCommand SaveChartCommand { get; set; }

        // /////////////////////////////////////////////////////////////////////////////////////////

        public ChartViewModel()
        {
            ChordBuilderSearchResults = new ObservableCollection<ChordModel>(ChordBuilderChords);

            GenerateChordsCommand = new DelegateCommand(() =>
            {
                // Does the ChartHistory have charts after this one? If so, skip forward to it instead of generate a new one
                if (ChartHistory.IndexOf(ChordChart) != ChartHistory.Count - 1)
                {
                    ChordChart = ChartHistory[ChartHistory.IndexOf(ChordChart) + 1];
                    return;
                }

                ChordChart = new ChartModel(ChordChart);
                ChordChart.GenerateChords(ChartHistory.Count);
                ChartHistory.Add(ChordChart);

                IsPreviousEnabled = ChartHistory.Count > 1;
            });

            SearchChordsCommand = new DelegateCommand<string>(s => 
            {
                ChordBuilderSearchResults = new ObservableCollection<ChordModel>(ChordBuilderChords.FindAll(c => c.Name.Contains(s, StringComparison.CurrentCultureIgnoreCase)));
            });

            WriteNewChordCommand = new DelegateCommand(() =>
            {
                SelectedWritingModeChord = SelectedChordBuilderChord;
            });

            PreviousChartCommand = new DelegateCommand(() =>
            {
                if (IsPreviousEnabled)
                {
                    int previousIndex = ChartHistory.IndexOf(ChordChart) - 1;
                    if (previousIndex <= 0) previousIndex = 0;
                    ChordChart = ChartHistory[previousIndex];
                }
            });

            PauseToggleCommand = new DelegateCommand(() =>
            {
                // Toggle boolean
                ChordChart.IsPaused = !ChordChart.IsPaused;

                if (ChordChart.IsPaused)
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
            });
        }
    }
}
