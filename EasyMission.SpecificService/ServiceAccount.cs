using ServicesPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMission.Domaine;
using EasyMission.SpecificService;
using EasyMission.Data.Infrastructure;

namespace EasyMission.SpecificService
{
    public class ServiceAccount : Service<aspnetuser>,IServiceAccount
    {
        private static IDatabaseFactory db = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(db);
        public ServiceAccount():base(uow)
        {

        }
        public aspnetuser getUser(String id)
        {
            return uow.GetRepository<aspnetuser>().Get(x => x.Id.Equals(id));
        }
       public void updateUser(aspnetuser u)
        {
            uow.GetRepository<aspnetuser>().Update(u);
        }

        public int countReclamation(string id)
        {
            List<reclamation> rec = uow.GetRepository<reclamation>().GetAll().Where(x => x.aspnetuser1.Id.Equals(id)).ToList();

            

            return rec.Count();
        }
        public IEnumerable<aspnetuser> getTalentedUser(string specialite)
        {
            IEnumerable<aspnetuser> users = uow.GetRepository<aspnetuser>().GetAll().ToList();
            var req = from u in users
                      where u.cvs.Where(x=>x.specialite.Contains(specialite)).Count()>0
                      where u.aspnetroles.Where(x => x.Name.Equals("Agent")).Count() > 0

                      orderby u.offres.Count()
                      select u;
            return req.ToList();
        }
        public IEnumerable<aspnetuser> getFreeTalentedUser(int numberEndedOffer,string op)
        {
            IEnumerable<aspnetuser> users = uow.GetRepository<aspnetuser>().GetAll().ToList();
            if (op.Equals(">"))
            {
                var req = from u in users
                          where u.candidatures.Where(x => x.status.Contains("non") || x.dateSubmit > DateTime.Now.AddDays(30)).Count() > numberEndedOffer
                          where u.aspnetroles.Where(x=>x.Name.Equals("Agent")).Count()>0
                          orderby u.offres.Count()
                          select u;
                return req.ToList();

            }
            else
            {
                var req = from u in users
                          where u.candidatures.Where(x => x.status.Contains("non") || x.dateSubmit < DateTime.Now.AddDays(30)).Count() < numberEndedOffer
                          where u.aspnetroles.Where(x => x.Name.Equals("Agent")).Count() > 0
                          orderby u.offres.Count()
                          select u;
                return req.ToList();

            }



        }
        public IEnumerable<aspnetuser> getTalened()
        {
            IEnumerable<aspnetuser> users = uow.GetRepository<aspnetuser>().GetAll().ToList();
            var req = from u in users
                      orderby u.offres.Count()
                      select u;
            return req.ToList();
        }

        public List<aspnetuser> getUsersChat(string room)
        {
            IEnumerable<aspnetuser> users = uow.GetRepository<aspnetuser>().GetAll().ToList();
            var req = from u in users
                      where u.cvs.Where(x => x.specialite.Contains(room)).Count() > 0
                      select u;
            return req.ToList();

        }

    }
}
