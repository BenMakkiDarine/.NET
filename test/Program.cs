using EasyMission.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            easymissionEntities ctx = new easymissionEntities();
            candidature c = new candidature();
            c.status = "bara nayek";
            ctx.candidatures.Add(c);
            ctx.SaveChanges();
        }
    }
}
