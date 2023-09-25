using ChordGeneratorMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordGeneratorMAUI.DataAccess
{
    internal sealed class TrackManager
    {
        private static readonly string _path_TrackPacks = "/Resources/Raw/TrackPacks";

        static TrackManager()
        {
            // TODO: Check for Pro membership
            // TODO: If pro tracks aren't present on device, restore download from our Firebase db

            if (Directory.Exists(_path_TrackPacks))
            {
                // Setup default tracks
                StarterBeats = new TrackPackModel()
                {
                    Name = "Starter Beats",
                    IsUnlocked = true,
                };

                // Look for all folders in Resources/Raw/TrackPacks/
                // Foreach track in each folder, create a new TrackModel and add it to the above TrackPackModel.

                foreach(var folder in Directory.EnumerateDirectories(_path_TrackPacks))
                {
                    var newTrackPack = new TrackPackModel();
                    newTrackPack.Name = folder;

                    foreach (var file in Directory.GetFiles(folder).ToList())
                    {
                        newTrackPack.Tracks.Add(new TrackModel(file, folder, _path_TrackPacks + "/" + folder + "/" + file));
                    }
                }
            }
        }

        internal static List<TrackPackModel> TrackPackLibrary = new List<TrackPackModel>();

        internal static TrackPackModel StarterBeats;
        internal static TrackPackModel ProBeats_Rock;
    }
}
