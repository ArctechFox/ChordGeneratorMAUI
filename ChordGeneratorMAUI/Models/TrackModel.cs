using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
        }
        ~TrackModel()
        {
            AudioPlayer.Dispose();
        }

        private IAudioPlayer _audioPlayer;
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
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }

        private bool _isPlaying = false;
        public bool IsPlaying
        {
            get { return _isPlaying; }
            set { SetProperty(ref _isPlaying, value); }
        }

        /////////////////////////////////////////////////////////
        
        public DelegateCommand PlayPauseTrackToggleCommand { get; set; }

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
