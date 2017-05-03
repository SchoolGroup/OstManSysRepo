using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstManSysMVVM.Persistency;

namespace OstManSysMVVM.Model
{
    class ResidentCatalogSingleton
    {
        private static ResidentCatalogSingleton _instance = new ResidentCatalogSingleton();

        public static ResidentCatalogSingleton Instance
        {
            get { return _instance; }
        }

        public ObservableCollection<Resident> Residents { get; set; }

        private ResidentCatalogSingleton()
        {
            Residents = new ObservableCollection<Resident>(new PersistencyFacade().GetResidents());
        }
    }
}
