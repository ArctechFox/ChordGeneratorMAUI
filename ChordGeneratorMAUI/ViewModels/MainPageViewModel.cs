using ChordGeneratorMAUI.DataAccess;
using ChordGeneratorMAUI.Helpers;
using ChordGeneratorMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordGeneratorMAUI.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        // TODO: Make the UI a ListBox so we can hook it up to this list instead of 16 different chord models separately

        //private List<ChordModel> _chords;
        //public List<ChordModel> Chords
        //{
        //    get { return _chords; }
        //    set { SetProperty(ref _chords, value); }
        //}

        #region chord models

        private ChordModel _chord1 = new ChordModel();
        public ChordModel Chord1
        {
            get { return _chord1; }
            set { SetProperty(ref _chord1, value); }
        }

        private ChordModel _chord2 = new ChordModel();
        public ChordModel Chord2
        {
            get { return _chord2; }
            set { SetProperty(ref _chord2, value); }
        }

        private ChordModel _chord3 = new ChordModel();
        public ChordModel Chord3
        {
            get { return _chord3; }
            set { SetProperty(ref _chord3, value); }
        }

        private ChordModel _chord4 = new ChordModel();
        public ChordModel Chord4
        {
            get { return _chord4; }
            set { SetProperty(ref _chord4, value); }
        }

        private ChordModel _chord5 = new ChordModel();
        public ChordModel Chord5
        {
            get { return _chord5; }
            set { SetProperty(ref _chord5, value); }
        }

        private ChordModel _chord6 = new ChordModel();
        public ChordModel Chord6
        {
            get { return _chord6; }
            set { SetProperty(ref _chord6, value); }
        }

        private ChordModel _chord7 = new ChordModel();
        public ChordModel Chord7
        {
            get { return _chord7; }
            set { SetProperty(ref _chord7, value); }
        }

        private ChordModel _chord8 = new ChordModel();
        public ChordModel Chord8
        {
            get { return _chord8; }
            set { SetProperty(ref _chord8, value); }
        }

        private ChordModel _chord9 = new ChordModel();
        public ChordModel Chord9
        {
            get { return _chord9; }
            set { SetProperty(ref _chord9, value); }
        }

        private ChordModel _chord10 = new ChordModel();
        public ChordModel Chord10
        {
            get { return _chord10; }
            set { SetProperty(ref _chord10, value); }
        }

        private ChordModel _chord11 = new ChordModel();
        public ChordModel Chord11
        {
            get { return _chord11; }
            set { SetProperty(ref _chord11, value); }
        }

        private ChordModel _chord12 = new ChordModel();
        public ChordModel Chord12
        {
            get { return _chord12; }
            set { SetProperty(ref _chord12, value); }
        }

        private ChordModel _chord13 = new ChordModel();
        public ChordModel Chord13
        {
            get { return _chord13; }
            set { SetProperty(ref _chord13, value); }
        }

        private ChordModel _chord14 = new ChordModel();
        public ChordModel Chord14
        {
            get { return _chord14; }
            set { SetProperty(ref _chord14, value); }
        }

        private ChordModel _chord15 = new ChordModel();
        public ChordModel Chord15
        {
            get { return _chord15; }
            set { SetProperty(ref _chord15, value); }
        }

        private ChordModel _chord16 = new ChordModel();
        public ChordModel Chord16
        {
            get { return _chord16; }
            set { SetProperty(ref _chord16, value); }
        }

        #endregion


        public DelegateCommand GenerateChordsCommand { get; set; }

        public MainPageViewModel()
        {
            GenerateChordsCommand = new DelegateCommand(() =>
            {
                List<int> rNumbers = new List<int>();

                for (int i = 0; i < 16; i++)
                {
                    Random r = new Random();
                    int n = r.Next(0, ChordDatabase.Chords.Count);

                    rNumbers.Add(n);
                }

                Chord1.Name = ChordDatabase.Chords[rNumbers[0]];
                Chord2.Name = ChordDatabase.Chords[rNumbers[1]];
                Chord3.Name = ChordDatabase.Chords[rNumbers[2]];
                Chord4.Name = ChordDatabase.Chords[rNumbers[3]];
                Chord5.Name = ChordDatabase.Chords[rNumbers[4]];
                Chord6.Name = ChordDatabase.Chords[rNumbers[5]];
                Chord7.Name = ChordDatabase.Chords[rNumbers[6]];
                Chord8.Name = ChordDatabase.Chords[rNumbers[7]];
                Chord9.Name = ChordDatabase.Chords[rNumbers[8]];
                Chord10.Name = ChordDatabase.Chords[rNumbers[9]];
                Chord11.Name = ChordDatabase.Chords[rNumbers[10]];
                Chord12.Name = ChordDatabase.Chords[rNumbers[11]];
                Chord13.Name = ChordDatabase.Chords[rNumbers[12]];
                Chord14.Name = ChordDatabase.Chords[rNumbers[13]];
                Chord15.Name = ChordDatabase.Chords[rNumbers[14]];
                Chord16.Name = ChordDatabase.Chords[rNumbers[15]];

                Application.Current?.Dispatcher.Dispatch(() =>
                {
                    Helpers.EventManager.Instance.EventAggregator.GetEvent<ChartGeneratedEvent>().Publish();
                });
            });
        }
    }
}
