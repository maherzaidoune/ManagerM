using PFE.Helper;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PFE.PageModels
{
    [AddINotifyPropertyChangedInterface]
    class SellMainPageModel : FreshMvvm.FreshBasePageModel
    {
        public ICommand devis => new Command(_devis);

        private void _devis(object obj)
        {
            Navigation.initTabs();
        }

        public SellMainPageModel()
        {

        }
        public override void Init(object initData)
        {
            base.Init(initData);
        }
    }
}
