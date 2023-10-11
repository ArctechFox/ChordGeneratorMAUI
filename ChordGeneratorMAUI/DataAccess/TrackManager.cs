using ChordGeneratorMAUI.Helpers;
using ChordGeneratorMAUI.Models;
using Microsoft.VisualBasic;
using Plugin.Maui.Audio;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystem = Microsoft.Maui.Storage.FileSystem;

namespace ChordGeneratorMAUI.DataAccess
{
    internal sealed class TrackManager
    {
        private static SQLiteAsyncConnection _database;

        internal static List<TrackModel> AllTracks;
        internal static List<TrackModel> FavoriteTracks
        {
            get { return AllTracks.Where(t => t.IsFavorited).ToList(); }
        }

        internal static List<TrackPackModel> TrackPackLibrary = new List<TrackPackModel>();

        // Static Ctor
        static TrackManager()
        {
            //LoadTracks();

            Helpers.EventManager.Instance.EventAggregator
                .GetEvent<ToggleFavoriteTrackEvent>()
                .Subscribe(ToggleFavoriteTrackHandlerAsync);
        }

        #region DB Methods

        static async Task Init()
        {
            if (_database is not null)
                return;

            _database = new SQLiteAsyncConnection(ConfigurationConstants.DatabasePath, ConfigurationConstants.Flags);
            var result = await _database.CreateTableAsync<TrackModel>();
        }

        public static async Task<List<TrackModel>> GetTracksAsync()
        {
            await Init();
            return await _database.Table<TrackModel>().ToListAsync();
        }

        public static async Task<TrackModel> GetTrackAsync(string name, string packName)
        {
            await Init();
            return await _database.Table<TrackModel>().Where(t => t.Name == name && t.PackName == packName).FirstOrDefaultAsync();
        }

        public static async Task<int> SaveTrackAsync(TrackModel track)
        {
            await Init();
            return await _database.InsertOrReplaceAsync(track);
        }

        public static async Task<int[]> SaveTracksAsync(List<TrackModel> tracks)
        {
            var tasks = tracks.Select(SaveTrackAsync);
            return await Task.WhenAll(tasks);
        }

        public static async Task<int[]> SaveAllTracksAsync()
        {
            return await SaveTracksAsync(AllTracks);
        }

        #endregion

        #region Private Methods

        internal static async Task LoadTracks()
        {
            // TODO: Check for Pro membership
            // TODO: If pro tracks aren't present on device, restore download from our Firebase content db?

            try
            {
                // GET TRACKS
                AllTracks = await GetTracksAsync();

                // If we couldn't find anything in the database, build out the objects from file directory
                if (AllTracks is null || AllTracks.Count == 0)
                {
                    if (Directory.Exists(ConfigurationConstants.Path_TrackPacks))
                    {
                        AllTracks = new List<TrackModel>();
                        // Look for all folders in Resources/Raw/TrackPacks/
                        foreach (var folder in Directory.EnumerateDirectories(ConfigurationConstants.Path_TrackPacks))
                        {
                            var newTrackPack = new TrackPackModel();
                            newTrackPack.Name = folder.Substring(folder.LastIndexOf('/') + 1);

                            // Foreach track in each folder, create a new TrackModel and add it to the above TrackPackModel.
                            foreach (var file in Directory.GetFiles(folder).ToList())
                            {
                                TrackModel newTrack;
                                var name = Path.GetFileNameWithoutExtension(file);

                                newTrack = new TrackModel();
                                newTrack.Name = name;
                                newTrack.PackName = newTrackPack.Name;
                                newTrack.Path = ConfigurationConstants.Path_TrackPacks + "/" + newTrack.PackName + "/" + newTrack.Name + Path.GetExtension(file);
                                newTrack.IsFavorited = false;

                                AllTracks.Add(newTrack);
                                newTrackPack.Tracks.Add(newTrack);
                                SetupAudioPlayer(newTrack);
                            }

                            TrackPackLibrary.Add(newTrackPack);
                        }
                    }
                    else
                    {
                        throw new Exception("Error finding the directory path for track packs. " + ConfigurationConstants.Path_TrackPacks);
                    }
                }

                // We found tracks in the database
                else
                {
                    foreach (var t in AllTracks)
                    {
                        SetupAudioPlayer(t);

                        var pack = TrackPackLibrary.FirstOrDefault(tp => tp.Name == t.PackName);

                        // If there isn't an existing TrackPack with this track's packName, create a new TrackPack for it.
                        if (pack is null)
                        {
                            pack = new TrackPackModel();
                            pack.Name = t.PackName;
                            TrackPackLibrary.Add(pack);
                        }

                        pack.Tracks.Add(t);
                    }
                }

                // PRAISE THE ALLPACK
                // 'All' is just a pack for convenient listing/filtering of tracks without regard to what pack they're from.
                var allPack = new TrackPackModel();
                allPack.Name = "All";
                allPack.Tracks = AllTracks;
                TrackPackLibrary.Add(allPack);
            }
            catch (Exception ex)
            {
                // TODO: Implement logging w/ Firebase!
                // TODO: Show error message popup

                throw new Exception(ex.Message);
            }
        }

        private static async void SetupAudioPlayer(TrackModel track)
        {
            track.AudioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(track.Path));
        }

        private static async void ToggleFavoriteTrackHandlerAsync(TrackModel track)
        {
            track.IsFavorited = !track.IsFavorited;
            await SaveTrackAsync(track);
        }

        #endregion
    }
}
