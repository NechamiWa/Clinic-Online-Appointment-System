using BL.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BL.BLApi
{
    public interface IJoinDateClient:ICrud<JoinDateClient>
    {
        public Task <DateTime> GetJoinDate(Client client);
        Task<ICollection<BLMeeting>> GetBLClientMeetings(string id);
        Task<List<JoinDateClient>> GetClientById(string id);

    }
}
