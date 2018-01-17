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
    public class ServiceCv : Service<cv>,IServiceCV
    {
        private static IDatabaseFactory db = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(db);
        public ServiceCv():base(uow)
        {

        }
      public cv getCvById(string id)
        {
            return uow.GetRepository<cv>().Get(x => x.user_idUser.Equals(id));
        }
        public IEnumerable<cv> getUsersByRole(string role)
        {
            List<cv> cvs = uow.GetRepository<cv>().GetAll().ToList();
            var req = from p in cvs
                      where p.aspnetuser.aspnetroles.Count() > 0
                      where p.aspnetuser.aspnetroles.Where(x=>x.Name.Equals(role)).Count()>0
                      select p;
            return req.ToList();
        }

    }
}
