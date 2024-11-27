using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ruta: GymManagementSystem/Models/Equipment.cs
namespace GymManagementSystem.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; } // Non-nullable property

        public Inventory(int id, string name)
        {
            Id = id;
            Name = name; // Se asegura que 'Name' tenga un valor al construir la clase
        }

    }

}
