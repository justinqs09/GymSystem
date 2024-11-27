using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ruta: GymManagementSystem/Models/Reservation.cs
namespace GymManagementSystem.Models
{
    public class Reservation
    {
        public class Clase
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime Schedule { get; set; }
            public int Capacity { get; set; }
            public Trainer AssignedTrainer { get; set; }
            public List<Client> Clients { get; set; }

            public Clase(int id, string name, DateTime schedule, int capacity, Trainer assignedTrainer)
            {
                Id = id;
                Name = name;
                Schedule = schedule;
                Capacity = capacity;
                AssignedTrainer = assignedTrainer;
                Clients = new List<Client>();
            }

            public bool AddClient(Client client)
            {
                if (Clients.Count >= Capacity) return false;
                Clients.Add(client);
                return true;
            }
        }

    }
}
