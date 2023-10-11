using ChordGeneratorMAUI.DataAccess;
using ChordGeneratorMAUI.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Maui.Audio;
using Plugin.MauiMTAdmob;
using System.Runtime.CompilerServices;

namespace ChordGeneratorMAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var pm = PurchaseManager.Instance; // initializes

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMediaElement()
            .UseMauiMTAdmob()
            .ConfigureFonts(fonts =>
            {
                // Logo/title font
                fonts.AddFont("Gila-AL4r7.otf", "Gila");
                fonts.AddFont("GilaBold-p7Rdr.otf", "Gila Bold");

                // "Pro"
                fonts.AddFont("Cintaly-ax7v9.otf", "Cintaly");

                // Main sans-serif font
                fonts.AddFont("JosefinSans-Regular.ttf", "JosefinSans");
                fonts.AddFont("JosefinSans-Bold.ttf", "JosefinSans Bold");
                fonts.AddFont("JosefinSans-Light.ttf", "JosefinSans Light");

                fonts.AddFont("SalmaproMedium-0Wooo.otf", "Salmapro");
                fonts.AddFont("SalmaproMediumnarrow-VG5v6.otf", "Salmapro Narrow");

                fonts.AddFont("Sansation_Bold.ttf", "Sansation Bold");
                fonts.AddFont("Sansation_Bold_italic.ttf", "Sansation Bold-Italic");
                fonts.AddFont("Sansation_Italic.ttf", "Sansation Italic");
                fonts.AddFont("Sansation_Light.ttf", "Sansation Light");
                fonts.AddFont("Sansation_Light_Italic.ttf", "Sansation Light-Italic");
                fonts.AddFont("Sansation_Regular.ttf", "Sansation");

                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                // Music notation
                fonts.AddFont("LASSUS.ttf", "Lassus");
                fonts.AddFont("MusAnalysis.otf", "MusicAnalysis");

                // Icon fonts
                fonts.AddFont("Font Awesome 5 Brands-Regular-400.otf", "FA Brands");
                fonts.AddFont("Font Awesome 5 Duotone-Solid-900.otf", "FA Duotone");
                fonts.AddFont("Font Awesome 5 Pro-Light-300.otf", "FA Pro Light");
                fonts.AddFont("Font Awesome 5 Pro-Regular-400.otf", "FA Pro Regular");
                fonts.AddFont("Font Awesome 5 Pro-Solid-900.otf", "FA Pro Solid");
            });

        builder.Services.AddSingleton(AudioManager.Current);

#if IOS
        builder.ConfigureLifecycleEvents(events =>
        {
            events.AddiOS(iOS => iOS.FinishedLaunching((app, launchOptions) => {
                Firebase.Core.App.Configure();
                return false;
            }));
        });

#endif

#if DEBUG
        builder.Logging.AddDebug();
#endif

        //CrossMauiMTAdmob.Current.UserPersonalizedAds = false;
        ////CrossMauiMTAdmob.Current.AdsId = "ca-app-pub-2329707705985560/7005829538";
        //CrossMauiMTAdmob.Current.AdsId = "ca-app-pub-3940256099942544/2934735716";

        return builder.Build();
    }
}
