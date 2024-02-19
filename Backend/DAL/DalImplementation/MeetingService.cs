using DAL.DalApi;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalImplementation
{
    public class MeetingService : IMeetings
    {
        dbcontext db;
        public MeetingService(dbcontext db)
        {
            this.db = db;
        }
        public void Create(Meeting meeting)
        {
            try
            {
                db.Meetings.Add(meeting);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Meeting meeting)
        {
            try
            {
                db.Meetings.Remove(meeting);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task< List<Meeting>> Read()
        {
            try
            {
                return db.Meetings.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Update(Meeting item)
        {
            throw new NotImplementedException();
        }
    }
}
