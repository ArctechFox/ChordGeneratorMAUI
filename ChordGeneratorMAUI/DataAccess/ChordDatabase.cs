﻿using ChordGeneratorMAUI.Models;
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
            [Description("All")]
            All = 1 | 2 | 3 | 4 | 5 | 6 | 7,

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
            MinorSevenFlatFive
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
           new ChordModel(){ Name = "A# -7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "B# -7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "C# -7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "D# -7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "E# -7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "F# -7", ChordType = ChordTypes.Minor7th },
           new ChordModel(){ Name = "G# -7", ChordType = ChordTypes.Minor7th },

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
                                                                                                                              c.Name == "B♭m" ||
                                                                                                                              c.Name == "Cm" ||
                                                                                                                              c.Name == "D♭" ||
                                                                                                                              c.Name == "E♭" ||
                                                                                                                              c.Name == "Fm" ||
                                                                                                                              c.Name == "G°" ||
                                                                                                                              c.Name == "Gm" ||
                                                                                                                              c.Name == "A♭Ma7" ||
                                                                                                                              c.Name == "B♭-7" ||
                                                                                                                              c.Name == "C-7" ||
                                                                                                                              c.Name == "D♭Ma7" ||
                                                                                                                              c.Name == "E♭7" ||
                                                                                                                              c.Name == "F-7" ||
                                                                                                                              c.Name == "G-7♭5");

        public static readonly List<ChordModel> Key_A_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "A" ||
                                                                                                                              c.Name == "Bm" ||
                                                                                                                              c.Name == "C#m" ||
                                                                                                                              c.Name == "D" ||
                                                                                                                              c.Name == "E" ||
                                                                                                                              c.Name == "F#m" ||
                                                                                                                              c.Name == "G#°" ||
                                                                                                                              c.Name == "G#m" ||
                                                                                                                              c.Name == "AMa7" ||
                                                                                                                              c.Name == "B-7" ||
                                                                                                                              c.Name == "C#-7" ||
                                                                                                                              c.Name == "DMa7" ||
                                                                                                                              c.Name == "E7" ||
                                                                                                                              c.Name == "F#-7" ||
                                                                                                                              c.Name == "G#-7♭5");

        public static readonly List<ChordModel> Key_Bb_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "B♭" ||
                                                                                                                              c.Name == "Cm" ||
                                                                                                                              c.Name == "Dm" ||
                                                                                                                              c.Name == "E♭" ||
                                                                                                                              c.Name == "F" ||
                                                                                                                              c.Name == "Gm" ||
                                                                                                                              c.Name == "A°" ||
                                                                                                                              c.Name == "Am" ||
                                                                                                                              c.Name == "B♭Ma7" ||
                                                                                                                              c.Name == "C-7" ||
                                                                                                                              c.Name == "D-7" ||
                                                                                                                              c.Name == "E♭Ma7" ||
                                                                                                                              c.Name == "F7" ||
                                                                                                                              c.Name == "G-7" ||
                                                                                                                              c.Name == "A-7♭5");

        public static readonly List<ChordModel> Key_B_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "B" ||
                                                                                                                              c.Name == "C#m" ||
                                                                                                                              c.Name == "D#m" ||
                                                                                                                              c.Name == "E" ||
                                                                                                                              c.Name == "F#" ||
                                                                                                                              c.Name == "G#m" ||
                                                                                                                              c.Name == "A#°" ||
                                                                                                                              c.Name == "A#m" ||
                                                                                                                              c.Name == "BMa7" ||
                                                                                                                              c.Name == "C#-7" ||
                                                                                                                              c.Name == "D#-7" ||
                                                                                                                              c.Name == "EMa7" ||
                                                                                                                              c.Name == "F#7" ||
                                                                                                                              c.Name == "G#-7" ||
                                                                                                                              c.Name == "A#-7♭5");

        public static readonly List<ChordModel> Key_C_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "C" ||
                                                                                                                              c.Name == "Dm" ||
                                                                                                                              c.Name == "Em" ||
                                                                                                                              c.Name == "F" ||
                                                                                                                              c.Name == "G" ||
                                                                                                                              c.Name == "Am" ||
                                                                                                                              c.Name == "B°" ||
                                                                                                                              c.Name == "Bm" ||
                                                                                                                              c.Name == "CMa7" ||
                                                                                                                              c.Name == "D-7" ||
                                                                                                                              c.Name == "E-7" ||
                                                                                                                              c.Name == "FMa7" ||
                                                                                                                              c.Name == "G7" ||
                                                                                                                              c.Name == "A-7" ||
                                                                                                                              c.Name == "B-7♭5");

        public static readonly List<ChordModel> Key_CSharp_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "C#" ||
                                                                                                                              c.Name == "D#m" ||
                                                                                                                              c.Name == "E#m" ||
                                                                                                                              c.Name == "F#" ||
                                                                                                                              c.Name == "G#" ||
                                                                                                                              c.Name == "A#m" ||
                                                                                                                              c.Name == "B#°" ||
                                                                                                                              c.Name == "B#m" ||
                                                                                                                              c.Name == "C#Ma7" ||
                                                                                                                              c.Name == "D#-7" ||
                                                                                                                              c.Name == "E#-7" ||
                                                                                                                              c.Name == "F#Ma7" ||
                                                                                                                              c.Name == "G#7" ||
                                                                                                                              c.Name == "A#-7" ||
                                                                                                                              c.Name == "B#-7♭5");

        public static readonly List<ChordModel> Key_Db_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "D♭" ||
                                                                                                                              c.Name == "E♭m" ||
                                                                                                                              c.Name == "Fm" ||
                                                                                                                              c.Name == "G♭" ||
                                                                                                                              c.Name == "A♭" ||
                                                                                                                              c.Name == "B♭m" ||
                                                                                                                              c.Name == "C°" ||
                                                                                                                              c.Name == "Cm" ||
                                                                                                                              c.Name == "D♭Ma7" ||
                                                                                                                              c.Name == "E♭-7" ||
                                                                                                                              c.Name == "F-7" ||
                                                                                                                              c.Name == "G♭Ma7" ||
                                                                                                                              c.Name == "A♭7" ||
                                                                                                                              c.Name == "B♭-7" ||
                                                                                                                              c.Name == "C-7♭5");

        public static readonly List<ChordModel> Key_D_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "D" ||
                                                                                                                              c.Name == "Em" ||
                                                                                                                              c.Name == "F#m" ||
                                                                                                                              c.Name == "G" ||
                                                                                                                              c.Name == "A" ||
                                                                                                                              c.Name == "Bm" ||
                                                                                                                              c.Name == "C#°" ||
                                                                                                                              c.Name == "C#m" ||
                                                                                                                              c.Name == "DMa7" ||
                                                                                                                              c.Name == "E-7" ||
                                                                                                                              c.Name == "F#-7" ||
                                                                                                                              c.Name == "GMa7" ||
                                                                                                                              c.Name == "A7" ||
                                                                                                                              c.Name == "B-7" ||
                                                                                                                              c.Name == "C#-7♭5");

        public static readonly List<ChordModel> Key_Eb_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "E♭" ||
                                                                                                                              c.Name == "Fm" ||
                                                                                                                              c.Name == "Gm" ||
                                                                                                                              c.Name == "A♭" ||
                                                                                                                              c.Name == "B♭" ||
                                                                                                                              c.Name == "Cm" ||
                                                                                                                              c.Name == "D°" ||
                                                                                                                              c.Name == "Dm" ||
                                                                                                                              c.Name == "E♭Ma7" ||
                                                                                                                              c.Name == "F-7" ||
                                                                                                                              c.Name == "G-7" ||
                                                                                                                              c.Name == "A♭Ma7" ||
                                                                                                                              c.Name == "B♭7" ||
                                                                                                                              c.Name == "C-7" ||
                                                                                                                              c.Name == "D-7♭5");

        public static readonly List<ChordModel> Key_E_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "E" ||
                                                                                                                              c.Name == "F#m" ||
                                                                                                                              c.Name == "G#m" ||
                                                                                                                              c.Name == "A" ||
                                                                                                                              c.Name == "B" ||
                                                                                                                              c.Name == "C#m" ||
                                                                                                                              c.Name == "D#°" ||
                                                                                                                              c.Name == "D#m" ||
                                                                                                                              c.Name == "EMa7" ||
                                                                                                                              c.Name == "F#-7" ||
                                                                                                                              c.Name == "G#-7" ||
                                                                                                                              c.Name == "AMa7" ||
                                                                                                                              c.Name == "B7" ||
                                                                                                                              c.Name == "C#-7" ||
                                                                                                                              c.Name == "D#-7♭5");

        public static readonly List<ChordModel> Key_F_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "F" ||
                                                                                                                              c.Name == "Gm" ||
                                                                                                                              c.Name == "Am" ||
                                                                                                                              c.Name == "B♭" ||
                                                                                                                              c.Name == "C" ||
                                                                                                                              c.Name == "Dm" ||
                                                                                                                              c.Name == "E°" ||
                                                                                                                              c.Name == "Em" ||
                                                                                                                              c.Name == "FMa7" ||
                                                                                                                              c.Name == "G-7" ||
                                                                                                                              c.Name == "A-7" ||
                                                                                                                              c.Name == "B♭Ma7" ||
                                                                                                                              c.Name == "C7" ||
                                                                                                                              c.Name == "D-7" ||
                                                                                                                              c.Name == "E-7♭5");

        public static readonly List<ChordModel> Key_FSharp_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "F#" ||
                                                                                                                              c.Name == "G#m" ||
                                                                                                                              c.Name == "A#m" ||
                                                                                                                              c.Name == "B" ||
                                                                                                                              c.Name == "C#" ||
                                                                                                                              c.Name == "D#m" ||
                                                                                                                              c.Name == "E#°" ||
                                                                                                                              c.Name == "E#m" ||
                                                                                                                              c.Name == "F#Ma7" ||
                                                                                                                              c.Name == "G#-7" ||
                                                                                                                              c.Name == "A#-7" ||
                                                                                                                              c.Name == "BMa7" ||
                                                                                                                              c.Name == "C#7" ||
                                                                                                                              c.Name == "D#-7" ||
                                                                                                                              c.Name == "E#-7♭5");

        public static readonly List<ChordModel> Key_Gb_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "G♭" ||
                                                                                                                              c.Name == "A♭m" ||
                                                                                                                              c.Name == "B♭m" ||
                                                                                                                              c.Name == "C♭" ||
                                                                                                                              c.Name == "D♭" ||
                                                                                                                              c.Name == "E♭m" ||
                                                                                                                              c.Name == "F°" ||
                                                                                                                              c.Name == "Fm" ||
                                                                                                                              c.Name == "G♭Ma7" ||
                                                                                                                              c.Name == "A♭-7" ||
                                                                                                                              c.Name == "B♭-7" ||
                                                                                                                              c.Name == "C♭Ma7" ||
                                                                                                                              c.Name == "D♭7" ||
                                                                                                                              c.Name == "E♭7" ||
                                                                                                                              c.Name == "F-7♭5");

        public static readonly List<ChordModel> Key_G_Major_Chords = AllChords.FindAll((c) =>
                                                                                                                              c.Name == "G" ||
                                                                                                                              c.Name == "Am" ||
                                                                                                                              c.Name == "Bm" ||
                                                                                                                              c.Name == "C" ||
                                                                                                                              c.Name == "D" ||
                                                                                                                              c.Name == "Em" ||
                                                                                                                              c.Name == "F#°" ||
                                                                                                                              c.Name == "F#m" ||
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
                                                                                                                              c.Name == "A♭m" ||
                                                                                                                              c.Name == "B♭°" ||
                                                                                                                              c.Name == "B♭m" ||
                                                                                                                              c.Name == "C♭" ||
                                                                                                                              c.Name == "D♭m" ||
                                                                                                                              c.Name == "E♭m" ||
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
                                                                                                                              c.Name == "Am" ||
                                                                                                                              c.Name == "B°" ||
                                                                                                                              c.Name == "Bm" ||
                                                                                                                              c.Name == "C" ||
                                                                                                                              c.Name == "Dm" ||
                                                                                                                              c.Name == "Em" ||
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
                                                                                                                              c.Name == "A#m" ||
                                                                                                                              c.Name == "B#°" ||
                                                                                                                              c.Name == "B#m" ||
                                                                                                                              c.Name == "C#" ||
                                                                                                                              c.Name == "D#m" ||
                                                                                                                              c.Name == "E#m" ||
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
                                                                                                                              c.Name == "B♭m" ||
                                                                                                                              c.Name == "C°" ||
                                                                                                                              c.Name == "Cm" ||
                                                                                                                              c.Name == "D♭" ||
                                                                                                                              c.Name == "E♭m" ||
                                                                                                                              c.Name == "Fm" ||
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
                                                                                                                              c.Name == "Bm" ||
                                                                                                                              c.Name == "C#°" ||
                                                                                                                              c.Name == "C#m" ||
                                                                                                                              c.Name == "D" ||
                                                                                                                              c.Name == "Em" ||
                                                                                                                              c.Name == "F#m" ||
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
                                                                                                                              c.Name == "Cm" ||
                                                                                                                              c.Name == "D°" ||
                                                                                                                              c.Name == "Dm" ||
                                                                                                                              c.Name == "E♭" ||
                                                                                                                              c.Name == "Fm" ||
                                                                                                                              c.Name == "Gm" ||
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
                                                                                                                              c.Name == "C#m" ||
                                                                                                                              c.Name == "D#°" ||
                                                                                                                              c.Name == "D#m" ||
                                                                                                                              c.Name == "E" ||
                                                                                                                              c.Name == "F#m" ||
                                                                                                                              c.Name == "G#m" ||
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
                                                                                                                              c.Name == "Dm" ||
                                                                                                                              c.Name == "E°" ||
                                                                                                                              c.Name == "Em" ||
                                                                                                                              c.Name == "F" ||
                                                                                                                              c.Name == "Gm" ||
                                                                                                                              c.Name == "Am" ||
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
                                                                                                                              c.Name == "D#m" ||
                                                                                                                              c.Name == "E#°" ||
                                                                                                                              c.Name == "E#m" ||
                                                                                                                              c.Name == "F#" ||
                                                                                                                              c.Name == "G#m" ||
                                                                                                                              c.Name == "A#m" ||
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
                                                                                                                              c.Name == "E♭m" ||
                                                                                                                              c.Name == "F°" ||
                                                                                                                              c.Name == "Fm" ||
                                                                                                                              c.Name == "G♭" ||
                                                                                                                              c.Name == "A♭m" ||
                                                                                                                              c.Name == "B♭m" ||
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
                                                                                                                              c.Name == "Em" ||
                                                                                                                              c.Name == "F#°" ||
                                                                                                                              c.Name == "F#m" ||
                                                                                                                              c.Name == "G" ||
                                                                                                                              c.Name == "Am" ||
                                                                                                                              c.Name == "Bm" ||
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
                                                                                                                              c.Name == "Fm" ||
                                                                                                                              c.Name == "G°" ||
                                                                                                                              c.Name == "Gm" ||
                                                                                                                              c.Name == "A♭" ||
                                                                                                                              c.Name == "B♭m" ||
                                                                                                                              c.Name == "Cm" ||
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
                                                                                                                              c.Name == "F#m" ||
                                                                                                                              c.Name == "G#°" ||
                                                                                                                              c.Name == "G#m" ||
                                                                                                                              c.Name == "A" ||
                                                                                                                              c.Name == "Bm" ||
                                                                                                                              c.Name == "C#m" ||
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
                                                                                                                              c.Name == "Gm" ||
                                                                                                                              c.Name == "A°" ||
                                                                                                                              c.Name == "Am" ||
                                                                                                                              c.Name == "B♭" ||
                                                                                                                              c.Name == "Cm" ||
                                                                                                                              c.Name == "Dm" ||
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
                                                                                                                              c.Name == "G#m" ||
                                                                                                                              c.Name == "A#°" ||
                                                                                                                              c.Name == "A#m" ||
                                                                                                                              c.Name == "B" ||
                                                                                                                              c.Name == "C#m" ||
                                                                                                                              c.Name == "D#m" ||
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

