using ChordGeneratorMAUI.DataAccess;
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
    public class MainPageViewModel : BindableBase
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

        // /////////////////////////////////////////////////////////////////////////////////////////

        public DelegateCommand GenerateChordsCommand { get; set; }
        public DelegateCommand PauseToggleCommand { get; set; }
        public DelegateCommand ResetCommand { get; set; }
        public DelegateCommand PreviousChartCommand { get; set; }
        public DelegateCommand SaveChartCommand { get; set; }

        public MainPageViewModel()
        {
            GenerateChordsCommand = new DelegateCommand(() =>
            {
                // Does the ChartHistory have charts after this one? If so, skip forward to it instead of generate a new one
                if (ChartHistory.IndexOf(ChordChart) != ChartHistory.Count -1)
                {
                    ChordChart = ChartHistory[ChartHistory.IndexOf(ChordChart) + 1];
                    return;
                }

                ChordChart = new ChartModel(ChordChart);
                ChordChart.GenerateChords(ChartHistory.Count);
                ChartHistory.Add(ChordChart);

                IsPreviousEnabled = ChartHistory.Count > 1;
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
