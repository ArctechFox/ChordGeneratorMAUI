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
    }
}
