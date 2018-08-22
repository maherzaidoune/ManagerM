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
        Task<IList<TIERS>> GetTiers(string info);
        Task<IList<depot>> GetDepot(string DEPISACTIF, string DEPISPRINCIPAL = null);
        Task<IList<PIECE_NATURE>> GetPieceNature(string PICCODE = null, string PITCODE = null, string PINLIBELLE = null, string PINSENSSTOCK = null);
    }
}
