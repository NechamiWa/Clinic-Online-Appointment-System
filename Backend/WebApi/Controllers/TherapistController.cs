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
    [Route("Therapist")]

    public class TherapistController
    {
        IBLTherapist therapistService;
        public TherapistController(BLManager blManager)
        {
            this.therapistService = blManager.JoinDateTherapist;
        }

        [HttpGet]
        [Route("GetTherapist")]
        public List<BLTherapist> GetTherapist()
        {
            return therapistService.Read().Result;
        }

        [HttpPost]
        [Route("CreateTherapist")]
        public void CreateTherapist(BLTherapist t)
        {
            therapistService.Create(t);
        }


        [HttpGet]
        [Route("GetMeetings")]
        public ICollection<BLMeeting> GetMeetings(string id)
        {
            return therapistService.GetBLTherapistMeetings(id).Result;
        }

        [HttpGet]
        [Route("GetTherapistById")]
        public ICollection<BLTherapist> GetTherapistById(string id)
        {
            return therapistService.GetTherapistById(id).Result;
        }
    }
}
