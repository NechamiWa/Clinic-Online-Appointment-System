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
    public class BLMeetingService : IBLMeeting
    {
        IMeetings meetingService { get; set; }
        public BLMeetingService(DALManager dm)
        {
            meetingService = dm.Meetings;
        }
        public void Create(BLMeeting item)
        {
            throw new Exception("אין אפשרות ליצור אובייקט מסוג זה");
        }

        public void Delete(BLMeeting item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BLMeeting>> Read()
        {
            List<BLMeeting> bLMeetings = new List<BLMeeting>();
            try
            {
                meetingService.Read().Result.ForEach(m =>
                {
                    bLMeetings.Add(new BLMeeting() { ClientName = m.Client.Name, TherapistName = m.Therapist.Name, Date = m.Date });
                });
                return bLMeetings;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Read method: {ex.Message}");
                return new List<BLMeeting>();
            }
        }

        public void Update(BLMeeting item)
        {
            throw new NotImplementedException();
        }
        public async Task<ICollection<BLMeeting>> GetMeetingsByDate(DateTime date)
        {
            try
            {
                return this.Read().Result.Where(m => m.Date == date).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetMeetingsByDate method: {ex.Message}");
                return new List<BLMeeting>();
            }
        }

    }
}
