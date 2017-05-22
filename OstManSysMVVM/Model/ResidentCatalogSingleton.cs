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
        private static ResidentCatalogSingleton _instance = null;

        public static ResidentCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ResidentCatalogSingleton();
                }
                return _instance;
            }
        }

        public Resident CurrentResident { get; set; }
        public Resident SelectedResident { get; set; }
        public ObservableCollection<Resident> Residents { get; set; }

        private ResidentCatalogSingleton()
        {
            Residents = new ObservableCollection<Resident>(new PersistencyFacade().GetResidents());
        }
    }
}
