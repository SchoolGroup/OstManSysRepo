using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OstManSysMVVM.Annotations;
using OstManSysMVVM.Common;
using OstManSysMVVM.Handler;
using OstManSysMVVM.Model;
using OstManSysMVVM.View;

namespace OstManSysMVVM.ViewModel
{
    class ProblemViewModel:INotifyPropertyChanged
    {
        private Problem _selectedProblem;
        private Problem _newProblem;
        private string _problemNote;
        public string ProblemNote
        {
            get { return _problemNote; }
            set
            {
                _problemNote = value;
                OnPropertyChanged(nameof(ProblemNote));
            }
        }
        public Problem NewProblem
        {
            get { return _newProblem; }
            set
            {
                _newProblem = value;
                OnPropertyChanged(nameof(NewProblem));
            }
        }
        public Problem SelectedProblem
        {
            get { return _selectedProblem; }
            set
            {
                _selectedProblem = value;
                OnPropertyChanged(nameof(SelectedProblem));
            }
        }
        public ProblemCatalogSingleton ProblemCatalogSingleton { get; set; }
        public ProblemHistoryCatalogSingleton ProblemHistoryCatalogSingleton { get; set; }
        public ICommand CreateProblemCommand { get; set; }
        public ICommand SolveTheProblemCommand { get; set; }
        public Handler.ProblemHandler ProblemHandler { get; set; }

        public ProblemViewModel()
        {
            ProblemCatalogSingleton = ProblemCatalogSingleton.Instance;
            ProblemHistoryCatalogSingleton = ProblemHistoryCatalogSingleton.Instance;
            ProblemHandler = new Handler.ProblemHandler(this);
            NewProblem = new Problem();
            SelectedProblem = ProblemCatalogSingleton.SelectedProblem;
            CreateProblemCommand = new RelayCommand(ProblemHandler.ReportAProblem);
            SolveTheProblemCommand = new RelayCommand(ProblemHandler.DeleteProblem);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
