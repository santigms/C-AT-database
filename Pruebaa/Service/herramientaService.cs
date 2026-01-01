using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pruebaa.Data;
using Pruebaa.Models;

namespace Pruebaa.Service;

    public class HerramientaService
    {
    private readonly AppDbContext _db = new AppDbContext();
    public List<Herramientas> ObtenerHerramientas() //devuelve las personas que hay en la base de datos
    {
        return _db.Herramientas.AsNoTracking().ToList();
    }

    public void AgregarHerramienta(Herramientas herramienta)
    {
        _db.Herramientas.Add(herramienta);
        _db.SaveChanges();
    }
    public void ActualizarHerramienta(Herramientas herramienta)
    {
        using var context = new AppDbContext();
        context.Attach(herramienta);
        context.Entry(herramienta).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void EliminarHerramienta(Herramientas herramienta)
    {
        var entidad = _db.Herramientas.FirstOrDefault(p => p.Code == herramienta.Code);
        if (entidad != null)
        {
            _db.Herramientas.Remove(entidad);
            _db.SaveChanges();
        }
    }

    public void ActualizarStock(int code, int nuevoStock)
    {
        var herramienta = _db.Herramientas.FirstOrDefault(h => h.Code == code);
        if (herramienta != null)
        {
            herramienta.Stock = nuevoStock;
            _db.SaveChanges();
        }
    }



}
