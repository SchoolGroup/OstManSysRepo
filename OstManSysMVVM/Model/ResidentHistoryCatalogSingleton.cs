using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstManSysMVVM.Persistency;

namespace OstManSysMVVM.Model
{
    class ResidentHistoryCatalogSingleton
    {
        private static ResidentHistoryCatalogSingleton _instance = null;

      
        public static ResidentHistoryCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ResidentHistoryCatalogSingleton();
                }
                return _instance;
            }
        }

        public ObservableCollection<ResidentHistory> ResidentHistories { get; set; }
        private ResidentHistoryCatalogSingleton()
        {
            ResidentHistories = new ObservableCollection<ResidentHistory>(new PersistencyFacade().GetResidentHistories());
        }
    }
}
