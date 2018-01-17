using EasyMission.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EasyMission.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private easymissionEntities dataContext;
        public easymissionEntities DataContext { get { return dataContext; } }
        public DatabaseFactory()
        {
            dataContext = new easymissionEntities();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }


}
