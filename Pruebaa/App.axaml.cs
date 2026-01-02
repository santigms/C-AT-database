using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using Pruebaa.Data;

namespace Pruebaa;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Solo ejecuta la base de datos si NO estamos en el diseñador
        if (!Avalonia.Controls.Design.IsDesignMode)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    db.Database.Migrate();
                }
                catch (System.Exception ex)
                {
                    // Es buena idea imprimir el error en consola para debuguear
                    System.Diagnostics.Debug.WriteLine($"Error de BD: {ex.Message}");
                }
            }
        }

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
    }