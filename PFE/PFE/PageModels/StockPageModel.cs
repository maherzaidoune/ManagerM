using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.PageModels
{
    [AddINotifyPropertyChangedInterface]
    class StockPageModel : FreshMvvm.FreshBasePageModel
    {
        public StockPageModel()
        {

        }
        public override void Init(object initData)
        {
            base.Init(initData);
        }
    }
}
