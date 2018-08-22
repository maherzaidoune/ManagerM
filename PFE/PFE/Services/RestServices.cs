using Flurl.Http;
using PFE.Helper;
using PFE.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PFE.Services
{
    class RestServices : IRestServices
    {
        public Task<IList<UTILISATEURSGRP>> GetGroupAsync()
        {
            try
            {
                Constant c = new Constant("http://192.168.43.174:3000");
                var l =  c.group_uri.GetJsonAsync<IList<UTILISATEURSGRP>>();
                return l;
            }
            catch (FlurlHttpException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            catch (Exception ex)
            {
                //noInternetConnection();
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Task<IList<UTILISATEUR>> GetUserByGroupIdAsync(string groupId)
        {
            try
            {
                Constant c = new Constant("http://192.168.43.174:3000");
                var user =  (c.user_uri + "?filter[where][USERGRP]=" + groupId).GetJsonAsync<IList<UTILISATEUR>>();
                return user;
                
            }
            catch (FlurlHttpException e)
            {
                //userNotAuth();
                Console.WriteLine(e.StackTrace);
            }
            catch (Exception ex)
            {
                //noInternetConnection();
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Task<IList<UTILISATEUR>> GetUserAsync()
        {
            try
            {
                Constant c = new Constant("http://192.168.43.174:3000");
                return c.user_uri.GetJsonAsync<IList<UTILISATEUR>>();
            }
            catch (FlurlHttpException)
            {
                //userNotAuth();
            }
            catch (Exception ex)
            {
                //noInternetConnection();
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public bool Login(UTILISATEUR user)
        {
            try
            {
                Constant c = new Constant("http://192.168.43.174:3000");
                return (c.user_uri + "count?where={\"and\":[{\"USRLOGIN\":" + user.USRLOGIN + "},{\"USRPWD\":\" " + user.USRPWD + "}]}").GetJsonAsync<login>().Result.count > 0;
            }
            catch (FlurlHttpException)
            {
                //userNotAuth();
            }
            catch (Exception ex)
            {
                //noInternetConnection();
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public Task<IList<TIERS>> GetTiers(string info)
        {
            try
            {
                Constant c = new Constant("http://192.168.43.174:3000");

                if (string.IsNullOrEmpty(info))
                {
                    return c.tiers_uri.GetJsonAsync<IList<TIERS>>();
                }
                return (c.tiers_uri + "?filter[where][or][0][TIRSOCIETE]=" + info + "&filter[where][or][1][TIRCODE]=" + info ).GetJsonAsync<IList<TIERS>>();
            }
            catch (FlurlHttpException e)
            {
                Console.WriteLine(e.StackTrace);
                //userNotAuth();
            }
            catch (Exception ex)
            {
                //noInternetConnection();
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Task<IList<PIECE_NATURE>> GetPieceNature(string PICCODE = null, string PITCODE = null, string PINLIBELLE = null, string PINSENSSTOCK = null)
        {
            Constant c = new Constant("http://192.168.43.174:3000");
            try
            {
                if(string.IsNullOrEmpty(PINLIBELLE) && string.IsNullOrEmpty(PINSENSSTOCK)) 
                    return (c.piece_nature_uri + "?filter[where][and][0][PICCODE]=" + PICCODE + "&filter[where][and][1][PITCODE]=" + PITCODE).GetJsonAsync<IList<PIECE_NATURE>>();
                if (string.IsNullOrEmpty(PINLIBELLE))
                    return (c.piece_nature_uri + "?filter[where][and][0][PICCODE]=" + PICCODE + "&filter[where][and][1][PITCODE]=" + PITCODE + "&filter[where][and][2][(PINSENSSTOCK]=" + PINSENSSTOCK).GetJsonAsync<IList<PIECE_NATURE>>();
                //return (c.piece_nature_uri + "?filter[where][AND][0][PICCODE ]=" + PICCODE + "&filter[where][AND][1][PITCODE ]=" + PITCODE + "&filter[where][AND][1][(PINSENSSTOCK]=" + PINSENSSTOCK).GetJsonAsync<IList<PIECE_NATURE>>();
            }
            catch (FlurlHttpException e)
            {
                Console.WriteLine(e.StackTrace);
                //userNotAuth();
            }
            catch (Exception ex)
            {
                //noInternetConnection();
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Task<IList<depot>> GetDepot(string DEPISACTIF, string DEPISPRINCIPAL = null)
        {
            Constant c = new Constant("http://192.168.43.174:3000");
            try
            {
                if (string.IsNullOrEmpty(DEPISPRINCIPAL))
                    return (c.depot_url + "?filter[where][DEPISACTIF]=" + DEPISACTIF).GetJsonAsync<IList<depot>>();
                return (c.depot_url + "?filter[where][and][0][DEPISACTIF]=" + DEPISACTIF + "&filter[where][and][1][DEPISPRINCIPAL]=" + DEPISPRINCIPAL ).GetJsonAsync<IList<depot>>();
            }
            catch (FlurlHttpException e)
            {
                Console.WriteLine(e.StackTrace);
                //userNotAuth();
            }
            catch (Exception ex)
            {
                //noInternetConnection();
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
