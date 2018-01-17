using EasyMission.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUI.Models
{
    public class PromotionOffer
    {
        public IEnumerable<aspnetuser> users { get; set; }
        public IEnumerable<promotion> promotions { get; set; }
    }
}