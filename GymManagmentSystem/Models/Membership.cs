using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ruta: GymManagementSystem/Models/Membership.cs
namespace GymManagementSystem.Models
{
    public class Membership
    {
        public int ClientId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsPaid { get; set; }

        public Membership(int clientId, DateTime expiryDate, bool isPaid)
        {
            ClientId = clientId;
            ExpiryDate = expiryDate;
            IsPaid = isPaid;
        }
    }
}

