using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class BLNewMeeting
    {
        public string ClientId { get; set; } = null!;
        public string TherapistId { get; set; } = null!;
        public DateTime Date { get; set; }

    }
}
