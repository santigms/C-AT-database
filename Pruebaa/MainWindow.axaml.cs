using Avalonia.Controls;
using Microsoft.EntityFrameworkCore;
using Pruebaa.Data;

namespace Pruebaa;

public partial class MainWindow : Window
{
    private readonly AppDbContext _db = new AppDbContext();

    public MainWindow()
    {
        InitializeComponent();

        // 1. Verificamos si estamos en el diseñador
        if (Design.IsDesignMode)
        {
            return; // Si es el diseñador, salimos y no ejecutamos la DB
        }

        // 2. Solo llegamos aquí si la app se está ejecutando de verdad
        _db.Database.Migrate();
    }
}