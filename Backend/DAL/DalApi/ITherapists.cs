using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface ITherapists : ICrud<Therapist>
    {
       Task< ICollection<Meeting>> GetTherapistsMeetings(string id);
    }
}
