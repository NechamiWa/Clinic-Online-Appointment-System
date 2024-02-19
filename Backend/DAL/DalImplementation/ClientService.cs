using DAL.DalApi;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalImplementation
{
    public class ClientService : IClients
    {
        dbcontext db;
        public ClientService(dbcontext dbcontext)
        {
            this.db = dbcontext;
        }
        public void Create(Client item)
        {
            try
            {
                List<Client> CurrentClients = this.Read().Result.Where(i => i.Id == item.Id).ToList();
                if (CurrentClients.Count > 0)
                    throw new Exception("this client is exist");
                else
                {
                    db.Clients.Add(item);
                    db.SaveChanges();
                }
           ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Client item)
        {
            try {
                db.Clients.Remove(item);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<  ICollection<Meeting>> GetClientMeetings(string id)
        {
            try
            {
                Client client = db.Clients.ToList().Where(c => c.Id == id).FirstOrDefault();

                if (client != null)
                {
                    return client.Meetings;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task< List<Client>> Read()
        {
            try {
                return db.Clients.Include(c => c.Meetings).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Update(Client item)
        {
            throw new NotImplementedException();
        }


    }
}
