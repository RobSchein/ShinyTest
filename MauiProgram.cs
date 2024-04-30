using Microsoft.Extensions.Logging;
using Shiny;

namespace MyNamespace {
   public static class MauiProgram {
      public static MauiApp CreateMauiApp() {
         var builder = MauiApp.CreateBuilder();
         builder
             .UseMauiApp<App>()
             .UseShiny()
             .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
             });

         builder.Services.AddBluetoothLE();

#if DEBUG
         builder.Logging.AddDebug();
#endif

         return builder.Build();
      }
   }
}
