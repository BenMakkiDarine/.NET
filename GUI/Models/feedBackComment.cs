using EasyMission.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUI.Models
{
    public class feedBackComment
    {
        public feedback feedback { get; set; }

        public IEnumerable<feedback> feedbacks { get; set; }
    }
}