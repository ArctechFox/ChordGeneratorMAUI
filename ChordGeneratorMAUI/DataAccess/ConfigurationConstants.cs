using System;
namespace ChordGeneratorMAUI.DataAccess
{
    public static class ConfigurationConstants
    {
        public const string Path_TrackPacks = "TrackPacks";
        public const string DatabaseFilename = "ChordStar_SQLiteDB.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}

