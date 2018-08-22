using PFE.Models;
using PFE.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PFE.PageModels
{
    [AddINotifyPropertyChangedInterface]
    class CTieresPageModel : FreshMvvm.FreshBasePageModel
    {
        public string search { get; set; }
        public string info { get; set; }
        public TIERS tiers { get; set; }
        public ObservableCollection<TIERS> tiersList { get; set; }
        private IRestServices _restServices;
        public ICommand find => new Command(_find);

        private void _find(object obj)
        {
            
            IList<TIERS> list = null;
            Task.Run(async () =>
                {
                    try
                    {
                        list = await _restServices.GetTiers(search);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                }).Wait();
            if (list != null)
                tiersList = new ObservableCollection<TIERS>(list);

        }

        public CTieresPageModel(IRestServices _restServices)
        {
            this._restServices = _restServices;
        }
        public override void Init(object initData)
        {
            base.Init(initData);
        }
    }
}
