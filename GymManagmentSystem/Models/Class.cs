using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ruta: GymManagementSystem/Models/Class.cs
namespace GymManagementSystem.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Trainer { get; set; }
        public DateTime Schedule { get; set; }
        public int Capacity { get; set; }

        public Class(int id, string name, string trainer, DateTime schedule, int capacity)
        {
            Id = id;
            Name = name;
            Trainer = trainer;
            Schedule = schedule;
            Capacity = capacity;
        }
    }
}

