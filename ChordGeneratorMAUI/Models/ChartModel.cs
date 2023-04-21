using ChordGeneratorMAUI.DataAccess;
using ChordGeneratorMAUI.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChordGeneratorMAUI.DataAccess.ChordDatabase;
using static ChordGeneratorMAUI.Helpers.Converters;

namespace ChordGeneratorMAUI.Models
{
    public class ChartModel : BindableBase
    {
        public ChartModel()
        {
            
        }

        public ChartModel(ChartModel c)
        {
            this.SelectedKey = c.SelectedKey;
            this.BPM = c.BPM;
            this.BarCount = c.BarCount;
            this.TimeSignature = c.TimeSignature;
            this.ShowDiminishedAsMinor = c.ShowDiminishedAsMinor;
            this.LoopPlayback = c.LoopPlayback;

            this.IncludeChordType_All = c.IncludeChordType_All;
            this.IncludeChordType_Major = c.IncludeChordType_Major;
            this.IncludeChordType_Minor = c.IncludeChordType_Minor;
            this.IncludeChordType_7th = c.IncludeChordType_7th;

        }

        private readonly string _defaultChartName = "Chart #";

        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private ObservableCollection<ChordModel> _chords = new ObservableCollection<ChordModel>();

        public ObservableCollection<ChordModel> Chords
        {
            get { return _chords; }
            set { SetProperty(ref _chords, value); }
        }

        private int _bpm = 80;
        public int BPM
        {
            get { return _bpm; }
            set
            {
                value = value > 0 ? value : 1;
                SetProperty(ref _bpm, value);

                Application.Current?.Dispatcher.Dispatch(() =>
                {
                    Helpers.EventManager.Instance.EventAggregator.GetEvent<BPMChangedEvent>().Publish(_bpm);
                });
            }
        }

        // TODO: this is simplified for now
        private int _timeSignature = 4;
        public int TimeSignature
        {
            get { return _timeSignature; }
            set { SetProperty(ref _timeSignature, value); }
        }

        private int _barCount = 16;
        public int BarCount
        {
            get { return _barCount; }
            set
            {
                SetProperty(ref _barCount, value);

                Application.Current?.Dispatcher.Dispatch(() =>
                {
                    Helpers.EventManager.Instance.EventAggregator.GetEvent<BarCountChangedEvent>().Publish(_barCount);
                });
            }
        }

        private bool _showDiminishedAsMinor = true;
        public bool ShowDiminishedAsMinor
        {
            get { return _showDiminishedAsMinor; }
            set { SetProperty(ref _showDiminishedAsMinor, value); }
        }

        private bool _loopPlayback = true;
        public bool LoopPlayback
        {
            get { return _loopPlayback; }
            set { SetProperty(ref _loopPlayback, value); }
        }

        private bool _isPaused = true;
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

        // KEY OPTIONS

        private ObservableCollection<ChordModel> _filteredChords = new ObservableCollection<ChordModel>();
        public ObservableCollection<ChordModel> FilteredChords
        {
            get { return _filteredChords; }
            set { SetProperty(ref _filteredChords, value); }
        }

        private ObservableCollection<ChordModel> _keyChords = new ObservableCollection<ChordModel>();
        public ObservableCollection<ChordModel> KeyChords
        {
            get { return _keyChords; }
            set { SetProperty(ref _keyChords, value); }
        }

        private string _selectedKey = "All";
        public string SelectedKey
        {
            get { return _selectedKey; }
            set 
            { 
                SetProperty(ref _selectedKey, value);

                #region Filter by Key

                List<ChordModel> keyChords = AllChords;

                switch (_selectedKey)
                {
                    case "All": break;

                    case "Ab Major": keyChords = Key_Ab_Major_Chords; break;
                    case "A Major": keyChords = Key_A_Major_Chords; break;
                    case "Ab Minor": keyChords = Key_Ab_Minor_Chords; break;
                    case "A Minor": keyChords = Key_A_Minor_Chords; break;
                    case "A# Minor": keyChords = Key_ASharp_Minor_Chords; break;

                    case "Bb Major": keyChords = Key_Bb_Major_Chords; break;
                    case "B Major": keyChords = Key_B_Major_Chords; break;
                    case "Bb Minor": keyChords = Key_Bb_Minor_Chords; break;
                    case "B Minor": keyChords = Key_B_Minor_Chords; break;

                    case "Cb Major": keyChords = Key_Cb_Major_Chords; break;
                    case "C Major": keyChords = Key_C_Major_Chords; break;
                    case "C# Major": keyChords = Key_CSharp_Major_Chords; break;
                    case "C Minor": keyChords = Key_C_Minor_Chords; break;
                    case "C# Minor": keyChords = Key_CSharp_Minor_Chords; break;

                    case "Db Major": keyChords = Key_Db_Major_Chords; break;
                    case "D Major": keyChords = Key_D_Major_Chords; break;
                    case "D Minor": keyChords = Key_D_Minor_Chords; break;
                    case "D# Minor": keyChords = Key_DSharp_Minor_Chords; break;

                    case "Eb Major": keyChords = Key_Eb_Major_Chords; break;
                    case "E Major": keyChords = Key_E_Major_Chords; break;
                    case "Eb Minor": keyChords = Key_Eb_Minor_Chords; break;
                    case "E Minor": keyChords = Key_E_Minor_Chords; break;

                    case "F Major": keyChords = Key_F_Major_Chords; break;
                    case "F# Major": keyChords = Key_FSharp_Major_Chords; break;
                    case "F Minor": keyChords = Key_F_Minor_Chords; break;
                    case "F# Minor": keyChords = Key_FSharp_Minor_Chords; break;

                    case "Gb Major": keyChords = Key_Gb_Major_Chords; break;
                    case "G Major": keyChords = Key_G_Major_Chords; break;
                    case "G Minor": keyChords = Key_G_Minor_Chords; break;
                    case "G# Minor": keyChords = Key_GSharp_Minor_Chords; break;

                    case "8==D": keyChords = Key_D_Major_Chords; break; // ;)
                }

                KeyChords = new ObservableCollection<ChordModel>(keyChords);

                #endregion
            }
        }

