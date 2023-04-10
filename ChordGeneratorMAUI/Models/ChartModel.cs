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

        //private string _includedKeys = true;
        //public bool IncludeAllKeys
        //{
        //    get { return _includeAllKeys; }
        //    set 
        //    { 
        //        SetProperty(ref _includeAllKeys, value); 

        //        // Toggle All
        //    }
        //}

        private ChordTypes _includedChordTypes = ChordTypes.All;
        public ChordTypes IncludedChordTypes
        {
            get { return _includedChordTypes; }
            set { SetProperty(ref _includedChordTypes, value); }
        }

        // Provides the bindable enumeration of descriptions
        public IEnumerable<ChordTypes> ChordTypesValues
        {
            get { return Enum.GetValues(typeof(ChordTypes)).Cast<ChordTypes>(); }
        }

        //public ObservableCollection<ChordModel> Filter()
        //{
        //    return new ObservableCollection<ChordModel>();
        //}

        private void ClearChordChart()
        {
            this.Chords = new ObservableCollection<ChordModel>();
            IsChordChartActive = false;
        }

        public ObservableCollection<ChordModel> GenerateChords(int chartHistoryCount)
        {
            ClearChordChart();

            List<ChordModel> filteredChords = ChordDatabase.AllChords;

            switch (IncludedChordTypes)
            {
                case ChordTypes.All:
                    filteredChords = ChordDatabase.AllChords;
                    break;
                case ChordTypes.Major: 
                    filteredChords = ChordDatabase.AllChords.FindAll((c) => c.ChordType == ChordTypes.Major);
                    break;
                case ChordTypes.Minor:
                    filteredChords = ChordDatabase.AllChords.FindAll((c) => c.ChordType == ChordTypes.Minor);
                    break;
                case ChordTypes.Major7th:
                    filteredChords = ChordDatabase.AllChords.FindAll((c) => c.ChordType == ChordTypes.Major7th);
                    break;
                case ChordTypes.Minor7th:
                    filteredChords = ChordDatabase.AllChords.FindAll((c) => c.ChordType == ChordTypes.Minor7th);
                    break;
                case ChordTypes.Dominant7th:
                    filteredChords = ChordDatabase.AllChords.FindAll((c) => c.ChordType == ChordTypes.Dominant7th);
                    break;
                case ChordTypes.Diminished:
                    filteredChords = ChordDatabase.AllChords.FindAll((c) => c.ChordType == ChordTypes.Diminished);
                    break;
                default:
                    break;
            }

            Random r = new Random();
            for (int i = 0; i < BarCount; i++)
            {
                int n = r.Next(0, filteredChords.Count);
                Chords.Add(filteredChords[n]);
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
