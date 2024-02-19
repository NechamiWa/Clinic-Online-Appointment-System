using BL.BLApi;
using BL.BLImplementation;
using BL.BO;
using DAL;
using DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{// תפקיד המחלקה ליצג את השכבה
    public class BLManager
    {
        public IJoinDateClient JoinDateClient { get; }
        public IBLTherapist JoinDateTherapist { get; }
        public IBLMeeting meetings { get; set; }
        public IBLNewMeeting newMeetings { get; set; }
        public BLManager()
        {
            ServiceCollection service = new ServiceCollection();
            service.AddSingleton<DALManager>();
            //יצור האוביקט
            service.AddSingleton<IJoinDateClient, JoinDateClientService>();
            service.AddSingleton<IBLTherapist, BLTherapistService>();
            service.AddSingleton<IBLMeeting, BLMeetingService>();
            service.AddSingleton<IBLNewMeeting, BLNewMeetingService>();
            var provider = service.BuildServiceProvider();
           //מציבה למאפין
            JoinDateClient = provider.GetRequiredService<IJoinDateClient>();
            JoinDateTherapist = provider.GetRequiredService<IBLTherapist>();
            meetings = provider.GetRequiredService<IBLMeeting>();
            newMeetings=provider.GetRequiredService<IBLNewMeeting>();


        }
    }
}
