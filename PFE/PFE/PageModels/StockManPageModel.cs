using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.PageModels
{
    [AddINotifyPropertyChangedInterface]
    class StockManPageModel : FreshMvvm.FreshBasePageModel
    {
        public StockManPageModel()
        {

        }

        public override void Init(object initData)
        {
            base.Init(initData);
        }
    }
}
