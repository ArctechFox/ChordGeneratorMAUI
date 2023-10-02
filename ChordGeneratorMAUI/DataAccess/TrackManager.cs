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

            // TODO: Check for Pro membership
            // TODO: If pro tracks aren't present on device, restore download from our Firebase db?

            if (Directory.Exists(_path_TrackPacks))
            {
                // Look for all folders in Resources/Raw/TrackPacks/
                foreach(var folder in Directory.EnumerateDirectories(_path_TrackPacks))
                {
                    var newTrackPack = new TrackPackModel();
                    newTrackPack.Name = folder.Substring(folder.LastIndexOf('/') + 1);

                    // Foreach track in each folder, create a new TrackModel and add it to the above TrackPackModel.
                    foreach (var file in Directory.GetFiles(folder).ToList())
                    {
                        var newTrack = new TrackModel();
                        newTrack.Name = Path.GetFileNameWithoutExtension(file);
                        newTrack.PackName = newTrackPack.Name;
                        newTrack.Path = _path_TrackPacks + "/" + newTrack.PackName + "/" + newTrack.Name + Path.GetExtension(file);

                        SetupAudioPlayer(newTrack);

                        newTrackPack.Tracks.Add(newTrack); 
                    }

                    TrackPackLibrary.Add(newTrackPack);
                }
            }
        }

        internal static List<TrackPackModel> TrackPackLibrary = new List<TrackPackModel>();


        private static async void SetupAudioPlayer(TrackModel track)
        {
            track.AudioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(track.Path));
        }
    }
}
