using PFE.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PFE.PageModels
{
    [AddINotifyPropertyChangedInterface]
    class UserPageModel : FreshMvvm.FreshBasePageModel
    {
        public string username { get; set; }
        public string login { get; set; }
        public string pass { get; set; }
        public UTILISATEUR selectedUser { get; set; }
        public IList<UTILISATEURSGRP> _role { get; set; }
        public UTILISATEURSGRP selectedrole { get; set; }
        public ObservableCollection<UTILISATEUR> userList { get; set; }
        public ICommand validate => new Command(_validate);
        public ICommand modifier => new Command(_modifier);
        public ICommand delete => new Command(_delete);

        private void _delete(object obj)
        {
            userList.Remove(selectedUser);
        }

        private void _modifier(object obj)
        {
            login = string.Empty;
            username = string.Empty;
            pass = string.Empty;
        }

        private void _validate(object obj)
        {
            //if(string.IsNullOrEmpty(login) && string.IsNullOrEmpty(username) && string.IsNullOrEmpty(pass))
            userList.Add(new UTILISATEUR()
            {
                USRLOGIN = login,
                USRNOM = username,
                USRPWD = pass
            });
        }

        public UserPageModel()
        {

        }
        public override void Init(object initData)
        {
            base.Init(initData);
            _role = new List<UTILISATEURSGRP>
        {
            new UTILISATEURSGRP(){ INTITULEGRP = "Administrator"},
            new UTILISATEURSGRP(){ INTITULEGRP = "User"}
        };
            userList = new ObservableCollection<UTILISATEUR>
        {
            new UTILISATEUR(){ USRLOGIN = "maher"},
            new UTILISATEUR(){ USRLOGIN = "Randa"},
            new UTILISATEUR(){ USRLOGIN = "Bahloul"},
        };
        }
    }
}
