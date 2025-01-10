using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp
{
    public class User
    {
        public string Name { get; set; }
        public string Role { get; set; } // Możliwe role: "Administrator", "Konsultant"

        public User(string name, string role)
        {
            Name = name;
            Role = role;
        }
    }
}
