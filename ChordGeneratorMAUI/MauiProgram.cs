using ChordGeneratorMAUI.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;

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
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("LASSUS.ttf", "Lassus");
				fonts.AddFont("MusAnalysis.otf", "MusicAnalysis");

				fonts.AddFont("Font Awesome 5 Brands-Regular-400.otf", "FA Brands");
				fonts.AddFont("Font Awesome 5 Duotone-Solid-900.otf", "FA Duotone");
				fonts.AddFont("Font Awesome 5 Pro-Light-300.otf", "FA Pro Light");
				fonts.AddFont("Font Awesome 5 Pro-Regular-400.otf", "FA Pro Regular");
				fonts.AddFont("Font Awesome 5 Pro-Solid-900.otf", "FA Pro Solid");
			});

		builder.Services.AddSingleton(AudioManager.Current);
		//builder.Services.AddTransient<MetronomeViewModel>();
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
