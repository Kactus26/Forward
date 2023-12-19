﻿using Forward4.Data;
using Forward4.View;
using Forward4.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Forward4
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Quicksand-Light", "Quicksand");
                    fonts.AddFont("Montserrat-Light", "Montserrat");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<NavigationService>();
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlite("Data Source=C:\\Users\\sasha\\source\\repos\\Forward4\\Forward4\\bin\\Debug\\net8.0-android\\helloapp.db"));


#if DEBUG
            builder.Logging.AddDebug();
#endif
            var serviceProvider = builder.Services.BuildServiceProvider();

            var dataContext = serviceProvider.GetRequiredService<DataContext>();

            Singletone.AddContext(dataContext);

            return builder.Build();
        }
    }
}
