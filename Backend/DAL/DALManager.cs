using DAL.DalApi;
using DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DalApi;
using DAL.Models;
using DAL.DalImplementation;

namespace DAL
{
    public class DALManager
    {
        public IClients Clients { get; }
        public ITherapists Therapists { get; }
        public IMeetings Meetings { get; }

        public DALManager()
        {
            ServiceCollection service = new ServiceCollection();
            service.AddSingleton<dbcontext>();
            service.AddSingleton<IClients, ClientService>();
            service.AddSingleton<IMeetings, MeetingService>();
            service.AddSingleton<ITherapists, TherapistService>();
            var provider = service.BuildServiceProvider();
            Clients = provider.GetRequiredService<IClients>();
            Therapists = provider.GetRequiredService<ITherapists>();
            Meetings = provider.GetRequiredService<IMeetings>();
        }
    }
}