        // CHORD OPTIONS

        private bool _includeChordType_All = true;
        public bool IncludeChordType_All
        {
            get { return _includeChordType_All; }
            set 
            { 
                SetProperty(ref _includeChordType_All, value); 
                if (value)
                {
                    IncludeChordType_Major = false;
                    IncludeChordType_Minor = false;
                    IncludeChordType_7th = false;
                }
            }
        }

        private bool _includeChordType_Major = false;
        public bool IncludeChordType_Major
        {
            get { return _includeChordType_Major; }
            set { SetProperty(ref _includeChordType_Major, value); if (value) IncludeChordType_All = false; }
        }

        private bool _includeChordType_Minor = false;
        public bool IncludeChordType_Minor
        {
            get { return _includeChordType_Minor; }
            set { SetProperty(ref _includeChordType_Minor, value); if (value) IncludeChordType_All = false; }
        }

        private bool _includeChordType_7th = false;
        public bool IncludeChordType_7th
        {
            get { return _includeChordType_7th; }
            set { SetProperty(ref _includeChordType_7th, value); if (value) IncludeChordType_All = false; }
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////

        // Provides the bindable enumeration of descriptions
        public IEnumerable<ChordTypes> ChordTypesValues
        {
            get { return Enum.GetValues(typeof(ChordTypes)).Cast<ChordTypes>(); }
        }

        private void ClearChordChart()
        {
            //_filteredChords.Clear();

            this.Chords = new ObservableCollection<ChordModel>();
            IsChordChartActive = false;
        }

        public ObservableCollection<ChordModel> GenerateChords(int chartHistoryCount)
        {
            ClearChordChart();

            #region Filter by Chord Type

            if (SelectedKey != "All")
            {
                FilteredChords = KeyChords;
            }
            else
            {
                FilteredChords = new ObservableCollection<ChordModel>(AllChords);
            }

            var filteredChordsList = FilteredChords.ToList();

            if (!IncludeChordType_All)
            {
                if (!IncludeChordType_Major)
                {
                    filteredChordsList.RemoveAll((c) => c.ChordType == ChordTypes.Major);
                }

                if (!IncludeChordType_Minor)
                {
                    filteredChordsList.RemoveAll((c) => c.ChordType == ChordTypes.Minor);
                    filteredChordsList.RemoveAll((c) => c.ChordType == ChordTypes.Diminished);
                }
                else if (ShowDiminishedAsMinor)
                {
                    filteredChordsList.RemoveAll((c) => c.ChordType == ChordTypes.Diminished);
                }
                else
                {
                    filteredChordsList.RemoveAll((c) => c.ChordType == ChordTypes.Minor);
                }

                if (!IncludeChordType_7th)
                {
                    filteredChordsList.RemoveAll((c) => c.ChordType == ChordTypes.Major7th);
                    filteredChordsList.RemoveAll((c) => c.ChordType == ChordTypes.Minor7th);
                    filteredChordsList.RemoveAll((c) => c.ChordType == ChordTypes.Dominant7th);
                    filteredChordsList.RemoveAll((c) => c.ChordType == ChordTypes.MinorSevenFlatFive);
                }
            }

            FilteredChords = new ObservableCollection<ChordModel>(filteredChordsList);

            #endregion

            if (FilteredChords.Any())
            {
                Random r = new Random();
                for (int i = 0; i < BarCount; i++)
                {
                    int n = r.Next(0, FilteredChords.Count);
                    Chords.Add(new ChordModel(FilteredChords[n]));
                }
            }
            
            this.Name = _defaultChartName + chartHistoryCount.ToString();

            IsChordChartActive = true;
            IsPaused = false;

            Application.Current?.Dispatcher.Dispatch(() =>
            {
                Helpers.EventManager.Instance.EventAggregator.GetEvent<ChartGeneratedEvent>().Publish();
            });

            return Chords;
        }
    }
}
