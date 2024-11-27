using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ruta: GymManagementSystem/Controllers/UserController.cs
using GymManagementSystem.Models;
using System.Collections.Generic;

namespace GymManagementSystem.Controllers
{
    public class UserController
    {
        public List<Client> Clients { get; set; }
        public List<Trainer> Trainers { get; set; }

        public UserController()
        {
            // Inicializar listas de usuarios (debe cargarse desde archivos en el futuro)
            Clients = new List<Client>();
            Trainers = new List<Trainer>();
        }

        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        public void AddTrainer(Trainer trainer)
        {
            Trainers.Add(trainer);
        }
    }
}
