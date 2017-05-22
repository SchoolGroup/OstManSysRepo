using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstManSysMVVM.Persistency;

namespace OstManSysMVVM.Model
{
    public class ProblemCatalogSingleton
    {
        private static ProblemCatalogSingleton _instance = null;

        public static ProblemCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProblemCatalogSingleton();
                }
                return _instance;
            }
        }
        public Problem SelectedProblem { get; set; }
        public ObservableCollection<Problem> Problems { get; set; }
        private ProblemCatalogSingleton()
        {
            Problems = new ObservableCollection<Problem>(new PersistencyFacade().GetProblems());
        }
    }
}
