using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstManSysMVVM.Persistency;

namespace OstManSysMVVM.Model
{
    public class DownpipeCatalogSingleton
    {
        private static DownpipeCatalogSingleton _instance = null;

        public static DownpipeCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DownpipeCatalogSingleton();
                }
                return _instance;
            }
        }

        public ObservableCollection<Downpipe> Downpipes { get; set; }
        private DownpipeCatalogSingleton()
        {
            Downpipes = new ObservableCollection<Downpipe>(new PersistencyFacade().GetDownpipes());
        }
    }
}
