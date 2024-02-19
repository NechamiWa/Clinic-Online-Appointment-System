using BL.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLApi
{
    public interface IBLMeeting:ICrud<BLMeeting>
    {
     public Task<ICollection<BLMeeting>>  GetMeetingsByDate(DateTime date);

    }
}
