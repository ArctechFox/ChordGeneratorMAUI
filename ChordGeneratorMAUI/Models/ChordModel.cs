using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChordGeneratorMAUI.DataAccess.ChordDatabase;

namespace ChordGeneratorMAUI.Models
{
    public class ChordModel : BindableBase
    {
        public ChordModel() { }

        public ChordModel(ChordModel copy)
        {
            this.Name = copy.Name;
            this.ChordType = copy.ChordType;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private ChordTypes _chordType;
        public ChordTypes ChordType
        {
            get { return _chordType; }
            set { SetProperty(ref _chordType, value); }
        }

        // Toggle this to show border highlight in WritingMode for chords that don't belong in selected key.
        private bool _belongsInKey = true;
        public bool BelongsInKey
        {
            get { return _belongsInKey; }
            set { SetProperty(ref _belongsInKey, value); }
        }
    }
}
