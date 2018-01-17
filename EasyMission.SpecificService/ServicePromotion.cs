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
    public class ServicePromotion : Service<promotion>,IServicePromotion
    {
        private static IDatabaseFactory db = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(db);
        public ServicePromotion():base(uow)
        {

        }
        public List<promotion> getPromotions()
        {
            return uow.GetRepository<promotion>().GetAll().ToList();
        }

        public List<service> getService(DateTime datePromotion,string name)
        {
            List<service> services = uow.GetRepository<service>().GetAll().Where(x => x.promotions.Where(c => c.dateDebut<datePromotion).Count() > 0).ToList();
            var req = from s in services
                       where s.offres.Where(x => x.candidatures.Where(c => c.aspnetuser.Email.Contains(name)).Count() > 0).Count() > 0
                      select s;
            return req.ToList();
        }



        public Dictionary<string, int> StatPromotion()
        {

            var tmp = uow.GetRepository<promotion>().GetAll()
                   .GroupBy(x => x.idService);


            var result = tmp.Select(y => new
            {
                Id = y.Key,
                Name = y
                    .Select(x => x.service.nomService)
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

    }
}
