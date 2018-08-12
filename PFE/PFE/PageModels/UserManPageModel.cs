using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.PageModels
{
    [AddINotifyPropertyChangedInterface]
    class UserManPageModel : FreshMvvm.FreshBasePageModel
    {
        public UserManPageModel()
        {

        }
        public override void Init(object initData)
        {
            base.Init(initData);
        }
    }
}
