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
    public class ServiceOffre : Service<offre>,IServiceOffre
    {
        private static IDatabaseFactory db = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(db);
        public ServiceOffre():base(uow)
        {

        }
       
        public IEnumerable<offre> getOfferByLocationFilter(offre o)
        {
            string location = o.location;
            IEnumerable<offre> offres = uow.GetRepository<offre>().GetAll().ToList();
            var req = from a in offres
                      where a.location.Contains(location)
                      orderby a.candidatures.Where(x => x.aspnetuser.cvs.ToList().Where(c => c.location.Contains(location)).Count() > 0).Count()

                      select a;

            return req.ToList();

        }
       
    }
}
