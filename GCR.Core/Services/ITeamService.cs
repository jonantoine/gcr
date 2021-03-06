﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCR.Core.Entities;

namespace GCR.Core.Services
{
    public interface ITeamService
    {
        IQueryable<Team> Fetch();
        Team GetById(int id);
        void SaveTeam(Team team);
        void DeleteTeam(Team team);
    }
}
