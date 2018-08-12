using PFE.Models;
using PFE.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PFE.PageModels
{
    [AddINotifyPropertyChangedInterface]
    class LoginPageModel : FreshMvvm.FreshBasePageModel
    {
        private IDialogService _dialogServices;

        public LoginPageModel(IDialogService _dialogService)
        {
            this._dialogServices = _dialogService;
        }

        public bool isBusy { get; set; }
        public bool isEnabled { get; set; }


        public ICommand validate => new Command(login);
        private void login(object obj)
        {

            if(selectedrole == null || selecteduser == null)
            {
                _dialogServices.ShowMessage("make sure you select a valid user and role ", true);
            }
            else
            {
                isEnabled = false;
                isBusy = true;
                Task.Delay(3000);
                Task.Run(() =>
                {
                    // call api server simulate
                    _dialogServices.ShowMessage("Login success : " + selecteduser.USRLOGIN, false);
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        switch (selectedrole.INTITULEGRP)
                        {
                            case "Administrator":
                                await CoreMethods.PushPageModel<AdminMenuPageModel>();
                                RaisePropertyChanged();
                                break;
                            case "User":
                                await CoreMethods.PushPageModel<SellerMenuPageModel>();
                                RaisePropertyChanged();
                                break;
                            default:
                                _dialogServices.ShowMessage("ERROR", true);
                                break;
                        }
                        isBusy = false;
                        isEnabled = true;
                    });
                });
                
            }
             
        }

        public ICommand quit => new Command(quitter);

        private void quitter(object obj)
        {
            throw new NotImplementedException();
        }


        public UTILISATEURSGRP selectedrole { get; set; }
      

        public UTILISATEUR selecteduser { get; set; }
        

        //mocking role and user  list
        public List<UTILISATEURSGRP> _role { get; set; }
        public List<UTILISATEUR> _user { get; set; }

        public LoginPageModel()
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

            

            _user = new List<UTILISATEUR>
        {
            new UTILISATEUR(){ USRLOGIN = "maher"},
            new UTILISATEUR(){ USRLOGIN = "Randa"},
            new UTILISATEUR(){ USRLOGIN = "Bahloul"},
        };
            isBusy = false;
            isEnabled = true;
        }
    }
}
