
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pruebaa.Data;
using Pruebaa.Models;

namespace Pruebaa.Service;

public class PersonaService
{
    private readonly AppDbContext _db = new AppDbContext();

    public List<Personas> ObtenerPersonas() //devuelve las personas que hay en la base de datos
    {
        return _db.Personas.AsNoTracking().ToList();
    }

    public void AgregarPersona(Personas persona)
    {
        _db.Personas.Add(persona);
        _db.SaveChanges();
    }

    public void ActualizarPersona(Personas persona)
    {
        using var context = new AppDbContext();
        context.Attach(persona);
        context.Entry(persona).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void EliminarPersona(Personas persona)
    {
        var entidad = _db.Personas.FirstOrDefault(p => p.Id == persona.Id);
        if (entidad != null)
        {
            _db.Personas.Remove(entidad);
            _db.SaveChanges();
        }
    }
}