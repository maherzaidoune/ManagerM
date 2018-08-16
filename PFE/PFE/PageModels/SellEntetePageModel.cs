using PFE.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.PageModels
{
    [AddINotifyPropertyChangedInterface]
    class SellEntetePageModel : FreshMvvm.FreshBasePageModel
    {
        public PIECE_NATURE selectednature { get; set; }
        public IList<PIECE_NATURE> nature { get; set; }
        public string numeroPiece { get; set; }
        public DateTime date { get; set; }
        public IList<depot> depo { get; set; }
        public depot selectedDepo { get; set; }
        public string numerofournisseur { get; set; }
        public string fournisseurintitule { get; set; }
        public string Codeaffaire { get; set; }
        public string affaireintitule { get; set; }
        public SellEntetePageModel()
        {

        }
        public override void Init(object initData)
        {
            base.Init(initData);
        }

    }
}
