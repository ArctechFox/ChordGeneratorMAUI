using ChordGeneratorMAUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChordGeneratorMAUI.Helpers.Converters;

namespace ChordGeneratorMAUI.DataAccess
{
    public static class ChordDatabase
    {
        [TypeConverter(typeof(EnumDescriptionConverter))]
        public enum ChordTypes
        {
            [Description("Major")]
            Major,
            [Description("Minor")]
            Minor,
            [Description("Major7th")]
            Major7th,
            [Description("Minor7th")]
            Minor7th,
            [Description("Dominant7th")]
            Dominant7th,
            [Description("Diminished")]
            Diminished,
            [Description("MinorSevenFlatFive")]
            MinorSevenFlatFive,

            [Description("All")]
            All = 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7,
        }


        public static readonly List<ChordModel> AllChords = new List<ChordModel>
        {
           new ChordModel(){ Name = "A", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "B", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "C", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "D", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "E", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "F", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "G", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "A♭", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "B♭", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "C♭", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "D♭", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "E♭", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "F♭", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "G♭", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "A#", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "B#", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "C#", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "D#", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "E#", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "F#", ChordType = ChordTypes.Major },
           new ChordModel(){ Name = "G#", ChordType = ChordTypes.Major },

           new ChordModel(){ Name = "Ami", ChordType = ChordTypes.Minor },
           new ChordModel(){ Name = "Bmi", ChordType = ChordTypes.Minor },
           new ChordModel(){ Name = "Cmi", ChordType = ChordTypes.Minor },
           new ChordModel(){ Name = "Dmi", ChordType = ChordTypes.Minor },
           new ChordModel(){ Name = "Emi", ChordType = ChordTypes.Minor },
           new ChordModel(){ Name = "Fmi", ChordType = ChordTypes.Minor },
           new ChordModel(){ Name = "Gmi", ChordType = ChordTypes.Minor },
           new ChordModel(){ Name = "A♭mi", ChordType = ChordTypes.Minor },
           new ChordModel(){ Name = "B♭mi", ChordType = ChordTypes.Minor },
           new ChordModel(){ Name = "C♭mi", ChordType = ChordTypes.Minor },
           new ChordModel(){ Name = "D♭mi", ChordType = ChordTypes.Minor },
           new ChordModel(){ Name = "E♭mi", ChordType = ChordTypes.Minor },
           new ChordModel(){ Name = "F♭mi", ChordType = ChordTypes.Minor },
           new ChordModel(){ Name = "G♭mi", ChordType = ChordTypes.Minor },
           new ChordModel(){ Name = "A#mi", ChordType = ChordTypes.Minor},
           new ChordModel(){ Name = "B#mi", ChordType = ChordTypes.Minor},
           new ChordModel(){ Name = "C#mi", ChordType = ChordTypes.Minor},
           new ChordModel(){ Name = "D#mi", ChordType = ChordTypes.Minor},
           new ChordModel(){ Name = "E#mi", ChordType = ChordTypes.Minor},
           new ChordModel(){ Name = "F#mi", ChordType = ChordTypes.Minor},
           new ChordModel(){ Name = "G#mi", ChordType = ChordTypes.Minor},

           new ChordModel(){ Name = "A7", ChordType = ChordTypes.Dominant7th },
           new ChordModel(){ Name = "B7", ChordType = ChordTypes.Dominant7th },
           new ChordModel(){ Name = "C7", ChordType = ChordTypes.Dominant7th },
           new ChordModel(){ Name = "D7", ChordType = ChordTypes.Dominant7th },
           new ChordModel(){ Name = "E7", ChordType = ChordTypes.Dominant7th },
           new ChordModel(){ Name = "F7", ChordType = ChordTypes.Dominant7th },
           new ChordModel(){ Name = "G7", ChordType = ChordTypes.Dominant7th },
           new ChordModel(){ Name = "A♭7", ChordType = ChordTypes.Dominant7th },
           new ChordModel(){ Name = "B♭7", ChordType = ChordTypes.Dominant7th },
           new ChordModel(){ Name = "C♭7", ChordType = ChordTypes.Dominant7th },
           new ChordModel(){ Name = "D♭7", ChordType = ChordTypes.Dominant7th },
           new ChordModel(){ Name = "E♭7", ChordType = ChordTypes.Dominant7th },
           new ChordModel(){ Name = "F♭7", ChordType = ChordTypes.Dominant7th },
           new ChordModel(){ Name = "G♭7", ChordType = ChordTypes.Dominant7th },
           new ChordModel(){ Name = "A#7", ChordType = ChordTypes.Dominant7th},
           new ChordModel(){ Name = "B#7", ChordType = ChordTypes.Dominant7th},
           new ChordModel(){ Name = "C#7", ChordType = ChordTypes.Dominant7th},
           new ChordModel(){ Name = "D#7", ChordType = ChordTypes.Dominant7th},
           new ChordModel(){ Name = "E#7", ChordType = ChordTypes.Dominant7th},
           new ChordModel(){ Name = "F#7", ChordType = ChordTypes.Dominant7th},
           new ChordModel(){ Name = "G#7", ChordType = ChordTypes.Dominant7th},

           new ChordModel(){ Name = "A-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "B-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "C-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "D-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "E-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "F-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "G-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "A♭-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "B♭-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "C♭-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "D♭-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "E♭-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "F♭-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "G♭-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "A#-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "B#-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "C#-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "D#-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "E#-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "F#-7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "G#-7", ChordType = ChordTypes.Minor7th },

           new ChordModel(){ Name = "AMa7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "BMa7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "CMa7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "DMa7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "EMa7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "FMa7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "GMa7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "A♭Ma7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "B♭Ma7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "C♭Ma7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "D♭Ma7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "E♭Ma7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "F♭Ma7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "G♭Ma7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "A#Ma7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "B#Ma7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "C#Ma7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "D#Ma7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "E#Ma7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "F#Ma7", ChordType = ChordTypes.Major7th },
           new ChordModel(){ Name = "G#Ma7", ChordType = ChordTypes.Major7th },

           new ChordModel(){ Name = "A°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "B°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "C°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "D°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "E°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "F°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "G°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "A♭°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "B♭°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "C♭°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "D♭°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "E♭°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "F♭°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "G♭°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "A#°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "B#°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "C#°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "D#°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "E#°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "F#°", ChordType = ChordTypes.Diminished },
           new ChordModel(){ Name = "G#°", ChordType = ChordTypes.Diminished },

           new ChordModel(){ Name = "A-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "B-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "C-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "D-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "E-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "F-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "G-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "A♭-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "B♭-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "C♭-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "D♭-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "E♭-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "F♭-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "G♭-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "A#-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "B#-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "C#-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "D#-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "E#-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "F#-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
           new ChordModel(){ Name = "G#-7♭5", ChordType = ChordTypes.MinorSevenFlatFive },
    };

        #region Major Chords

        public static readonly List<ChordModel> Key_Ab_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "A♭" ||
                                                                                                                              c.Name == "B♭mi" ||
                                                                                                                              c.Name == "Cmi" ||
                                                                                                                              c.Name == "D♭" ||
                                                                                                                              c.Name == "E♭" ||
                                                                                                                              c.Name == "Fmi" ||
                                                                                                                              c.Name == "G°" ||
                                                                                                                              c.Name == "Gmi" ||
                                                                                                                              c.Name == "A♭Ma7" ||
                                                                                                                              c.Name == "B♭-7" ||
                                                                                                                              c.Name == "C-7" ||
                                                                                                                              c.Name == "D♭Ma7" ||
                                                                                                                              c.Name == "E♭7" ||
                                                                                                                              c.Name == "F-7" ||
                                                                                                                              c.Name == "G-7♭5");

        public static readonly List<ChordModel> Key_A_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "A" ||
                                                                                                                              c.Name == "Bmi" ||
                                                                                                                              c.Name == "C#mi" ||
                                                                                                                              c.Name == "D" ||
                                                                                                                              c.Name == "E" ||
                                                                                                                              c.Name == "F#mi" ||
                                                                                                                              c.Name == "G#°" ||
                                                                                                                              c.Name == "G#mi" ||
                                                                                                                              c.Name == "AMa7" ||
                                                                                                                              c.Name == "B-7" ||
                                                                                                                              c.Name == "C#-7" ||
                                                                                                                              c.Name == "DMa7" ||
                                                                                                                              c.Name == "E7" ||
                                                                                                                              c.Name == "F#-7" ||
                                                                                                                              c.Name == "G#-7♭5");

        public static readonly List<ChordModel> Key_Bb_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "B♭" ||
                                                                                                                              c.Name == "Cmi" ||
                                                                                                                              c.Name == "Dmi" ||
                                                                                                                              c.Name == "E♭" ||
                                                                                                                              c.Name == "F" ||
                                                                                                                              c.Name == "Gmi" ||
                                                                                                                              c.Name == "A°" ||
                                                                                                                              c.Name == "Ami" ||
                                                                                                                              c.Name == "B♭Ma7" ||
                                                                                                                              c.Name == "C-7" ||
                                                                                                                              c.Name == "D-7" ||
                                                                                                                              c.Name == "E♭Ma7" ||
                                                                                                                              c.Name == "F7" ||
                                                                                                                              c.Name == "G-7" ||
                                                                                                                              c.Name == "A-7♭5");

        public static readonly List<ChordModel> Key_B_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "B" ||
                                                                                                                              c.Name == "C#mi" ||
                                                                                                                              c.Name == "D#mi" ||
                                                                                                                              c.Name == "E" ||
                                                                                                                              c.Name == "F#" ||
                                                                                                                              c.Name == "G#mi" ||
                                                                                                                              c.Name == "A#°" ||
                                                                                                                              c.Name == "A#mi" ||
                                                                                                                              c.Name == "BMa7" ||
                                                                                                                              c.Name == "C#-7" ||
                                                                                                                              c.Name == "D#-7" ||
                                                                                                                              c.Name == "EMa7" ||
                                                                                                                              c.Name == "F#7" ||
                                                                                                                              c.Name == "G#-7" ||
                                                                                                                              c.Name == "A#-7♭5");

