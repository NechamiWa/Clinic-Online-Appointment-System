using BL.BLApi;
using BL.BO;
using DAL;
using DAL.DalApi;
using DAL.DalImplementation;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLImplementation
{
    public class JoinDateClientService : IJoinDateClient
    {
        public IClients clientService;
        public JoinDateClientService(DALManager dm)
        {
            this.clientService = dm.Clients;
        }

        public void Create(JoinDateClient item)
        {

            Client newClient = new Client();
            try
            {
                newClient.Name = item.Name;
                newClient.Id = item.Id;
                newClient.PhoneNumber = item.PhoneNumber;
                newClient.Email = item.Email;
                clientService.Create(newClient);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void Delete(JoinDateClient item)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<BLMeeting>> GetBLClientMeetings(string id)
        {
            List<BLMeeting> meetings = new List<BLMeeting>();
            List<Meeting> meets = new List<Meeting>();
            try
            {
                meets = clientService.GetClientMeetings(id).Result.ToList();
                meets.ForEach(m => meetings.Add(new BLMeeting() { ClientName = m.Client.Name, TherapistName = m.Therapist.Name, Date = m.Date }));
                return meetings;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<DateTime> GetJoinDate(Client client)
        {
            DateTime joinDate = DateTime.Now;
            try
            {
                clientService.GetClientMeetings(client.Id).Result.ToList().ForEach(meeting =>
            {
                if (meeting.Date > joinDate)
                    joinDate = meeting.Date;
            });
                return joinDate;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<JoinDateClient>> Read()
        {
            List<JoinDateClient> joinDateClients = new List<JoinDateClient>();
            try
            {
                clientService.Read().Result.ForEach(c =>
            {
                joinDateClients.Add(new JoinDateClient() { Id = c.Id, Name = c.Name, PhoneNumber = c.PhoneNumber, Email = c.Email, JoinDate = GetJoinDate(c).Result }); ;
            });
                return joinDateClients;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<JoinDateClient>> GetClientById(string id)
        {
            try
            {
                return this.Read().Result.Where(c => c.Id == id).ToList();
            }
            catch (Exception ex) { throw ex; }
        }


        public void Update(JoinDateClient item)
        {
            throw new NotImplementedException();
        }
    }
}
