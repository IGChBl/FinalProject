using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public static class FacturaStorage
    {
        private static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Facturas.json");

        // Guardar facturas en un archivo JSON
        public static void GuardarFacturas(List<Factura> facturas)
        {
            string json = JsonSerializer.Serialize(facturas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        // Cargar facturas desde un archivo JSON
        public static List<Factura> CargarFacturas()
        {
            if (!File.Exists(filePath))
            {
                return new List<Factura>(); // Si no existe el archivo, retornar una lista vacía
            }

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Factura>>(json) ?? new List<Factura>();
        }

        // Eliminar una factura del archivo JSON
        public static void EliminarFactura(string numeroFactura)
        {
            var facturas = CargarFacturas();
            facturas.RemoveAll(f => f.Numero == numeroFactura);
            GuardarFacturas(facturas);
        }
    }
}
