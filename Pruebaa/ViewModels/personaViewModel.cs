using System.Collections.ObjectModel;
using System.ComponentModel;
using Pruebaa.Service;
using Pruebaa.Models;
using System.Windows.Input;
using Pruebaa.Helpers;

namespace Pruebaa.ViewModels;

public class PersonaViewModel: INotifyPropertyChanged
{
    private readonly PersonaService _service = new PersonaService();

    public ObservableCollection<Personas> personasList {get; } = new();
    // Propiedad en PascalCase para enlazar desde la vista (ItemsSource="{Binding Personas}")
    public ObservableCollection<Personas> Personas => personasList;

    public ICommand AddCommand {get; }
    public ICommand ActualizeCommand {get; }
    public ICommand DeleteCommand {get; }
    public ICommand ClearCommand {get; }

    public PersonaViewModel()
    {
        AddCommand = new RelayCommand(Add);
        ActualizeCommand = new RelayCommand(Actualize);
        DeleteCommand = new RelayCommand(Delete);
        ClearCommand = new RelayCommand(Clear);
        LoadPersonas();
        ClearFields();
    }

    private Personas _SelectedPersona;

    public Personas SelectedPersona
    {
        get => _SelectedPersona;
        set
        {
            if(_SelectedPersona != value)
            {
                _SelectedPersona = value;
                OnPropertyChanged();
                if(value != null)
                {
                    Name = value.Name;
                    Age = value.Age;
                    Id = value.Id;
                }
                else
                {
                    ClearFields();
                }
            }
        }
    } 
    private string _Name;
    public string Name
    {
        get => _Name;
        set
        {
            _Name = value;
            OnPropertyChanged();
        }
    }

    private int _Age;
    public int Age
    {
        get => _Age;
        set
        {
            _Age = value;
            OnPropertyChanged();
        }
    }

    private int _Id;
    public int Id
    {
        get => _Id;
        set
        {
            _Id = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void LoadPersonas()
    {
        personasList.Clear();
        var personas = _service.ObtenerPersonas();
        foreach(var persona in personas)
        {
            personasList.Add(persona);
        }
    }

    public void ClearFields()
    {
        Name = string.Empty;
        Age = 0;
        Id = 0;
        SelectedPersona = null;
    }

    public bool Validate() =>
        !string.IsNullOrWhiteSpace(Name) &&
        Age > 0 &&
        Id > 0;

    public void Add()
    {
        if(!Validate()) return;
        var persona = new Personas
        {
            Name = Name.Trim(),
            Age = Age,
            Id = Id
        };
        _service.AgregarPersona(persona);
        LoadPersonas();
        ClearFields();
    }

    public void Actualize()
    {
        if(SelectedPersona == null || !Validate()) return;
        SelectedPersona.Name = Name.Trim();
        SelectedPersona.Age = Age;
        SelectedPersona.Id = Id;
        _service.ActualizarPersona(SelectedPersona);
        LoadPersonas();
        ClearFields();
    }

    public void Delete()
    {
        if(SelectedPersona == null) return;
        _service.EliminarPersona(SelectedPersona);
        LoadPersonas();
        ClearFields();
    }

    public void Clear()
    {
        ClearFields();
    }
}
