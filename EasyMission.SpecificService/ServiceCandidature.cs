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
    public class ServiceCandidature : Service<candidature>,IServiceCandidature
    {
        private static IDatabaseFactory db = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(db);
        public ServiceCandidature():base(uow)
        {

        }
        public Dictionary<string, int> StatCandidature()
        {

            var tmp = uow.GetRepository<candidature>().GetAll()
                   .GroupBy(x => x.idCandidature);


            var result = tmp.Select(y => new
            {
                Id = y.Key,
                Name = y
                    .Select(x => x.offre.description)
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



        public List<candidature> getCandidatures(String id)
        {
            return uow.GetRepository<candidature>().GetAll().Where(x=>x.offre.aspnetuser.Id.Equals(id)).ToList();
        }
        public IEnumerable<candidature> getCandidatureAccepted(DateTime dateDebut,DateTime dateFin)
        {

            IEnumerable<candidature> candidaturesList = uow.GetRepository<candidature>().GetAll().Where(x => x.offre.service.promotions.Where(c => c.dateDebut<(dateDebut) || c.dateFin<(dateFin)).Count() > 0).ToList();

            var req = from c in candidaturesList
                      where c.status.Equals("oui")
                      select c;
            return req.ToList();
        }

        public IEnumerable<promotion> getPromotionByOffer()
        {
            List<promotion> promotions = uow.GetRepository<promotion>().GetAll().ToList();
            var req =from p in promotions
                    orderby p.service.promotions
                    select p;
            return req.ToList();

        }

        public IEnumerable<aspnetuser> getUserByOffer(int id)
        {
            return uow.GetRepository<aspnetuser>().GetAll().Where(x => x.offres.Where(c => c.idOffre.Equals(id)).Count() > 0).ToList(); 
        }



        
    }
}
