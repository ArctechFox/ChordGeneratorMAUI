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
            this.BarCount = c.BarCount;
            this.BPM = c.BPM;
            this.IncludedChordTypes = c.IncludedChordTypes;
            this.TimeSignature = c.TimeSignature;
        }

        private readonly string _defaultChartName = "Chart #";
        private List<ChordModel> _filteredChords = new List<ChordModel>();

        private string _chartName = "";
        public string ChartName
        {
            get { return _chartName; }
            set { SetProperty(ref _chartName, value); }
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

        private ObservableCollection<ChordTypes> _includedChordTypes = new ObservableCollection<ChordTypes> { ChordTypes.All };
        public ObservableCollection<ChordTypes> IncludedChordTypes
        {
            get { return _includedChordTypes; }
            set { SetProperty(ref _includedChordTypes, value); }
        }

        // Provides the bindable enumeration of descriptions
        public IEnumerable<string> ChordTypesValues
        {
            get { return Enum.GetValues(typeof(ChordTypes)).Cast<string>(); }
        }

        //public ObservableCollection<ChordModel> Filter()
        //{
        //    return new ObservableCollection<ChordModel>();
        //}

        private void ClearChordChart()
        {
            _filteredChords.Clear();

            this.Chords = new ObservableCollection<ChordModel>();
            IsChordChartActive = false;
        }

        public ObservableCollection<ChordModel> GenerateChords(int chartHistoryCount)
        {
            //ClearChordChart();

            if (IncludedChordTypes.Contains(ChordTypes.All))
            {
                _filteredChords = AllChords;
            }
            else
            {
                foreach (var c in IncludedChordTypes)
                {
                    switch (c)
                    {
                        // TODO: maybe cache these sub-collections so I dont gotta find them every time
                        case ChordTypes.Major:
                            _filteredChords.AddRange(ChordDatabase.AllChords.FindAll((c) => c.ChordType == ChordTypes.Major));
                            break;
                        case ChordTypes.Minor:
                            _filteredChords.AddRange(ChordDatabase.AllChords.FindAll((c) => c.ChordType == ChordTypes.Minor));
                            break;
                        case ChordTypes.Major7th:
                            _filteredChords.AddRange(ChordDatabase.AllChords.FindAll((c) => c.ChordType == ChordTypes.Major7th));
                            break;
                        case ChordTypes.Minor7th:
                            _filteredChords.AddRange(ChordDatabase.AllChords.FindAll((c) => c.ChordType == ChordTypes.Minor7th));
                            break;
                        case ChordTypes.Dominant7th:
                            _filteredChords.AddRange(ChordDatabase.AllChords.FindAll((c) => c.ChordType == ChordTypes.Dominant7th));
                            break;
                        case ChordTypes.Diminished:
                            _filteredChords.AddRange(ChordDatabase.AllChords.FindAll((c) => c.ChordType == ChordTypes.Diminished));
                            break;
                        default:
                            break;
                    }
                }
            }

            Random r = new Random();
            for (int i = 0; i < BarCount; i++)
            {
                int n = r.Next(0, _filteredChords.Count);
                Chords.Add(_filteredChords[n]);
            }
            
            this.ChartName = _defaultChartName + chartHistoryCount.ToString();

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
