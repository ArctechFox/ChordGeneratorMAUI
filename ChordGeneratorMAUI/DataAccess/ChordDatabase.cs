using Manufaktura.Controls.Model;
using Manufaktura.Controls.Model.Collections;
using Manufaktura.Controls.Parser.MusicXml.Strategies;
using Manufaktura.Music.Model;
using Manufaktura.Music.Model.Harmony;
using Manufaktura.Music.Model.MajorAndMinor;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordGeneratorMAUI.DataAccess
{
    public static class ChordDatabase
    {
        public static Score Score { get; set; }

        public static Dictionary<string, Chord> Chords { get; set; } = new Dictionary<string, Chord>()
        {
            #region A

            { "Ab", TertianHarmony.CreateChord(Pitch.Ab1, 0, new MajorScale(Step.Ab, true)) },
            { "Ab7", TertianHarmony.Create7thChord(Pitch.Ab1, 0, new MajorScale(Step.Ab, true)) },
            { "Ab7", TertianHarmony.Create7thChord(Pitch.Ab1, 0, new MajorScale(Step.Ab, true)) },
            { "Abm", TertianHarmony.CreateChord(Pitch.Ab1, 0, new MinorScale(Step.Ab, true)) },
            { "Abm7", TertianHarmony.Create7thChord(Pitch.Ab1, 0, new MinorScale(Step.Ab, true)) },
            { "Abmaj7", TertianHarmony.Create7thChord(Pitch.Ab1, 0, new MajorScale(Step.Ab, true)) },

            { "A", TertianHarmony.CreateChord(Pitch.A1, 0, new MajorScale(Step.A, false)) },
            { "A7", TertianHarmony.Create7thChord(Pitch.A1, 0, new MajorScale(Step.A, false)) },
            { "Am", TertianHarmony.CreateChord(Pitch.A1, 0, new MinorScale(Step.A, false)) },
            { "Am7", TertianHarmony.Create7thChord(Pitch.A1, 0, new MinorScale(Step.A, false)) },
            { "Amaj7", TertianHarmony.Create7thChord(Pitch.A1, 0, new MajorScale(Step.A, false)) },

            { "A#", TertianHarmony.CreateChord(Pitch.A1, 0, new MajorScale(Step.A, false)) },
            { "A#7", TertianHarmony.Create7thChord(Pitch.A1, 0, new MajorScale(Step.A, false)) },
            { "A#m", TertianHarmony.CreateChord(Pitch.A1, 0, new MinorScale(Step.A, false)) },
            { "A#m7", TertianHarmony.Create7thChord(Pitch.A1, 0, new MinorScale(Step.A, false)) },
            { "A#maj7", TertianHarmony.Create7thChord(Pitch.A1, 0, new MajorScale(Step.A, false)) },

            #endregion

            #region B

            { "Bb", TertianHarmony.CreateChord(Pitch.Bb1, 0, new MajorScale(Step.Bb, true)) },
            { "Bb7", TertianHarmony.Create7thChord(Pitch.Bb1, 0, new MajorScale(Step.Bb, true)) },
            { "Bbm", TertianHarmony.CreateChord(Pitch.Bb1, 0, new MinorScale(Step.Bb, true)) },
            { "Bbm7", TertianHarmony.Create7thChord(Pitch.Bb1, 0, new MinorScale(Step.Bb, true)) },
            { "Bbmaj7", TertianHarmony.Create7thChord(Pitch.Bb1, 0, new MajorScale(Step.Bb, true)) },

            { "B", TertianHarmony.CreateChord(Pitch.B1, 0, new MajorScale(Step.B, false)) },
            { "B7", TertianHarmony.Create7thChord(Pitch.B1, 0, new MajorScale(Step.B, false)) },
            { "Bm", TertianHarmony.CreateChord(Pitch.B1, 0, new MinorScale(Step.B, false)) },
            { "Bm7", TertianHarmony.Create7thChord(Pitch.B1, 0, new MinorScale(Step.B, false)) },
            { "Bmaj7", TertianHarmony.Create7thChord(Pitch.B1, 0, new MajorScale(Step.B, false)) },

            { "B#", TertianHarmony.CreateChord(Pitch.BSharp1, 0, new MajorScale(Step.BSharp, false)) },
            { "B#7", TertianHarmony.Create7thChord(Pitch.BSharp1, 0, new MajorScale(Step.BSharp, false)) },
            { "B#m", TertianHarmony.CreateChord(Pitch.BSharp1, 0, new MinorScale(Step.BSharp, false)) },
            { "B#m7", TertianHarmony.Create7thChord(Pitch.BSharp1, 0, new MinorScale(Step.BSharp, false)) },
            { "B#maj7", TertianHarmony.Create7thChord(Pitch.BSharp1, 0, new MajorScale(Step.BSharp, false)) },

            #endregion

            #region C

            { "Cb", TertianHarmony.CreateChord(Pitch.Cb1, 0, new MajorScale(Step.Cb, true)) },
            { "Cb7", TertianHarmony.Create7thChord(Pitch.Cb1, 0, new MajorScale(Step.Cb, true)) },
            { "Cbm", TertianHarmony.CreateChord(Pitch.Cb1, 0, new MinorScale(Step.Cb, true)) },
            { "Cbm7", TertianHarmony.Create7thChord(Pitch.Cb1, 0, new MinorScale(Step.Cb, true)) },
            { "Cbmaj7", TertianHarmony.Create7thChord(Pitch.Cb1, 0, new MajorScale(Step.Cb, true)) },

            { "C", TertianHarmony.CreateChord(Pitch.C1, 0, new MajorScale(Step.C, false)) },
            { "C7", TertianHarmony.Create7thChord(Pitch.C1, 0, new MajorScale(Step.C, false)) },
            { "Cm", TertianHarmony.CreateChord(Pitch.C1, 0, new MinorScale(Step.C, false)) },
            { "Cm7", TertianHarmony.Create7thChord(Pitch.C1, 0, new MinorScale(Step.C, false)) },
            { "Cmaj7", TertianHarmony.Create7thChord(Pitch.C1, 0, new MajorScale(Step.C, false)) },

            { "C#", TertianHarmony.CreateChord(Pitch.CSharp1, 0, new MajorScale(Step.CSharp, false)) },
            { "C#7", TertianHarmony.Create7thChord(Pitch.CSharp1, 0, new MajorScale(Step.CSharp, false)) },
            { "C#m", TertianHarmony.CreateChord(Pitch.CSharp1, 0, new MinorScale(Step.CSharp, false)) },
            { "C#m7", TertianHarmony.Create7thChord(Pitch.CSharp1, 0, new MinorScale(Step.CSharp, false)) },
            { "C#maj7", TertianHarmony.Create7thChord(Pitch.CSharp1, 0, new MajorScale(Step.CSharp, false)) },

            #endregion

            #region D

            { "Db", TertianHarmony.CreateChord(Pitch.Db1, 0, new MajorScale(Step.Db, true)) },
            { "Db7", TertianHarmony.Create7thChord(Pitch.Db1, 0, new MajorScale(Step.Db, true)) },
            { "Dbm", TertianHarmony.CreateChord(Pitch.Db1, 0, new MinorScale(Step.Db, true)) },
            { "Dbm7", TertianHarmony.Create7thChord(Pitch.Db1, 0, new MinorScale(Step.Db, true)) },
            { "Dbmaj7", TertianHarmony.Create7thChord(Pitch.Db1, 0, new MajorScale(Step.Db, true)) },

            { "D", TertianHarmony.CreateChord(Pitch.D1, 0, new MajorScale(Step.D, false)) },
            { "D7", TertianHarmony.Create7thChord(Pitch.D1, 0, new MajorScale(Step.D, false)) },
            { "Dm", TertianHarmony.CreateChord(Pitch.D1, 0, new MinorScale(Step.D, false)) },
            { "Dm7", TertianHarmony.Create7thChord(Pitch.D1, 0, new MinorScale(Step.D, false)) },
            { "Dmaj7", TertianHarmony.Create7thChord(Pitch.D1, 0, new MajorScale(Step.D, false)) },

            { "D#", TertianHarmony.CreateChord(Pitch.DSharp1, 0, new MajorScale(Step.DSharp, false)) },
            { "D#7", TertianHarmony.Create7thChord(Pitch.DSharp1, 0, new MajorScale(Step.DSharp, false)) },
            { "D#m", TertianHarmony.CreateChord(Pitch.DSharp1, 0, new MinorScale(Step.DSharp, false)) },
            { "D#m7", TertianHarmony.Create7thChord(Pitch.DSharp1, 0, new MinorScale(Step.DSharp, false)) },
            { "D#maj7", TertianHarmony.Create7thChord(Pitch.DSharp1, 0, new MajorScale(Step.DSharp, false)) },

            #endregion

            #region E

            { "Eb", TertianHarmony.CreateChord(Pitch.Eb1, 0, new MajorScale(Step.Eb, true)) },
            { "Eb7", TertianHarmony.Create7thChord(Pitch.Eb1, 0, new MajorScale(Step.Eb, true)) },
            { "Ebm", TertianHarmony.CreateChord(Pitch.Eb1, 0, new MinorScale(Step.Eb, true)) },
            { "Ebm7", TertianHarmony.Create7thChord(Pitch.Eb1, 0, new MinorScale(Step.Eb, true)) },
            { "Ebmaj7", TertianHarmony.Create7thChord(Pitch.Eb1, 0, new MajorScale(Step.Eb, true)) },

            { "E", TertianHarmony.CreateChord(Pitch.D1, 0, new MajorScale(Step.E, false)) },
            { "E7", TertianHarmony.Create7thChord(Pitch.D1, 0, new MajorScale(Step.E, false)) },
            { "Em", TertianHarmony.CreateChord(Pitch.D1, 0, new MinorScale(Step.E, false)) },
            { "Em7", TertianHarmony.Create7thChord(Pitch.D1, 0, new MinorScale(Step.E, false)) },
            { "Emaj7", TertianHarmony.Create7thChord(Pitch.D1, 0, new MajorScale(Step.E, false)) },

            #endregion

        };

        //public static List<string> Chords = new List<string>
        //{
        //    "A",
        //    "B",
        //    "C",
        //    "D",
        //    "E",
        //    "F",
        //    "G",
        //    "A♭",
        //    "B♭",
        //    "C♭",
        //    "D♭",
        //    "E♭",
        //    "F♭",
        //    "G♭",
        //    "A#",
        //    "B#",
        //    "C#",
        //    "D#",
        //    "E#",
        //    "F#",
        //    "G#",
        //    "Amin",
        //    "Bmin",
        //    "Cmin",
        //    "Dmin",
        //    "Emin",
        //    "Fmin",
        //    "Gmin",
        //    "A♭min",
        //    "B♭min",
        //    "C♭min",
        //    "D♭min",
        //    "E♭min",
        //    "F♭min",
        //    "G♭min",
        //    "A#min",
        //    "B#min",
        //    "C#min",
        //    "D#min",
        //    "E#min",
        //    "F#min",
        //    "G#min",
        //    "A7",
        //    "B7",
        //    "C7",
        //    "D7",
        //    "E7",
        //    "F7",
        //    "G7",
        //    "A♭7",
        //    "B♭7",
        //    "C♭7",
        //    "D♭7",
        //    "E♭7",
        //    "F♭7",
        //    "G♭7",
        //    "A#7",
        //    "B#7",
        //    "C#7",
        //    "D#7",
        //    "E#7",
        //    "F#7",
        //    "G#7",
        //    "A -7",
        //    "B -7",
        //    "C -7",
        //    "D -7",
        //    "E -7",
        //    "F -7",
        //    "G -7",
        //    "A♭-7",
        //    "B♭-7",
        //    "C♭-7",
        //    "D♭-7",
        //    "E♭-7",
        //    "F♭-7",
        //    "G♭-7",
        //    "A# -7",
        //    "B# -7",
        //    "C# -7",
        //    "D# -7",
        //    "E# -7",
        //    "F# -7",
        //    "G# -7",
        //    "Amaj7",
        //    "Bmaj7",
        //    "Cmaj7",
        //    "Dmaj7",
        //    "Emaj7",
        //    "Fmaj7",
        //    "Gmaj7",
        //    "A♭maj7",
        //    "B♭maj7",
        //    "C♭maj7",
        //    "D♭maj7",
        //    "E♭maj7",
        //    "F♭maj7",
        //    "G♭maj7",
        //    "A#maj7",
        //    "B#maj7",
        //    "C#maj7",
        //    "D#maj7",
        //    "E#maj7",
        //    "F#maj7",
        //    "G#maj7",
        //};
    }
}
