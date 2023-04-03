﻿using ChordGeneratorMAUI.Helpers;
using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;

namespace ChordGeneratorMAUI.ViewModels
{
    public class MetronomeViewModel : BindableBase
    {
        private System.Timers.Timer _totalTimer;
        private System.Timers.Timer _beatTimer;

        // In miliseconds
        private readonly double _totalTimeInterval = 1000;

        public MetronomeViewModel()
        {
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
        }

        private TimeSpan _totalTimeElapsed = TimeSpan.Zero;
        public TimeSpan TotalTimeElapsed
        {
            get { return _totalTimeElapsed; }
            set { SetProperty(ref _totalTimeElapsed, value); }
        }

        private int _bpm = 80;
        public int BPM
        {
            get { return _bpm; }
            set
            {
                value = value > 0 ? value : 1;
                SetProperty(ref _bpm, value);
                _beatTimer.Interval = 60000 / BPM;
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
                value = value > TimeSignature ? 1 : value;
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
            TotalTimeElapsed = TimeSpan.Zero;
            CurrentBeat = 0;
            //ChartCount = ChartCount <= 0 ? 0 : ChartCount-1;
        }

        private void ChartGeneratedHandler()
        {
            ResetToDefaultSettings();
            StartTotalTimer();

            ChartCount++;
        }

        private void OnTotalTimerElapsed(object sender, ElapsedEventArgs e)
        {
            TotalTimeElapsed += TimeSpan.FromMilliseconds(_totalTimeInterval);
        }

        private void OnBeatTimerElapsed(object sender, ElapsedEventArgs e)
        {
            CurrentBeat++;

            Application.Current?.Dispatcher.Dispatch(() =>
            {
                Helpers.EventManager.Instance.EventAggregator.GetEvent<BeatElapsedEvent>().Publish(CurrentBeat);
            });
        }
    }
}
