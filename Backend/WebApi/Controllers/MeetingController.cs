using BL.BLApi;
using BL.BO;
using BL;
using DAL.DalApi;
using DAL.Models;
using DAL;
using Microsoft.AspNetCore.Mvc;
using DAL.DalImplementation;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Meeting")]
    public class MeetingController
    {
        IBLMeeting meetingService;
        IBLNewMeeting newMeetingService;
        public MeetingController(BLManager blManager)
        {
            this.meetingService = blManager.meetings;
            this.newMeetingService = blManager.newMeetings;
        }

        [HttpPost]
        [Route("CreateMeeting")]
        public void CreateMeeting(BLNewMeeting m)
        {
            newMeetingService.Create(m);
        }


        [HttpGet]
        [Route("GetMeetings")]
        public ICollection<BLMeeting> GetMeetings()
        {
            return meetingService.Read().Result;
        }


        [HttpGet]
        [Route("GetMeetingsByDate")]
        public ICollection<BLMeeting> GetMeetingsByDate(DateTime date)
        {
            return meetingService.GetMeetingsByDate(date).Result;
        }

        [HttpGet]
        [Route("GetMeetingsOnSecrateryFormat")]
        public List<BLNewMeeting> GetMeetingsOnSecrateryFormat()
        {
            return newMeetingService.Read().Result;
        }
    }
}

