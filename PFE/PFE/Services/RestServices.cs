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
                return (c.user_uri + " count?where={\"and\":[{\"USRLOGIN\":" + user.USRLOGIN + "},{\"USRPWD\":\" " + user.USRPWD + "}]}").GetJsonAsync<login>().Result.count > 0;
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
    }
}
