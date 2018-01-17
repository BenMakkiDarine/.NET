using EasyMission.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUI.Models
{
    public class Details
    {
        public forum Forum { get; set; }
        public IEnumerable<commentaire> commentaires { get; set; }
        public commentaire Commentaire { get; set; }
    }
}