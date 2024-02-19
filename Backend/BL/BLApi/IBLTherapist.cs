using BL.BO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLApi
{
    public interface IBLTherapist : ICrud<BLTherapist>
    {
        public Task<DateTime> GetFirstMeeting(Therapist t);
        Task<ICollection<BLMeeting>> GetBLTherapistMeetings(string id);
        Task<List<BLTherapist>> GetTherapistById(string id);

    }
}
