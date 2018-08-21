using PFE.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PFE.Services
{
    interface IRestServices
    {
        Task<IList<UTILISATEUR>> GetUserAsync();
        Task<IList<UTILISATEURSGRP>> GetGroupAsync();
        Task<IList<UTILISATEUR>> GetUserByGroupIdAsync(string groupId);
        bool Login(UTILISATEUR user);
    }
}
