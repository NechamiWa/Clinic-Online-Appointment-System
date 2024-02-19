using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Meeting
    {
        public int Id { get; set; }
        public string ClientId { get; set; } = null!;
        public string TherapistId { get; set; } = null!;
        public DateTime Date { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Therapist Therapist { get; set; } = null!;
    }
}
