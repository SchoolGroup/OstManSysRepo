using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstManSysMVVM.Model;
using OstManSysMVVM.Persistency;

namespace OstManSysMVVM.View
{
    public class ProblemHistoryCatalogSingleton
    {
        private static ProblemHistoryCatalogSingleton _instance = null;

        //public ApartmentCatalogSingleton GetInstance()
        //{
        //    if (_instance==null)
        //    {
        //        _instance = new ApartmentCatalogSingleton();
        //    }
        //    return _instance;
        //}
        public static ProblemHistoryCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProblemHistoryCatalogSingleton();
                }
                return _instance;
            }
        }

        public ObservableCollection<ProblemHistory> ProblemHistories { get; set; }
        private ProblemHistoryCatalogSingleton()
        {
            ProblemHistories = new ObservableCollection<ProblemHistory>(new PersistencyFacade().GetProblemHistories());
        }
    }
}
