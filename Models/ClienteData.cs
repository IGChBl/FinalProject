using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Proyecto.Models
{
        public static class ClienteData
        {
            private static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Clientes.json");

            // Método para guardar la lista de clientes en un archivo JSON
            public static void GuardarClientes(List<Cliente> clientes)
            {
                string json = JsonSerializer.Serialize(clientes, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }

            // Método para cargar la lista de clientes desde el archivo JSON
            public static List<Cliente> CargarClientes()
            {
                if (!File.Exists(filePath))
                {
                    // Si el archivo no existe, devolver una lista vacía
                    return new List<Cliente>();
                }

                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Cliente>>(json) ?? new List<Cliente>();
            }
        }
}
