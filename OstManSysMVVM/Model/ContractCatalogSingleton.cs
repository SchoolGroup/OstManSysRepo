using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstManSysMVVM.Handler;
using OstManSysMVVM.Persistency;

namespace OstManSysMVVM.Model
{
    class ContractCatalogSingleton
    {
        private static ContractCatalogSingleton _instance = null;

        //public ApartmentCatalogSingleton GetInstance()
        //{
        //    if (_instance==null)
        //    {
        //        _instance = new ApartmentCatalogSingleton();
        //    }
        //    return _instance;
        //}
        public static ContractCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ContractCatalogSingleton();
                }
                return _instance;
            }
        }

        public int ResidentID { get; set; }
        public ObservableCollection<Contract> Contracts { get; set; }
        private ContractCatalogSingleton()
        {
            Contracts = new ObservableCollection<Contract>(new PersistencyFacade().GetContracts());
        }
    }
}
