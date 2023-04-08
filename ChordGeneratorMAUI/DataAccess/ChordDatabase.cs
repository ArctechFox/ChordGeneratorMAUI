using ChordGeneratorMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordGeneratorMAUI.DataAccess
{
    public static class ChordDatabase
    {
        public static readonly List<ChordModel> AllChords = new List<ChordModel>
        {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "A♭",
            "B♭",
            "C♭",
            "D♭",
            "E♭",
            "F♭",
            "G♭",
            "A#",
            "B#",
            "C#",
            "D#",
            "E#",
            "F#",
            "G#",
            "Amin",
            "Bmin",
            "Cmin",
            "Dmin",
            "Emin",
            "Fmin",
            "Gmin",
            "A♭min",
            "B♭min",
            "C♭min",
            "D♭min",
            "E♭min",
            "F♭min",
            "G♭min",
            "A#min",
            "B#min",
            "C#min",
            "D#min",
            "E#min",
            "F#min",
            "G#min",
            "A7",
            "B7",
            "C7",
            "D7",
            "E7",
            "F7",
            "G7",
            "A♭7",
            "B♭7",
            "C♭7",
            "D♭7",
            "E♭7",
            "F♭7",
            "G♭7",
            "A#7",
            "B#7",
            "C#7",
            "D#7",
            "E#7",
            "F#7",
            "G#7",
            "A -7",
            "B -7",
            "C -7",
            "D -7",
            "E -7",
            "F -7",
            "G -7",
            "A♭-7",
            "B♭-7",
            "C♭-7",
            "D♭-7",
            "E♭-7",
            "F♭-7",
            "G♭-7",
            "A# -7",
            "B# -7",
            "C# -7",
            "D# -7",
            "E# -7",
            "F# -7",
            "G# -7",
            "Amaj7",
            "Bmaj7",
            "Cmaj7",
            "Dmaj7",
            "Emaj7",
            "Fmaj7",
            "Gmaj7",
            "A♭maj7",
            "B♭maj7",
            "C♭maj7",
            "D♭maj7",
            "E♭maj7",
            "F♭maj7",
            "G♭maj7",
            "A#maj7",
            "B#maj7",
            "C#maj7",
            "D#maj7",
            "E#maj7",
            "F#maj7",
            "G#maj7",
    };

        #region Major Chords

        public static readonly List<ChordModel> Key_Ab_Major_Chords = AllChords.FindAll((c) => 
                                                                                                                              c.Name == "Ab" ||
                                                                                                                              c.Name == "Bbm" ||
                                                                                                                              c.Name == "Cm" ||
                                                                                                                              c.Name == "Db" ||
                                                                                                                              c.Name == "Eb" ||
                                                                                                                              c.Name == "Fm" ||
                                                                                                                              c.Name == "G°");

        public static readonly List<ChordModel> Key_A_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "A" ||
                                                                                                                              c.Name == "Bm" ||
                                                                                                                              c.Name == "C#m" ||
                                                                                                                              c.Name == "D" ||
                                                                                                                              c.Name == "E" ||
                                                                                                                              c.Name == "F#m" ||
                                                                                                                              c.Name == "G#°");

        public static readonly List<ChordModel> Key_Bb_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "Bb" ||
                                                                                                                              c.Name == "Cm" ||
                                                                                                                              c.Name == "Dm" ||
                                                                                                                              c.Name == "Eb" ||
                                                                                                                              c.Name == "F" ||
                                                                                                                              c.Name == "Gm" ||
                                                                                                                              c.Name == "A°");

        public static readonly List<ChordModel> Key_B_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "B" ||
                                                                                                                              c.Name == "C#m" ||
                                                                                                                              c.Name == "D#m" ||
                                                                                                                              c.Name == "E" ||
                                                                                                                              c.Name == "F#" ||
                                                                                                                              c.Name == "G#m" ||
                                                                                                                              c.Name == "A#°");

        public static readonly List<ChordModel> Key_C_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "C" ||
                                                                                                                              c.Name == "Dm" ||
                                                                                                                              c.Name == "Em" ||
                                                                                                                              c.Name == "F" ||
                                                                                                                              c.Name == "G" ||
                                                                                                                              c.Name == "Am" ||
                                                                                                                              c.Name == "B°");

        public static readonly List<ChordModel> Key_CSharp_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "C#" ||
                                                                                                                              c.Name == "D#m" ||
                                                                                                                              c.Name == "E#m" ||
                                                                                                                              c.Name == "F#" ||
                                                                                                                              c.Name == "G#" ||
                                                                                                                              c.Name == "A#m" ||
                                                                                                                              c.Name == "B#°");

        public static readonly List<ChordModel> Key_Db_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "Db" ||
                                                                                                                              c.Name == "Ebm" ||
                                                                                                                              c.Name == "Fm" ||
                                                                                                                              c.Name == "Gb" ||
                                                                                                                              c.Name == "Ab" ||
                                                                                                                              c.Name == "Bbm" ||
                                                                                                                              c.Name == "C°");

        public static readonly List<ChordModel> Key_D_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "D" ||
                                                                                                                              c.Name == "Em" ||
                                                                                                                              c.Name == "F#m" ||
                                                                                                                              c.Name == "G" ||
                                                                                                                              c.Name == "A" ||
                                                                                                                              c.Name == "Bm" ||
                                                                                                                              c.Name == "C#°");

        public static readonly List<ChordModel> Key_Eb_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "Eb" ||
                                                                                                                              c.Name == "Fm" ||
                                                                                                                              c.Name == "Gm" ||
                                                                                                                              c.Name == "Ab" ||
                                                                                                                              c.Name == "Bb" ||
                                                                                                                              c.Name == "Cm" ||
                                                                                                                              c.Name == "D°");

        public static readonly List<ChordModel> Key_E_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "E" ||
                                                                                                                              c.Name == "F#m" ||
                                                                                                                              c.Name == "G#m" ||
                                                                                                                              c.Name == "A" ||
                                                                                                                              c.Name == "B" ||
                                                                                                                              c.Name == "C#m" ||
                                                                                                                              c.Name == "D#°");

        public static readonly List<ChordModel> Key_F_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "F" ||
                                                                                                                              c.Name == "Gm" ||
                                                                                                                              c.Name == "Am" ||
                                                                                                                              c.Name == "Bb" ||
                                                                                                                              c.Name == "C" ||
                                                                                                                              c.Name == "Dm" ||
                                                                                                                              c.Name == "E°");

        public static readonly List<ChordModel> Key_FSharp_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "F#" ||
                                                                                                                              c.Name == "G#m" ||
                                                                                                                              c.Name == "A#m" ||
                                                                                                                              c.Name == "B" ||
                                                                                                                              c.Name == "C#" ||
                                                                                                                              c.Name == "D#m" ||
                                                                                                                              c.Name == "E#°");

        public static readonly List<ChordModel> Key_Gb_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "Gb" ||
                                                                                                                              c.Name == "Abm" ||
                                                                                                                              c.Name == "Bbm" ||
                                                                                                                              c.Name == "Cb" ||
                                                                                                                              c.Name == "Db" ||
                                                                                                                              c.Name == "Ebm" ||
                                                                                                                              c.Name == "F°");

        public static readonly List<ChordModel> Key_G_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "G" ||
                                                                                                                              c.Name == "Am" ||
                                                                                                                              c.Name == "Bm" ||
                                                                                                                              c.Name == "C" ||
                                                                                                                              c.Name == "D" ||
                                                                                                                              c.Name == "Em" ||
                                                                                                                              c.Name == "F#°");

        #endregion

        #region Minor Chords

        public static readonly List<ChordModel> Key_Ab_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "Abm" ||
                                                                                                                              c.Name == "Bb°" ||
                                                                                                                              c.Name == "Cb" ||
                                                                                                                              c.Name == "Dbm" ||
                                                                                                                              c.Name == "Ebm" ||
                                                                                                                              c.Name == "Fb" ||
                                                                                                                              c.Name == "Gb");

        public static readonly List<ChordModel> Key_A_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "Am" ||
                                                                                                                              c.Name == "B°" ||
                                                                                                                              c.Name == "C" ||
                                                                                                                              c.Name == "Dm" ||
                                                                                                                              c.Name == "Em" ||
                                                                                                                              c.Name == "F" ||
                                                                                                                              c.Name == "G");

        public static readonly List<ChordModel> Key_ASharp_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "Bb" ||
                                                                                                                              c.Name == "Cm" ||
                                                                                                                              c.Name == "Dm" ||
                                                                                                                              c.Name == "Eb" ||
                                                                                                                              c.Name == "F" ||
                                                                                                                              c.Name == "Gm" ||
                                                                                                                              c.Name == "A°");

        public static readonly List<ChordModel> Key_Bb_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "B" ||
                                                                                                                              c.Name == "C#m" ||
                                                                                                                              c.Name == "D#m" ||
                                                                                                                              c.Name == "E" ||
                                                                                                                              c.Name == "F#" ||
                                                                                                                              c.Name == "G#m" ||
                                                                                                                              c.Name == "A#°");

        public static readonly List<ChordModel> Key_B_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "C" ||
                                                                                                                              c.Name == "Dm" ||
                                                                                                                              c.Name == "Em" ||
                                                                                                                              c.Name == "F" ||
                                                                                                                              c.Name == "G" ||
                                                                                                                              c.Name == "Am" ||
                                                                                                                              c.Name == "B°");

        public static readonly List<ChordModel> Key_C_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "C#" ||
                                                                                                                              c.Name == "D#m" ||
                                                                                                                              c.Name == "E#m" ||
                                                                                                                              c.Name == "F#" ||
                                                                                                                              c.Name == "G#" ||
                                                                                                                              c.Name == "A#m" ||
                                                                                                                              c.Name == "B#°");

        public static readonly List<ChordModel> Key_CSharp_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "Db" ||
                                                                                                                              c.Name == "Ebm" ||
                                                                                                                              c.Name == "Fm" ||
                                                                                                                              c.Name == "Gb" ||
                                                                                                                              c.Name == "Ab" ||
                                                                                                                              c.Name == "Bbm" ||
                                                                                                                              c.Name == "C°");

        public static readonly List<ChordModel> Key_D_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "D" ||
                                                                                                                              c.Name == "Em" ||
                                                                                                                              c.Name == "F#m" ||
                                                                                                                              c.Name == "G" ||
                                                                                                                              c.Name == "A" ||
                                                                                                                              c.Name == "Bm" ||
                                                                                                                              c.Name == "C#°");

        public static readonly List<ChordModel> Key_DSharp_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "Eb" ||
                                                                                                                              c.Name == "Fm" ||
                                                                                                                              c.Name == "Gm" ||
                                                                                                                              c.Name == "Ab" ||
                                                                                                                              c.Name == "Bb" ||
                                                                                                                              c.Name == "Cm" ||
                                                                                                                              c.Name == "D°");

        public static readonly List<ChordModel> Key_Eb_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "E" ||
                                                                                                                              c.Name == "F#m" ||
                                                                                                                              c.Name == "G#m" ||
                                                                                                                              c.Name == "A" ||
                                                                                                                              c.Name == "B" ||
                                                                                                                              c.Name == "C#m" ||
                                                                                                                              c.Name == "D#°");

        public static readonly List<ChordModel> Key_E_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "F" ||
                                                                                                                              c.Name == "Gm" ||
                                                                                                                              c.Name == "Am" ||
                                                                                                                              c.Name == "Bb" ||
                                                                                                                              c.Name == "C" ||
                                                                                                                              c.Name == "Dm" ||
                                                                                                                              c.Name == "E°");

        public static readonly List<ChordModel> Key_F_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "F#" ||
                                                                                                                              c.Name == "G#m" ||
                                                                                                                              c.Name == "A#m" ||
                                                                                                                              c.Name == "B" ||
                                                                                                                              c.Name == "C#" ||
                                                                                                                              c.Name == "D#m" ||
                                                                                                                              c.Name == "E#°");

        public static readonly List<ChordModel> Key_FSharp_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "Gb" ||
                                                                                                                              c.Name == "Abm" ||
                                                                                                                              c.Name == "Bbm" ||
                                                                                                                              c.Name == "Cb" ||
                                                                                                                              c.Name == "Db" ||
                                                                                                                              c.Name == "Ebm" ||
                                                                                                                              c.Name == "F°");

        public static readonly List<ChordModel> Key_G_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "G" ||
                                                                                                                              c.Name == "Am" ||
                                                                                                                              c.Name == "Bm" ||
                                                                                                                              c.Name == "C" ||
                                                                                                                              c.Name == "D" ||
                                                                                                                              c.Name == "Em" ||
                                                                                                                              c.Name == "F#°");

        public static readonly List<ChordModel> Key_GSharp_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "G" ||
                                                                                                                              c.Name == "Am" ||
                                                                                                                              c.Name == "Bm" ||
                                                                                                                              c.Name == "C" ||
                                                                                                                              c.Name == "D" ||
                                                                                                                              c.Name == "Em" ||
                                                                                                                              c.Name == "F#°");

        #endregion
    }
}
