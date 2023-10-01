using Microsoft.Extensions.Logging;

using Phrasebook.Services;
using Phrasebook.ViewModels;
using Phrasebook.Views.Account;

namespace Phrasebook;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<AppShellViewModel>();

        builder.Services.AddSingleton<SignInPage>();
        builder.Services.AddSingleton<SignInViewModel>();

        builder.Services.AddScoped<ISignInService, SignInService>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
