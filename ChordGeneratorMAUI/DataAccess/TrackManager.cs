using ChordGeneratorMAUI.Helpers;
using ChordGeneratorMAUI.Models;
using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordGeneratorMAUI.DataAccess
{
    internal sealed class TrackManager
    {
        private static readonly string _path_TrackPacks = "TrackPacks";

        static TrackManager()
        {
            // Setup Tracks

            // Read 'FavoriteTracks' from Preferences
            FavoriteTracks = Preferences.Default.GetObject<List<TrackModel>>("FavoriteTracks", new List<TrackModel>());

            Helpers.EventManager.Instance.EventAggregator
                .GetEvent<ToggleFavoriteTrackEvent>()
                .Subscribe(ToggleFavoriteTrackHandler);

            // TODO: Check for Pro membership
            // TODO: If pro tracks aren't present on device, restore download from our Firebase db?

            if (Directory.Exists(_path_TrackPacks))
            {
                // Look for all folders in Resources/Raw/TrackPacks/
                foreach (var folder in Directory.EnumerateDirectories(_path_TrackPacks))
                {
                    var newTrackPack = new TrackPackModel();
                    newTrackPack.Name = folder.Substring(folder.LastIndexOf('/') + 1);

                    // Foreach track in each folder, create a new TrackModel and add it to the above TrackPackModel.
                    foreach (var file in Directory.GetFiles(folder).ToList())
                    {
                        TrackModel newTrack;
                        var name = Path.GetFileNameWithoutExtension(file);

                        // If the track is found in FavoriteTracks, use that track data from Preferences instead of building it out from the Directory info
                        var foundFavoriteTrack = FavoriteTracks.FirstOrDefault(t => (t.Name == name) && (t.PackName == newTrackPack.Name));

                        if (foundFavoriteTrack != null)
                        {
                            newTrack = foundFavoriteTrack;
                            newTrack.IsFavorited = true;
                        }
                        else
                        {
                            newTrack = new TrackModel();
                            newTrack.Name = name;
                            newTrack.PackName = newTrackPack.Name;
                            newTrack.Path = _path_TrackPacks + "/" + newTrack.PackName + "/" + newTrack.Name + Path.GetExtension(file);
                            newTrack.IsFavorited = false;
                        }

                        SetupAudioPlayer(newTrack);

                        newTrackPack.Tracks.Add(newTrack);
                    }

                    TrackPackLibrary.Add(newTrackPack);
                }
            }
        }

        internal static List<TrackPackModel> TrackPackLibrary = new List<TrackPackModel>();
        internal static List<TrackModel> FavoriteTracks;

        private static async void SetupAudioPlayer(TrackModel track)
        {
            track.AudioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(track.Path));
        }

        private static void ToggleFavoriteTrackHandler(TrackModel track)
        {
            if (track.IsFavorited)
            {
                track.IsFavorited = false;
                FavoriteTracks.Remove(track);
            }
            else
            {
                track.IsFavorited = true;
                FavoriteTracks.Add(track);
            }

            Preferences.Default.SetObject<List<TrackModel>>("FavoriteTracks", FavoriteTracks);
        }
    }
}
