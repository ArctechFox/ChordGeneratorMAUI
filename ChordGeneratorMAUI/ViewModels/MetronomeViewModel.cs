using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ChordGeneratorMAUI.ViewModels
{
    public class MetronomeViewModel : BindableBase
    {
        private System.Timers.Timer _timer;

        public MetronomeViewModel() 
        {
            _timer = new System.Timers.Timer();
            _timer.AutoReset = true;
            _timer.Elapsed += new ElapsedEventHandler(OnTimeElapsed);

            BPM = 80;
        }

        private int _bpm;
        public int BPM
        {
            get { return _bpm; }
            set 
            { 
                SetProperty(ref _bpm, value); 
                _timer.Interval = BPM; 
            }
        }

        // TODO: this is simplified for now
        private int _timeSignature = 4;
        public int TimeSignature
        {
            get { return _timeSignature; }
            set { SetProperty(ref _timeSignature, value); }
        }

        private int _currentBeat = 0;
        public int CurrentBeat
        {
            get { return _currentBeat; }
            set 
            {
                value = value > TimeSignature ? 0 : value;
                SetProperty(ref _currentBeat, value); 
            }
        }

        public void StartMetronome()
        {
            CurrentBeat = 0;
            _timer.Start();
        }

        public void StopMetronome()
        {
            CurrentBeat = 0;
            _timer.Stop();
        }

        private void OnTimeElapsed(object sender, ElapsedEventArgs e) 
        { 
            CurrentBeat++; 
        }
    }
}
