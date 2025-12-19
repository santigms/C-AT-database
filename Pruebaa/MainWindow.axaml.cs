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
        _db.Database.Migrate();
    }
}