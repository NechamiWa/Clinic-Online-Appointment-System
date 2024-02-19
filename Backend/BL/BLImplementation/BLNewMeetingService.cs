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
    public class BLNewMeetingService : IBLNewMeeting
    {
        IMeetings meetingsService;
        public BLNewMeetingService(DALManager dm)
        {
            meetingsService = dm.Meetings;
        }
        public void Create(BLNewMeeting item)
        {
            try
            {
                Meeting newMeeting = new Meeting();
                newMeeting.ClientId = item.ClientId;
                newMeeting.TherapistId = item.TherapistId;
                newMeeting.Date = item.Date;
                meetingsService.Create(newMeeting);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void Delete(BLNewMeeting item)
        {
            try
            {
                Meeting newMeeting = new Meeting();
                newMeeting.ClientId = item.ClientId;
                newMeeting.TherapistId = item.TherapistId;
                newMeeting.Date = item.Date;
                meetingsService.Delete(newMeeting);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<List<BLNewMeeting>> Read()
        {
            List<BLNewMeeting> bLMeetings = new List<BLNewMeeting>();
            try
            {
                meetingsService.Read().Result.ForEach(m =>
            {
                bLMeetings.Add(new BLNewMeeting() { ClientId = m.ClientId, TherapistId = m.TherapistId, Date = m.Date });
            });
                return bLMeetings;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void Update(BLNewMeeting item)
        {
            throw new NotImplementedException();
        }
    }
}
