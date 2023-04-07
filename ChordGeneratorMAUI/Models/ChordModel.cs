using Manufaktura.Music.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordGeneratorMAUI.Models
{
    public class ChordModel : BindableBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private Chord _chordData;
        public Chord ChordData
        {
            get { return _chordData; }
            set { SetProperty(ref _chordData, value); }
        }
    }
}