        public static readonly List<ChordModel> Key_Cb_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "Cb" ||
                                                                                                                              c.Name == "Dbmi" ||
                                                                                                                              c.Name == "Ebmi" ||
                                                                                                                              c.Name == "Fb" ||
                                                                                                                              c.Name == "Gb" ||
                                                                                                                              c.Name == "Abmi" ||
                                                                                                                              c.Name == "Bb°" ||
                                                                                                                              c.Name == "Bbmi" ||
                                                                                                                              c.Name == "CbMa7" ||
                                                                                                                              c.Name == "Db-7" ||
                                                                                                                              c.Name == "Eb-7" ||
                                                                                                                              c.Name == "FbMa7" ||
                                                                                                                              c.Name == "Gb7" ||
                                                                                                                              c.Name == "Ab-7" ||
                                                                                                                              c.Name == "Bb-7♭5");

        public static readonly List<ChordModel> Key_C_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "C" ||
                                                                                                                              c.Name == "Dmi" ||
                                                                                                                              c.Name == "Emi" ||
                                                                                                                              c.Name == "F" ||
                                                                                                                              c.Name == "G" ||
                                                                                                                              c.Name == "Ami" ||
                                                                                                                              c.Name == "B°" ||
                                                                                                                              c.Name == "Bmi" ||
                                                                                                                              c.Name == "CMa7" ||
                                                                                                                              c.Name == "D-7" ||
                                                                                                                              c.Name == "E-7" ||
                                                                                                                              c.Name == "FMa7" ||
                                                                                                                              c.Name == "G7" ||
                                                                                                                              c.Name == "A-7" ||
                                                                                                                              c.Name == "B-7♭5");

        public static readonly List<ChordModel> Key_CSharp_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "C#" ||
                                                                                                                              c.Name == "D#mi" ||
                                                                                                                              c.Name == "E#mi" ||
                                                                                                                              c.Name == "F#" ||
                                                                                                                              c.Name == "G#" ||
                                                                                                                              c.Name == "A#mi" ||
                                                                                                                              c.Name == "B#°" ||
                                                                                                                              c.Name == "B#mi" ||
                                                                                                                              c.Name == "C#Ma7" ||
                                                                                                                              c.Name == "D#-7" ||
                                                                                                                              c.Name == "E#-7" ||
                                                                                                                              c.Name == "F#Ma7" ||
                                                                                                                              c.Name == "G#7" ||
                                                                                                                              c.Name == "A#-7" ||
                                                                                                                              c.Name == "B#-7♭5");

        public static readonly List<ChordModel> Key_Db_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "D♭" ||
                                                                                                                              c.Name == "E♭mi" ||
                                                                                                                              c.Name == "Fmi" ||
                                                                                                                              c.Name == "G♭" ||
                                                                                                                              c.Name == "A♭" ||
                                                                                                                              c.Name == "B♭mi" ||
                                                                                                                              c.Name == "C°" ||
                                                                                                                              c.Name == "Cmi" ||
                                                                                                                              c.Name == "D♭Ma7" ||
                                                                                                                              c.Name == "E♭-7" ||
                                                                                                                              c.Name == "F-7" ||
                                                                                                                              c.Name == "G♭Ma7" ||
                                                                                                                              c.Name == "A♭7" ||
                                                                                                                              c.Name == "B♭-7" ||
                                                                                                                              c.Name == "C-7♭5");

        public static readonly List<ChordModel> Key_D_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "D" ||
                                                                                                                              c.Name == "Emi" ||
                                                                                                                              c.Name == "F#mi" ||
                                                                                                                              c.Name == "G" ||
                                                                                                                              c.Name == "A" ||
                                                                                                                              c.Name == "Bmi" ||
                                                                                                                              c.Name == "C#°" ||
                                                                                                                              c.Name == "C#mi" ||
                                                                                                                              c.Name == "DMa7" ||
                                                                                                                              c.Name == "E-7" ||
                                                                                                                              c.Name == "F#-7" ||
                                                                                                                              c.Name == "GMa7" ||
                                                                                                                              c.Name == "A7" ||
                                                                                                                              c.Name == "B-7" ||
                                                                                                                              c.Name == "C#-7♭5");

        public static readonly List<ChordModel> Key_Eb_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "E♭" ||
                                                                                                                              c.Name == "Fmi" ||
                                                                                                                              c.Name == "Gmi" ||
                                                                                                                              c.Name == "A♭" ||
                                                                                                                              c.Name == "B♭" ||
                                                                                                                              c.Name == "Cmi" ||
                                                                                                                              c.Name == "D°" ||
                                                                                                                              c.Name == "Dmi" ||
                                                                                                                              c.Name == "E♭Ma7" ||
                                                                                                                              c.Name == "F-7" ||
                                                                                                                              c.Name == "G-7" ||
                                                                                                                              c.Name == "A♭Ma7" ||
                                                                                                                              c.Name == "B♭7" ||
                                                                                                                              c.Name == "C-7" ||
                                                                                                                              c.Name == "D-7♭5");

        public static readonly List<ChordModel> Key_E_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "E" ||
                                                                                                                              c.Name == "F#mi" ||
                                                                                                                              c.Name == "G#mi" ||
                                                                                                                              c.Name == "A" ||
                                                                                                                              c.Name == "B" ||
                                                                                                                              c.Name == "C#mi" ||
                                                                                                                              c.Name == "D#°" ||
                                                                                                                              c.Name == "D#mi" ||
                                                                                                                              c.Name == "EMa7" ||
                                                                                                                              c.Name == "F#-7" ||
                                                                                                                              c.Name == "G#-7" ||
                                                                                                                              c.Name == "AMa7" ||
                                                                                                                              c.Name == "B7" ||
                                                                                                                              c.Name == "C#-7" ||
                                                                                                                              c.Name == "D#-7♭5");

        public static readonly List<ChordModel> Key_F_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "F" ||
                                                                                                                              c.Name == "Gmi" ||
                                                                                                                              c.Name == "Ami" ||
                                                                                                                              c.Name == "B♭" ||
                                                                                                                              c.Name == "C" ||
                                                                                                                              c.Name == "Dmi" ||
                                                                                                                              c.Name == "E°" ||
                                                                                                                              c.Name == "Emi" ||
                                                                                                                              c.Name == "FMa7" ||
                                                                                                                              c.Name == "G-7" ||
                                                                                                                              c.Name == "A-7" ||
                                                                                                                              c.Name == "B♭Ma7" ||
                                                                                                                              c.Name == "C7" ||
                                                                                                                              c.Name == "D-7" ||
                                                                                                                              c.Name == "E-7♭5");

        public static readonly List<ChordModel> Key_FSharp_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "F#" ||
                                                                                                                              c.Name == "G#mi" ||
                                                                                                                              c.Name == "A#mi" ||
                                                                                                                              c.Name == "B" ||
                                                                                                                              c.Name == "C#" ||
                                                                                                                              c.Name == "D#mi" ||
                                                                                                                              c.Name == "E#°" ||
                                                                                                                              c.Name == "E#mi" ||
                                                                                                                              c.Name == "F#Ma7" ||
                                                                                                                              c.Name == "G#-7" ||
                                                                                                                              c.Name == "A#-7" ||
                                                                                                                              c.Name == "BMa7" ||
                                                                                                                              c.Name == "C#7" ||
                                                                                                                              c.Name == "D#-7" ||
                                                                                                                              c.Name == "E#-7♭5");

        public static readonly List<ChordModel> Key_Gb_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "G♭" ||
                                                                                                                              c.Name == "A♭mi" ||
                                                                                                                              c.Name == "B♭mi" ||
                                                                                                                              c.Name == "C♭" ||
                                                                                                                              c.Name == "D♭" ||
                                                                                                                              c.Name == "E♭mi" ||
                                                                                                                              c.Name == "F°" ||
                                                                                                                              c.Name == "Fmi" ||
                                                                                                                              c.Name == "G♭Ma7" ||
                                                                                                                              c.Name == "A♭-7" ||
                                                                                                                              c.Name == "B♭-7" ||
                                                                                                                              c.Name == "C♭Ma7" ||
                                                                                                                              c.Name == "D♭7" ||
                                                                                                                              c.Name == "E♭7" ||
                                                                                                                              c.Name == "F-7♭5");

        public static readonly List<ChordModel> Key_G_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "G" ||
                                                                                                                              c.Name == "Ami" ||
                                                                                                                              c.Name == "Bmi" ||
                                                                                                                              c.Name == "C" ||
                                                                                                                              c.Name == "D" ||
                                                                                                                              c.Name == "Emi" ||
                                                                                                                              c.Name == "F#°" ||
                                                                                                                              c.Name == "F#mi" ||
                                                                                                                              c.Name == "GMa7" ||
                                                                                                                              c.Name == "A-7" ||
                                                                                                                              c.Name == "B-7" ||
                                                                                                                              c.Name == "CMa7" ||
                                                                                                                              c.Name == "D7" ||
                                                                                                                              c.Name == "E7" ||
                                                                                                                              c.Name == "F#-7♭5");

        #endregion

        #region Minor Chords

        public static readonly List<ChordModel> Key_Ab_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "A♭mi" ||
                                                                                                                              c.Name == "B♭°" ||
                                                                                                                              c.Name == "B♭mi" ||
                                                                                                                              c.Name == "C♭" ||
                                                                                                                              c.Name == "D♭mi" ||
                                                                                                                              c.Name == "E♭mi" ||
                                                                                                                              c.Name == "F♭" ||
                                                                                                                              c.Name == "G♭" ||
                                                                                                                              c.Name == "A♭-7" ||
                                                                                                                              c.Name == "B♭-7♭5" ||
                                                                                                                              c.Name == "C♭Ma7" ||
                                                                                                                              c.Name == "D♭-7" ||
                                                                                                                              c.Name == "E♭-7" ||
                                                                                                                              c.Name == "F♭Ma7" ||
                                                                                                                              c.Name == "G♭7");

        public static readonly List<ChordModel> Key_A_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "Ami" ||
                                                                                                                              c.Name == "B°" ||
                                                                                                                              c.Name == "Bmi" ||
                                                                                                                              c.Name == "C" ||
                                                                                                                              c.Name == "Dmi" ||
                                                                                                                              c.Name == "Emi" ||
                                                                                                                              c.Name == "F" ||
                                                                                                                              c.Name == "G" ||
                                                                                                                              c.Name == "A-7" ||
                                                                                                                              c.Name == "B-7♭5" ||
                                                                                                                              c.Name == "CMa7" ||
                                                                                                                              c.Name == "D-7" ||
                                                                                                                              c.Name == "E-7" ||
                                                                                                                              c.Name == "FMa7" ||
                                                                                                                              c.Name == "G7");

        public static readonly List<ChordModel> Key_ASharp_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "A#mi" ||
                                                                                                                              c.Name == "B#°" ||
                                                                                                                              c.Name == "B#mi" ||
                                                                                                                              c.Name == "C#" ||
                                                                                                                              c.Name == "D#mi" ||
                                                                                                                              c.Name == "E#mi" ||
                                                                                                                              c.Name == "F#" ||
                                                                                                                              c.Name == "G#" ||
                                                                                                                              c.Name == "A#-7" ||
                                                                                                                              c.Name == "B#-7♭5" ||
                                                                                                                              c.Name == "C#Ma7" ||
                                                                                                                              c.Name == "D#-7" ||
                                                                                                                              c.Name == "E#-7" ||
                                                                                                                              c.Name == "F#Ma7" ||
                                                                                                                              c.Name == "G#7");

        public static readonly List<ChordModel> Key_Bb_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "B♭mi" ||
                                                                                                                              c.Name == "C°" ||
                                                                                                                              c.Name == "Cmi" ||
                                                                                                                              c.Name == "D♭" ||
                                                                                                                              c.Name == "E♭mi" ||
                                                                                                                              c.Name == "Fmi" ||
                                                                                                                              c.Name == "G♭" ||
                                                                                                                              c.Name == "A♭" ||
                                                                                                                              c.Name == "B♭-7" ||
                                                                                                                              c.Name == "C-7♭5" ||
                                                                                                                              c.Name == "D♭Ma7" ||
                                                                                                                              c.Name == "E♭-7" ||
                                                                                                                              c.Name == "F-7" ||
                                                                                                                              c.Name == "G♭Ma7" ||
                                                                                                                              c.Name == "A♭7");

        public static readonly List<ChordModel> Key_B_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "Bmi" ||
                                                                                                                              c.Name == "C#°" ||
                                                                                                                              c.Name == "C#mi" ||
                                                                                                                              c.Name == "D" ||
                                                                                                                              c.Name == "Emi" ||
                                                                                                                              c.Name == "F#mi" ||
                                                                                                                              c.Name == "G" ||
                                                                                                                              c.Name == "A" ||
                                                                                                                              c.Name == "B-7" ||
                                                                                                                              c.Name == "C#-7♭5" ||
                                                                                                                              c.Name == "DMa7" ||
                                                                                                                              c.Name == "E-7" ||
                                                                                                                              c.Name == "F#-7" ||
                                                                                                                              c.Name == "GMa7" ||
                                                                                                                              c.Name == "A7");

        public static readonly List<ChordModel> Key_C_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "Cmi" ||
                                                                                                                              c.Name == "D°" ||
                                                                                                                              c.Name == "Dmi" ||
                                                                                                                              c.Name == "E♭" ||
                                                                                                                              c.Name == "Fmi" ||
                                                                                                                              c.Name == "Gmi" ||
                                                                                                                              c.Name == "A♭" ||
                                                                                                                              c.Name == "B♭" ||
                                                                                                                              c.Name == "C-7" ||
                                                                                                                              c.Name == "D-7♭5" ||
                                                                                                                              c.Name == "E♭Ma7" ||
                                                                                                                              c.Name == "F-7" ||
                                                                                                                              c.Name == "G-7" ||
                                                                                                                              c.Name == "A♭Ma7" ||
                                                                                                                              c.Name == "B♭7");

        public static readonly List<ChordModel> Key_CSharp_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "C#mi" ||
                                                                                                                              c.Name == "D#°" ||
                                                                                                                              c.Name == "D#mi" ||
                                                                                                                              c.Name == "E" ||
                                                                                                                              c.Name == "F#mi" ||
                                                                                                                              c.Name == "G#mi" ||
                                                                                                                              c.Name == "A" ||
                                                                                                                              c.Name == "B" ||
                                                                                                                              c.Name == "C#-7" ||
                                                                                                                              c.Name == "D#-7♭5" ||
                                                                                                                              c.Name == "EMa7" ||
                                                                                                                              c.Name == "F#-7" ||
                                                                                                                              c.Name == "G#-7" ||
                                                                                                                              c.Name == "AMa7" ||
                                                                                                                              c.Name == "B7");

        public static readonly List<ChordModel> Key_D_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "Dmi" ||
                                                                                                                              c.Name == "E°" ||
                                                                                                                              c.Name == "Emi" ||
                                                                                                                              c.Name == "F" ||
                                                                                                                              c.Name == "Gmi" ||
                                                                                                                              c.Name == "Ami" ||
                                                                                                                              c.Name == "B♭" ||
                                                                                                                              c.Name == "C" ||
                                                                                                                              c.Name == "D-7" ||
                                                                                                                              c.Name == "E-7♭5" ||
                                                                                                                              c.Name == "FMa7" ||
                                                                                                                              c.Name == "G-7" ||
                                                                                                                              c.Name == "A-7" ||
                                                                                                                              c.Name == "B♭Ma7" ||
                                                                                                                              c.Name == "C7");

        public static readonly List<ChordModel> Key_DSharp_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "D#mi" ||
                                                                                                                              c.Name == "E#°" ||
                                                                                                                              c.Name == "E#mi" ||
                                                                                                                              c.Name == "F#" ||
                                                                                                                              c.Name == "G#mi" ||
                                                                                                                              c.Name == "A#mi" ||
                                                                                                                              c.Name == "B" ||
                                                                                                                              c.Name == "C#" ||
                                                                                                                              c.Name == "D#-7" ||
                                                                                                                              c.Name == "E#-7♭5" ||
                                                                                                                              c.Name == "F#Ma7" ||
                                                                                                                              c.Name == "G#-7" ||
                                                                                                                              c.Name == "A#-7" ||
                                                                                                                              c.Name == "BMa7" ||
                                                                                                                              c.Name == "C#7");

        public static readonly List<ChordModel> Key_Eb_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "E♭mi" ||
                                                                                                                              c.Name == "F°" ||
                                                                                                                              c.Name == "Fmi" ||
                                                                                                                              c.Name == "G♭" ||
                                                                                                                              c.Name == "A♭mi" ||
                                                                                                                              c.Name == "B♭mi" ||
                                                                                                                              c.Name == "C♭" ||
                                                                                                                              c.Name == "D♭" ||
                                                                                                                              c.Name == "E♭-7" ||
                                                                                                                              c.Name == "F-7♭5" ||
                                                                                                                              c.Name == "G♭Ma7" ||
                                                                                                                              c.Name == "A♭-7" ||
                                                                                                                              c.Name == "B♭-7" ||
                                                                                                                              c.Name == "C♭Ma7" ||
                                                                                                                              c.Name == "D♭7");

        public static readonly List<ChordModel> Key_E_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "Emi" ||
                                                                                                                              c.Name == "F#°" ||
                                                                                                                              c.Name == "F#mi" ||
                                                                                                                              c.Name == "G" ||
                                                                                                                              c.Name == "Ami" ||
                                                                                                                              c.Name == "Bmi" ||
                                                                                                                              c.Name == "C" ||
                                                                                                                              c.Name == "D" ||
                                                                                                                              c.Name == "E-7" ||
                                                                                                                              c.Name == "F#-7♭5" ||
                                                                                                                              c.Name == "GMa7" ||
                                                                                                                              c.Name == "A-7" ||
                                                                                                                              c.Name == "B-7" ||
                                                                                                                              c.Name == "CMa7" ||
                                                                                                                              c.Name == "D7");

        public static readonly List<ChordModel> Key_F_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "Fmi" ||
                                                                                                                              c.Name == "G°" ||
                                                                                                                              c.Name == "Gmi" ||
                                                                                                                              c.Name == "A♭" ||
                                                                                                                              c.Name == "B♭mi" ||
                                                                                                                              c.Name == "Cmi" ||
                                                                                                                              c.Name == "D♭" ||
                                                                                                                              c.Name == "E♭" ||
                                                                                                                              c.Name == "F-7" ||
                                                                                                                              c.Name == "G-7♭5" ||
                                                                                                                              c.Name == "A♭Ma7" ||
                                                                                                                              c.Name == "B♭-7" ||
                                                                                                                              c.Name == "C-7" ||
                                                                                                                              c.Name == "D♭Ma7" ||
                                                                                                                              c.Name == "E♭7");

        public static readonly List<ChordModel> Key_FSharp_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "F#mi" ||
                                                                                                                              c.Name == "G#°" ||
                                                                                                                              c.Name == "G#mi" ||
                                                                                                                              c.Name == "A" ||
                                                                                                                              c.Name == "Bmi" ||
                                                                                                                              c.Name == "C#mi" ||
                                                                                                                              c.Name == "D" ||
                                                                                                                              c.Name == "E" ||
                                                                                                                              c.Name == "F#-7" ||
                                                                                                                              c.Name == "G#-7♭5" ||
                                                                                                                              c.Name == "AMa7" ||
                                                                                                                              c.Name == "B-7" ||
                                                                                                                              c.Name == "C#-7" ||
                                                                                                                              c.Name == "DMa7" ||
                                                                                                                              c.Name == "E7");

        public static readonly List<ChordModel> Key_G_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "Gmi" ||
                                                                                                                              c.Name == "A°" ||
                                                                                                                              c.Name == "Ami" ||
                                                                                                                              c.Name == "B♭" ||
                                                                                                                              c.Name == "Cmi" ||
                                                                                                                              c.Name == "Dmi" ||
                                                                                                                              c.Name == "E♭" ||
                                                                                                                              c.Name == "F" ||
                                                                                                                              c.Name == "G-7" ||
                                                                                                                              c.Name == "A-7♭5" ||
                                                                                                                              c.Name == "B♭Ma7" ||
                                                                                                                              c.Name == "C-7" ||
                                                                                                                              c.Name == "D-7" ||
                                                                                                                              c.Name == "E♭Ma7" ||
                                                                                                                              c.Name == "F7");

        public static readonly List<ChordModel> Key_GSharp_Minor_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "G#mi" ||
                                                                                                                              c.Name == "A#°" ||
                                                                                                                              c.Name == "A#mi" ||
                                                                                                                              c.Name == "B" ||
                                                                                                                              c.Name == "C#mi" ||
                                                                                                                              c.Name == "D#mi" ||
                                                                                                                              c.Name == "E" ||
                                                                                                                              c.Name == "F#" ||
                                                                                                                              c.Name == "G#-7" ||
                                                                                                                              c.Name == "A#-7♭5" ||
                                                                                                                              c.Name == "BMa7" ||
                                                                                                                              c.Name == "C#-7" ||
                                                                                                                              c.Name == "D#-7" ||
                                                                                                                              c.Name == "EMa7" ||
                                                                                                                              c.Name == "F#7");

        #endregion
    }
}

