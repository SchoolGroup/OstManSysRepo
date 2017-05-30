using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstManSysMVVM.Persistency;

namespace OstManSysMVVM.Model
{
    class ApartmentAddressCatalogSingleton
    {
        private static ApartmentAddressCatalogSingleton _instance = null;

       
        public static ApartmentAddressCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ApartmentAddressCatalogSingleton();
                }
                return _instance;
            }
        }

        public ApartmentAddress SelectedApartmentAddress { get; set; }
        public ObservableCollection<ApartmentAddress> ApartmentAddresses { get; set; }
       
        private ApartmentAddressCatalogSingleton()
        {
            ApartmentAddresses = new ObservableCollection<ApartmentAddress>(new PersistencyFacade().GetApartmentAddresses());
        }
    }
}
