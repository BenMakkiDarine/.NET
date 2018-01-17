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
    public class ServiceCommentaire : Service<commentaire>,IServiceCommentaire
    {
        private static IDatabaseFactory db = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(db);
        public ServiceCommentaire():base(uow)
        {

        }

        public Dictionary<string, int> StatCommentaire()
        {

            var tmp = uow.GetRepository<commentaire>().GetAll()
                   .GroupBy(x => x.idForum);


            var result = tmp.Select(y => new
            {
                Id = y.Key,
                Name = y
                    .Select(x => x.forum.nomForum)
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
