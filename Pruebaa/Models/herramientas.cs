using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // Necesitas este using
namespace Pruebaa.Models;

    public class Herramientas
    {
        [Key]
        public int Id { get; set; } // O simplemente llámalo 'Id' para que EF lo reconozca solo
        public string Name{set;get; }
        public int Code{set;get; }
        public int Stock{set;get; }
        public double price{set;get; }

}

