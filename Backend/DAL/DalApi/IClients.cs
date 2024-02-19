using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface IClients : ICrud<Client>
    {
       Task< ICollection<Meeting>> GetClientMeetings(string id);
    }
}
