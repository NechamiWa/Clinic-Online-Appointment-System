using BL.BLApi;
using BL.BO;
using DAL.Models;
using DAL.DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DalImplementation;

namespace BL.BLImplementation
{
    public class BLTherapistService : IBLTherapist
    {
        ITherapists therapistService;
        public BLTherapistService(DALManager dm)
        {
            this.therapistService = dm.Therapists;

        }
        public void Create(BLTherapist item)
        {
            try
            {
                Therapist newTherapist = new Therapist();
                newTherapist.Name = item.Name;
                newTherapist.Id = item.Id;
                newTherapist.PhoneNumber = item.PhoneNumber;
                newTherapist.Email = item.Email;
                newTherapist.Salary = item.Salary;
                therapistService.Create(newTherapist);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void Delete(BLTherapist item)
        {
            try
            {
                Therapist delTherapist = new Therapist();
                delTherapist.Name = item.Name;
                delTherapist.Id = item.Id;
                delTherapist.PhoneNumber = item.PhoneNumber;
                delTherapist.Email = item.Email;
                delTherapist.Salary = item.Salary;
                therapistService.Delete(delTherapist);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<ICollection<BLMeeting>> GetBLTherapistMeetings(string id)
        {
            List<BLMeeting> meetings = new List<BLMeeting>();
            List<Meeting> meets = new List<Meeting>();
            try
            {
                meets = therapistService.GetTherapistsMeetings(id).Result.ToList();
                meets.ForEach(m => meetings.Add(new BLMeeting() { ClientName = m.Client.Name, TherapistName = m.Therapist.Name, Date = m.Date }));
                return meetings;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<DateTime> GetFirstMeeting(Therapist t)
        {
            DateTime firstMeeting = DateTime.Now;
            try
            {
                therapistService.GetTherapistsMeetings(t.Id).Result.ToList().ForEach(meeting =>
            {
                if (meeting.Date > firstMeeting)
                    firstMeeting = meeting.Date;
            });
                return firstMeeting;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<List<BLTherapist>> Read()
        {
            List<BLTherapist> therapists = new List<BLTherapist>();
            try
            {
                therapistService.Read().Result.ForEach(t =>
            {
                therapists.Add(new BLTherapist() { Id = t.Id, Name = t.Name, PhoneNumber = t.PhoneNumber, Email = t.Email, Salary = t.Salary, FirstMeeting = GetFirstMeeting(t).Result }); ;
            });
                return therapists;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<List<BLTherapist>> GetTherapistById(string id)
        {
            try
            {
                return this.Read().Result.Where(t => t.Id == id).ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public void Update(BLTherapist item)
        {
            throw new NotImplementedException();
        }
    }
}
