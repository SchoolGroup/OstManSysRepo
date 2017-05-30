using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstManSysMVVM.Persistency;

namespace OstManSysMVVM.Model
{
    class DownpipeApartmentAddressCatalogSingleton
    {
        private static DownpipeApartmentAddressCatalogSingleton _instance = null;

      
        public static DownpipeApartmentAddressCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DownpipeApartmentAddressCatalogSingleton();
                }
                return _instance;
            }
        }

        public ObservableCollection<DownpipeApartmentAddress> DownpipeApartmentAddresses { get; set; }
        private DownpipeApartmentAddressCatalogSingleton()
        {
            DownpipeApartmentAddresses = new ObservableCollection<DownpipeApartmentAddress>(new PersistencyFacade().GetDownpipeApartmentAddress());
        }
    }
}
