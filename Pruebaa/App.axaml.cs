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
        // Aplica migraciones pendientes y asegura que la BD exista. Esto crea las tablas definidas por el modelo
        // si tienes migraciones generadas se aplicarán; si prefieres EnsureCreated() cambiar aquí.
        using (var db = new AppDbContext())
        {
            try
            {
                db.Database.Migrate();
            }
            catch (System.Exception)
            {
                // Si no hay migraciones creadas y se prefiere crear el esquema directamente en desarrollo,
                // descomenta la siguiente línea y comenta db.Database.Migrate();
                // db.Database.EnsureCreated();
                throw;
            }
        }

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
}