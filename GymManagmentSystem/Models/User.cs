using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        protected User(int id, string name, string role)
        {
            Id = id;
            Name = name;
            Role = role;
        }
    }

    public class Client : User
    {
        public DateTime MembershipExpiry { get; set; }

        public Client(int id, string name, DateTime membershipExpiry)
            : base(id, name, "Client")
        {
            MembershipExpiry = membershipExpiry;
        }

        public bool IsMembershipExpiring()
        {
            return (MembershipExpiry - DateTime.Now).TotalDays <= 5;
        }
    }

    public class Trainer : User
    {
        public string Specialty { get; set; }
        public List<string> Schedule { get; set; }

        public Trainer(int id, string name, string specialty, List<string> schedule)
            : base(id, name, "Trainer")
        {
            Specialty = specialty;
            Schedule = schedule;
        }
    }

}
