using System;
using System.Collections.Generic;

namespace KeepingItCute.Models
{
    public partial class Style
    {
        public Style()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ICollection<Appointment> Appointment { get; set; }
    }
}
