using System;
using System.Collections.Generic;

namespace KeepingItCute.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public int? CustomerId { get; set; }
        public int? StyleId { get; set; }
        public DateTime Date { get; set; }
    }
}
