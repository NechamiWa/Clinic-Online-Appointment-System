using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Therapist
    {
        public Therapist()
        {
            Meetings = new HashSet<Meeting>();
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }
        public int Salary { get; set; }

        public virtual ICollection<Meeting> Meetings { get; set; }
    }
}
