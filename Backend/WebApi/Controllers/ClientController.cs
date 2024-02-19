using Microsoft.AspNetCore.Mvc;
using DAL;
using DAL.DalImplementation;
using DAL.Models;
using DAL.DalApi;
using BL;
using BL.BLApi;
using BL.BO;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("Client")]
    public class ClientController : Controller
    {
       
        IJoinDateClient blClientService;
        public ClientController( BLManager blManager)
        {
            this.blClientService = blManager.JoinDateClient;
        }
        [HttpGet]
        [Route("GetClients")]
        public List<JoinDateClient> GetClients()
        {
            return blClientService.Read().Result;
        }

        [HttpPost]
        [Route("CreateClient")]
        public void CreateClient(JoinDateClient client)
        {
            blClientService.Create(client);
        }

        [HttpGet]
        [Route("GetMeetings")]
        public ICollection<BLMeeting> GetMeetings(string id)
        {
            return blClientService.GetBLClientMeetings(id).Result;
        }

        [HttpGet]
        [Route("GetClientById")]
        public ICollection<JoinDateClient> GetClientById(string id)
        {
            return blClientService.GetClientById(id).Result;
        }
    }
}
