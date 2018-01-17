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
    public class ServiceService : Service<service>,IServiceService
    {
        private static IDatabaseFactory db = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(db);
        public ServiceService():base(uow)
        {

        }
    
      public IEnumerable<feedback> getFeedBackbyId(int id)
        {
            
            return uow.GetRepository<feedback>().GetAll().Where(w => w.idService.Equals(id)).ToList();
        }
        public List<service> getHighDemandedServices(string category)
        {
            IEnumerable<service> services = uow.GetRepository<service>().GetAll().Where(x => x.categorieService.Contains(category)).ToList();
            var req = from s in services
                      orderby s.offres.Count()
                      select s;
            return req.ToList();


        }

        public Dictionary<string, int> StatService()
        {

            var tmp = uow.GetRepository<service>().GetAll()
                   .GroupBy(x => x.user_idUser);


            var result = tmp.Select(y => new
            {
                Id = y.Key,
                Name = y
                    .Select(x => x.aspnetuser.Name)
                    .FirstOrDefault(),
                Count = y.Count()

            });




            Dictionary<String, int> liste = new Dictionary<String, int>();
            foreach (var f in result)
            {
                liste.Add(f.Name, f.Count);
            }
            return liste;

        }


        public List<aspnetuser> getAgentByService(string category)
        {
            List<aspnetuser> users = uow.GetRepository<aspnetuser>().GetAll().ToList();
            var req = from u in users
                      where u.candidatures.Where(x => x.status.Equals("oui")).Count() > 0

                      where u.offres.Where(x=>x.candidatures.Where(w=>w.offre.service.categorieService.Equals(category)).Count()>0).Count()>0
                      orderby u.candidatures.Where(x=>x.status.Equals("oui"))
                      select u;
            return req.ToList();
        }



    }
}
