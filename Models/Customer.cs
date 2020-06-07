using System;
using System.Collections.Generic;

namespace KeepingItCute.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<Appointment> Appointment { get; set; }
    }
}
