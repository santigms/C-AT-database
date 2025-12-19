using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;


namespace Pruebaa.Views;

public partial class PersonaView : UserControl
{
    public PersonaView()
    {
        InitializeComponent();
        DataContext = new ViewModels.PersonaViewModel();
    }
}