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
    public class TrackPackModel : BindableBase
    {
        public TrackPackModel() { }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private bool _isUnlocked = true;
        public bool IsUnlocked
        {
            get { return _isUnlocked; }
            set { SetProperty(ref _isUnlocked, value); }
        }

        private List<TrackModel> _tracks = new List<TrackModel>();
        public List<TrackModel> Tracks
        {
            get { return _tracks; }
            set { SetProperty(ref _tracks, value); }
        }
    }
}
