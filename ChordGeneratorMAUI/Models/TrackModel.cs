using ChordGeneratorMAUI.Helpers;
using Plugin.Maui.Audio;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static ChordGeneratorMAUI.DataAccess.ChordDatabase;
using static ChordGeneratorMAUI.Helpers.Converters;

namespace ChordGeneratorMAUI.Models
{
    public class TrackModel : BindableBase
    {
        public TrackModel()
        {
            // Initialize Commands
            PlayPauseTrackToggleCommand = new DelegateCommand(() =>
            {
                if (IsPlaying)
                    Stop();
                else
                    Play();
            });

            FavoriteToggleCommand = new DelegateCommand(() =>
            {
                Application.Current?.Dispatcher.Dispatch(() =>
                {
                    Helpers.EventManager.Instance.EventAggregator.GetEvent<ToggleFavoriteTrackEvent>().Publish(this);
                });
            });
        }
        ~TrackModel()
        {
            if (AudioPlayer != null)
                AudioPlayer.Dispose();
        }

        private IAudioPlayer _audioPlayer;
        [Ignore]
        public IAudioPlayer AudioPlayer
        {
            get { return _audioPlayer; }
            set { SetProperty(ref _audioPlayer, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _packName;
        public string PackName
        {
            get { return _packName; }
            set { SetProperty(ref _packName, value); }
        }

        private string _path;
        public string Path
        {
            get { return _path; }
            set { SetProperty(ref _path, value); }
        }

        private bool _isSelected = false;
        [Ignore]
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }

        private bool _isPlaying = false;
        [Ignore]
        public bool IsPlaying
        {
            get { return _isPlaying; }
            set { SetProperty(ref _isPlaying, value); }
        }

        private bool _isFavorited = false;
        public bool IsFavorited
        {
            get { return _isFavorited; }
            set { SetProperty(ref _isFavorited, value); }
        }

        /////////////////////////////////////////////////////////
        [Ignore]
        public DelegateCommand PlayPauseTrackToggleCommand { get; set; }
        [Ignore]
        public DelegateCommand FavoriteToggleCommand { get; set; }


        /////////////////////////////////////////////////////////

        public void Play()
        {
            if (AudioPlayer != null)
            {
                AudioPlayer.Play();
                IsPlaying = true;
            }
        }

        public void Stop()
        {
            if (AudioPlayer != null)
            {
                AudioPlayer.Stop();
                IsPlaying = false;
            }
        }
    }
}
