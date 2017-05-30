using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using OstManSysMVVM.Model;
using OstManSysMVVM.Persistency;
using OstManSysMVVM.View;
using OstManSysMVVM.ViewModel;

namespace OstManSysMVVM.Handler
{
    /// <summary>
    /// Controls the functionality regarding Problems
    /// </summary>
    class ProblemHandler
    {
        public ProblemViewModel ProblemViewModel { get; set; }
        public ProblemHandler(ProblemViewModel problemViewModel)
        {
            ProblemViewModel = problemViewModel;
        }
        /// <summary>
        /// Creates new problem with the values the user has entered and than sends it to PersistencyFacade.
        /// Than gets all the problems and add them into the cleared list of problems in order to have the new problem also.
        /// </summary>
        public void ReportAProblem()
        {
            if (ProblemViewModel.NewProblem.Description==null || ProblemViewModel.NewProblem.Header==null || ProblemViewModel.NewProblem.ApartmentID==0)
            {
                new MessageDialog("You must fill in the form").ShowAsync();
            }
            else
            {
                var problem = new Problem();
                problem.ApartmentID = ProblemViewModel.NewProblem.ApartmentID;
                problem.Description = ProblemViewModel.NewProblem.Description;
                problem.Header = ProblemViewModel.NewProblem.Header;
                problem.ProblemID = ProblemViewModel.NewProblem.ProblemID;

                new PersistencyFacade().SaveProblem(problem);
                var problems = new PersistencyFacade().GetProblems();
                ProblemViewModel.ProblemCatalogSingleton.Problems.Clear();
                foreach (var problem1 in problems)
                {
                    ProblemViewModel.ProblemCatalogSingleton.Problems.Add(problem1);
                }

                ProblemViewModel.NewProblem.ApartmentID = 0;
                ProblemViewModel.NewProblem.Description = "";
                ProblemViewModel.NewProblem.Header = "";
                ProblemViewModel.NewProblem.ProblemID = 0;
            }
            
        }
        /// <summary>
        /// Converts the problem to problemhistory
        /// </summary>
        /// <returns></returns>
        public ProblemHistory HistoryConvert()
        {
            Problem problem = ProblemViewModel.SelectedProblem;
            ProblemHistory problemHistory = new ProblemHistory()
            {
                ApartmentID = problem.ApartmentID,
                Description = problem.Description,
                Header = problem.Header,
                ProblemID = problem.ProblemID,
                Note = ProblemViewModel.ProblemNote
            };
            return problemHistory;

        }
        /// <summary>
        /// Gets the converted problem and send it to the PersistencyFacade.
        /// Than gets all the problems and add them into the cleared list of problems in order to remove the deleted problem from the list.
        /// </summary>
        public void DeleteProblem()
        {
            if (ProblemViewModel.SelectedProblem==null)
            {
                new MessageDialog("You haven`t selected a problem").ShowAsync();
            }
            else
            {
                ProblemHistory problem = HistoryConvert();
                new PersistencyFacade().MoveProblemToHistory(problem);
                new PersistencyFacade().DeleteProblem(ProblemViewModel.SelectedProblem);
                var problems = new PersistencyFacade().GetProblems();
                var historyProblems = new PersistencyFacade().GetProblemHistories();
                ProblemViewModel.ProblemHistoryCatalogSingleton.ProblemHistories.Clear();
                ProblemViewModel.ProblemCatalogSingleton.Problems.Clear();
                foreach (var problem1 in problems)
                {
                    ProblemViewModel.ProblemCatalogSingleton.Problems.Add(problem1);
                }
                foreach (var problem2 in historyProblems)
                {
                    ProblemViewModel.ProblemHistoryCatalogSingleton.ProblemHistories.Add(problem2);
                }

            }
        }
    }
}
