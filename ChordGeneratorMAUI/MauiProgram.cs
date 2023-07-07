using ChordGeneratorMAUI.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;
using Windows.Media;

namespace ChordGeneratorMAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMediaElement()
            .ConfigureFonts(fonts =>
			{
				// Logo/title font
				fonts.AddFont("Stark.otf", "Stark");

				// Main sans-serif font
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
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
