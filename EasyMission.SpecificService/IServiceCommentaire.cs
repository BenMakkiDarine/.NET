﻿using EasyMission.Domaine;
using ServicesPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMission.SpecificService
{
    public interface IServiceCommentaire : IService<commentaire>
    {
        Dictionary<string, int> StatCommentaire();
    }
}
