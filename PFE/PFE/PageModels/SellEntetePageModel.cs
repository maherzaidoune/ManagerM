using PFE.Models;
using PFE.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

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
        public ICommand tiers => new Command(_tiers);
        private IRestServices _restService;
        private void _tiers(object obj)
        {
            Device.BeginInvokeOnMainThread(async()=>{
                await CoreMethods.PushPageModel<CTieresPageModel>();
                RaisePropertyChanged();
            });
        }

        public SellEntetePageModel(IRestServices _restService)
        {
            date = DateTime.Today;
            this._restService = _restService;
        }
        public override void Init(object initData)
        {
            base.Init(initData);
            Task.Run(async () =>
            {
                nature = await _restService.GetPieceNature("V", "C");
                depo = await _restService.GetDepot("O");
            });
        }

    }
}
