using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentSystem.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal Amount { get; set; }

        public Factura(int id, int clientId, DateTime issueDate, decimal amount)
        {
            Id = id;
            ClientId = clientId;
            IssueDate = issueDate;
            Amount = amount;
        }
    }

}
