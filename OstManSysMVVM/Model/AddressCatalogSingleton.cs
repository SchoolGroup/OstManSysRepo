using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstManSysMVVM.Persistency;

namespace OstManSysMVVM.Model
{
    class AddressCatalogSingleton
    {
        private static AddressCatalogSingleton _instance = null;

        //public ApartmentCatalogSingleton GetInstance()
        //{
        //    if (_instance==null)
        //    {
        //        _instance = new ApartmentCatalogSingleton();
        //    }
        //    return _instance;
        //}
        public static AddressCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AddressCatalogSingleton();
                }
                return _instance;
            }
        }

        public Address Address { get; set; }
      

        private AddressCatalogSingleton()
        {
          
        }
    }
}
