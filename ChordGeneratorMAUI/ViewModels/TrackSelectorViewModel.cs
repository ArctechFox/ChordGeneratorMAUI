using ChordGeneratorMAUI.DataAccess;
using ChordGeneratorMAUI.Helpers;
using ChordGeneratorMAUI.Models;
using CommunityToolkit.Maui.Views;
using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using TimeSpan = System.TimeSpan;

namespace ChordGeneratorMAUI.ViewModels
{
    public sealed class TrackSelectorViewModel : BindableBase
    {
        private static readonly Lazy<TrackSelectorViewModel> lazy = new Lazy<TrackSelectorViewModel>(() => new TrackSelectorViewModel());
        public static TrackSelectorViewModel Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private TrackSelectorViewModel()
        {
            SetupTracks();
        }

        private List<TrackPackModel> _availableTrackPacks = new List<TrackPackModel>();
        public List<TrackPackModel> AvailableTrackPacks
        {
            get { return _availableTrackPacks; }
            set { SetProperty(ref _availableTrackPacks, value); }
        }

        private TrackPackModel _selectedTrackPack;
        public TrackPackModel SelectedTrackPack
        {
            get { return _selectedTrackPack; }
            set { SetProperty(ref _selectedTrackPack, value); }
        }

        private TrackModel _selectedTrack;
        public TrackModel SelectedTrack
        {
            get { return _selectedTrack; }
            set
            {
                if (SelectedTrack != null)
                    SelectedTrack.IsSelected = false;

                SetProperty(ref _selectedTrack, value);
                SelectedTrack.IsSelected = true;
            }
        }

        private bool _showTrackOptions = false;
        public bool ShowTrackOptions
        {
            get { return _showTrackOptions; }
            set { SetProperty(ref _showTrackOptions, value); }
        }

        /////////////////////////////////////////////////////////////////////////

        public DelegateCommand PlayPauseTrackToggleCommand { get; set; }

        /////////////////////////////////////////////////////////////////////////

        private async void SetupTracks()
        {
            await TrackManager.LoadTracks();

            AvailableTrackPacks = TrackManager.TrackPackLibrary;
            SelectedTrackPack = AvailableTrackPacks.FirstOrDefault();
        }

        private void PlaySelectedTrack()
        {
            SelectedTrack.Play();
        }

        private void StopSelectedTrack()
        {
            SelectedTrack.Stop();
        }
    }
}
