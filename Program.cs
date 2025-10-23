using Avalonia;
using System;
using PrinTicket.Data;

namespace PrinTicket;

sealed class Program
{
    // // Initialization code. Don't use any Avalonia, third-party APIs or any
    // // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // // yet and stuff might break.
    // [STAThread]
    // public static void Main(string[] args) => BuildAvaloniaApp()
    //     .StartWithClassicDesktopLifetime(args);

    // // Avalonia configuration, don't remove; also used by visual designer.
    // public static AppBuilder BuildAvaloniaApp()
    //     => AppBuilder.Configure<App>()
    //         .UsePlatformDetect()
    //         .WithInterFont()
    //         .LogToTrace();





    //probando conexion  a base  de datos
    [STAThread]
    public static void Main(string[] args)
    {
        DatabaseTest.ProbarConexion();

        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();


}
