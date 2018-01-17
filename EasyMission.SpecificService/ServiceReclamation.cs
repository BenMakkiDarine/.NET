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
    public class ServiceReclamation : Service<reclamation>, IServiceReclamation
    {
        private static IDatabaseFactory db = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(db);
        public ServiceReclamation():base(uow)
        {

        }
        public List<reclamation> getReclamations()
        {
            return uow.GetRepository<reclamation>().GetAll().ToList();
        }

        public IEnumerable<reclamation> getReclamationBySpecialite(string keyword,string offre)
        {
            IEnumerable<reclamation> reclamations = uow.GetRepository<reclamation>().GetAll().ToList();
            var req = from r in reclamations
                      where r.aspnetuser.candidatures.Where(x=>x.offre.description.Contains(offre)).Count()>0
                      where r.aspnetuser1.cvs.Where(c=>c.title.Contains(keyword)).Count()>0
                      select r;

            return req.ToList();
        }

        public Dictionary<string, int> StatReclamation()
        {

            var tmp = uow.GetRepository<reclamation>().GetAll()
                   .GroupBy(x => x.user_idUser);


            var result = tmp.Select(y => new
            {
                Id = y.Key,
                Name = y
                    .Select(x => x.aspnetuser1.Name)
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
        public IEnumerable<reclamation> getReclamationByTitle(string title)
        {
            IEnumerable<reclamation> reclmations = uow.GetRepository<reclamation>().GetAll().ToList();
            var req = from r in reclmations
                      where r.aspnetuser.offres.Where(x => x.description.Contains(title)).Count() > 0
                      select r;
            return req.ToList();
        }

    }
}
