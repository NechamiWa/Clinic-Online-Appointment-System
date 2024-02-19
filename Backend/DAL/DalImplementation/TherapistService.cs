using DAL.DalApi;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalImplementation
{
    public class TherapistService : ITherapists
    {
        dbcontext db;
        public TherapistService(dbcontext dbcontext)
        {

            this.db = dbcontext;

        }

        public void Create(Therapist item)
        {
            try
            {
                List<Therapist> CurrentClients = this.Read().Result.Where(i => i.Id == item.Id).ToList();
                if (CurrentClients.Count > 0)
                    throw new Exception("this client is exist");
                else
                {
                    db.Therapists.Add(item);
                    db.SaveChanges();
                }
           ;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void Delete(Therapist item)
        {
            try
            {
                db.Therapists.Remove(item);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task< ICollection<Meeting>> GetTherapistsMeetings(string id)
        {
            try
            {
                Therapist therapist = null;
                this.Read().Result.ForEach(t => { if (t.Id == id) therapist = t; });
                return therapist.Meetings;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task< List<Therapist>> Read()
        {
            try
            {
                return db.Therapists.Include(c => c.Meetings).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Update(Therapist item)
        {
            throw new NotImplementedException();
        }
    }
}
