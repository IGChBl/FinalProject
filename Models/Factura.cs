using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class Factura
    {
        public string Numero { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<Servicio> Servicios { get; set; }
        public decimal Total { get; set; }
    }
}
