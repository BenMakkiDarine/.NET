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
    public class ServiceForum : Service<forum>,IServiceForum
    {
        private static IDatabaseFactory db = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(db);
        public ServiceForum():base(uow)
        {

        }
      public aspnetuser getUserName(String id)
        {
            return uow.GetRepository<aspnetuser>().Get(x => x.Id.Equals(id));
        }
        public List<forum> getForums()
        {
            return uow.GetRepository<forum>().GetAll().ToList();
        }
        public List<commentaire> getTask1(string serviceName)
        {
            List<commentaire> commentaires = uow.GetRepository<commentaire>().GetAll().ToList();
            var req = from c in commentaires
                      where c.aspnetuser.candidatures.Where(x=>x.offre.service.nomService.Contains(serviceName)).Count()>0
                      select c;


            return req.ToList();
        }
       
    }
}
