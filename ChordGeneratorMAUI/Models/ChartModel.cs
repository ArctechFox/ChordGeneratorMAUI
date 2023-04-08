using ChordGeneratorMAUI.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordGeneratorMAUI.Models
{
    public class ChartModel : BindableBase
    {
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

        private string _barCount = "16";
        public string BarCount
        {
            get { return _barCount; }
            set
            {
                SetProperty(ref _barCount, value);

                Application.Current?.Dispatcher.Dispatch(() =>
                {
                    Helpers.EventManager.Instance.EventAggregator.GetEvent<BarCountChangedEvent>().Publish(int.Parse(_barCount));
                });
            }
        }
    }
}
