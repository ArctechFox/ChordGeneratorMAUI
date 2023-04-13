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
            this.BPM = c.BPM;
            this.BarCount = c.BarCount;
            this.TimeSignature = c.TimeSignature;

            this.IncludeChordType_All = c.IncludeChordType_All;
            this.IncludeChordType_Major = c.IncludeChordType_Major;
            this.IncludeChordType_Minor = c.IncludeChordType_Minor;
            this.IncludeChordType_Major7th = c.IncludeChordType_Major7th;
            this.IncludeChordType_Minor7th = c.IncludeChordType_Minor7th;
            this.IncludeChordType_Dominant7th = c.IncludeChordType_Dominant7th;
            this.IncludeChordType_Diminished = c.IncludeChordType_Diminished;
            this.IncludeChordType_MinorSevenFlatFive = c.IncludeChordType_MinorSevenFlatFive;

            this.SelectedKey = c.SelectedKey;
        }

        private readonly string _defaultChartName = "Chart #";
        private List<ChordModel> _filteredChords = new List<ChordModel>();

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

        private string _selectedKey = "All";
        public string SelectedKey
        {
            get { return _selectedKey; }
            set { SetProperty(ref _selectedKey, value); }
        }

        // CHORD OPTIONS

        private bool _includeChordType_All = true;
        public bool IncludeChordType_All
        {
            get { return _includeChordType_All; }
            set { SetProperty(ref _includeChordType_All, value); }
        }

        private bool _includeChordType_Major = false;
        public bool IncludeChordType_Major
        {
            get { return _includeChordType_Major; }
            set { SetProperty(ref _includeChordType_Major, value); }
        }

        private bool _includeChordType_Minor = false;
        public bool IncludeChordType_Minor
        {
            get { return _includeChordType_Minor; }
            set { SetProperty(ref _includeChordType_Minor, value); }
        }

        private bool _includeChordType_Major7th = false;
        public bool IncludeChordType_Major7th
        {
            get { return _includeChordType_Major7th; }
            set { SetProperty(ref _includeChordType_Major7th, value); }
        }

        private bool _includeChordType_Minor7th = false;
        public bool IncludeChordType_Minor7th
        {
            get { return _includeChordType_Minor7th; }
            set { SetProperty(ref _includeChordType_Minor7th, value); }
        }

        private bool _includeChordType_Dominant7th = false;
        public bool IncludeChordType_Dominant7th
        {
            get { return _includeChordType_Dominant7th; }
            set { SetProperty(ref _includeChordType_Dominant7th, value); }
        }

        private bool _includeChordType_Diminished = false;
        public bool IncludeChordType_Diminished
        {
            get { return _includeChordType_Diminished; }
            set { SetProperty(ref _includeChordType_Diminished, value); }
        }

        private bool _includeChordType_MinorSevenFlatFive = false;
        public bool IncludeChordType_MinorSevenFlatFive
        {
            get { return _includeChordType_MinorSevenFlatFive; }
            set { SetProperty(ref _includeChordType_MinorSevenFlatFive, value); }
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////

        // Provides the bindable enumeration of descriptions
        public IEnumerable<ChordTypes> ChordTypesValues
        {
            get { return Enum.GetValues(typeof(ChordTypes)).Cast<ChordTypes>(); }
        }

        private void ClearChordChart()
        {
            _filteredChords.Clear();

            this.Chords = new ObservableCollection<ChordModel>();
            IsChordChartActive = false;
        }

        public ObservableCollection<ChordModel> GenerateChords(int chartHistoryCount)
        {
            ClearChordChart();

            #region Filter by Key
            switch (SelectedKey)
            {
                case "All": _filteredChords.AddRange( AllChords); break;

                case "Ab Major": _filteredChords.AddRange( Key_Ab_Major_Chords); break;
                case "A Major":  _filteredChords.AddRange( Key_A_Major_Chords); break;
                case "Ab Minor":  _filteredChords.AddRange( Key_Ab_Minor_Chords); break;
                case "A Minor":  _filteredChords.AddRange( Key_A_Minor_Chords); break;
                case "A# Minor":  _filteredChords.AddRange( Key_ASharp_Minor_Chords); break;

                case "Bb Major":  _filteredChords.AddRange( Key_Bb_Major_Chords); break;
                case "B Major":  _filteredChords.AddRange( Key_B_Major_Chords); break;
                case "Bb Minor":  _filteredChords.AddRange( Key_Bb_Minor_Chords); break;
                case "B Minor":  _filteredChords.AddRange( Key_B_Minor_Chords); break;

                case "Cb Major": _filteredChords.AddRange( Key_Cb_Major_Chords); break;
                case "C Major": _filteredChords.AddRange( Key_C_Major_Chords); break;
                case "C# Major": _filteredChords.AddRange( Key_CSharp_Major_Chords); break;
                case "C Minor": _filteredChords.AddRange( Key_C_Minor_Chords); break;
                case "C# Minor": _filteredChords.AddRange( Key_CSharp_Minor_Chords); break;

                case "Db Major": _filteredChords.AddRange( Key_Db_Major_Chords); break;
                case "D Major": _filteredChords.AddRange( Key_D_Major_Chords); break;
                case "D Minor": _filteredChords.AddRange( Key_D_Minor_Chords); break;
                case "D# Minor": _filteredChords.AddRange( Key_DSharp_Minor_Chords); break;

                case "Eb Major": _filteredChords.AddRange( Key_Eb_Major_Chords); break;
                case "E Major": _filteredChords.AddRange( Key_E_Major_Chords); break;
                case "Eb Minor": _filteredChords.AddRange( Key_Eb_Minor_Chords); break;
                case "E Minor": _filteredChords.AddRange( Key_E_Minor_Chords); break;

                case "F Major": _filteredChords.AddRange( Key_F_Major_Chords); break;
                case "F# Major": _filteredChords.AddRange( Key_FSharp_Major_Chords); break;
                case "F Minor": _filteredChords.AddRange( Key_F_Minor_Chords); break;
                case "F# Minor": _filteredChords.AddRange( Key_FSharp_Minor_Chords); break;

                case "Gb Major": _filteredChords.AddRange( Key_Gb_Major_Chords); break;
                case "G Major": _filteredChords.AddRange( Key_G_Major_Chords); break;
                case "G Minor": _filteredChords.AddRange( Key_G_Minor_Chords); break;
                case "G# Minor": _filteredChords.AddRange( Key_GSharp_Minor_Chords); break;
            }

            #endregion

            #region Filter by Chord Type

            if (!IncludeChordType_All)
            {
                if (!IncludeChordType_Major)
                {
                    _filteredChords.RemoveAll((c) => c.ChordType == ChordTypes.Major);
                }
                if (!IncludeChordType_Minor)
                {
                    _filteredChords.RemoveAll((c) => c.ChordType == ChordTypes.Minor);
                }
                if (!IncludeChordType_Major7th)
                {
                    _filteredChords.RemoveAll((c) => c.ChordType == ChordTypes.Major7th);
                }
                if (!IncludeChordType_Minor7th)
                {
                    _filteredChords.RemoveAll((c) => c.ChordType == ChordTypes.Minor7th);
                }
                if (!IncludeChordType_Dominant7th)
                {
                    _filteredChords.RemoveAll((c) => c.ChordType == ChordTypes.Dominant7th);
                }
                if (!IncludeChordType_Diminished)
                {
                    _filteredChords.RemoveAll((c) => c.ChordType == ChordTypes.Diminished);
                }
                if (!IncludeChordType_MinorSevenFlatFive)
                {
                    _filteredChords.RemoveAll((c) => c.ChordType == ChordTypes.MinorSevenFlatFive);
                }
            }

            #endregion

            if (_filteredChords.Any())
            {
                Random r = new Random();
                for (int i = 0; i < BarCount; i++)
                {
                    int n = r.Next(0, _filteredChords.Count);
                    Chords.Add(_filteredChords[n]);
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
