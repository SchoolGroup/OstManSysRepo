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
    class ApartmentViewModel:INotifyPropertyChanged
    {
        private Apartment _newApartment;
        private Apartment _selectedApartment;
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

        public Apartment NewApartment
        {
            get { return _newApartment; }
            set
            {
                _newApartment = value;
                OnPropertyChanged(nameof(NewApartment));
            }
        }

        public Apartment SelectedApartment
        {
            get { return _selectedApartment; }
            set
            {
                _selectedApartment = value;
                OnPropertyChanged(nameof(SelectedApartment));
            }
        }

        public Problem SelectedProblem
        {
            get { return _selectedProblem; }
            set
            {
                _selectedProblem = value;
                OnPropertyChanged(nameof(SelectedApartment));
            }
        }

        public ApartmentCatalogSingleton ApartmentCatalogSingleton { get; set; }
        public ApartmentAddressCatalogSingleton ApartmentAddressCatalogSingleton { get; set; }
        public DownpipeApartmentAddressCatalogSingleton DownpipeApartmentAddressCatalogSingleton { get; set; }
        public DownpipeCatalogSingleton DownpipeCatalogSingleton { get; set; }
        public ProblemCatalogSingleton ProblemCatalogSingleton { get; set; }
        public Handler.ApartmentHandler ApartmentHandler { get; set; }
        public ProblemHistoryCatalogSingleton ProblemHistoryCatalogSingleton { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand GoToUpdateCommand { get; set; }
        public ICommand CreateProblemCommand { get; set; }
        public ICommand SolveTheProblemCommand { get; set; }

        public ApartmentViewModel()
        {
            DownpipeApartmentAddressCatalogSingleton = DownpipeApartmentAddressCatalogSingleton.Instance;
            ApartmentAddressCatalogSingleton = ApartmentAddressCatalogSingleton.Instance;
            ApartmentCatalogSingleton = ApartmentCatalogSingleton.Instance;
            DownpipeCatalogSingleton = DownpipeCatalogSingleton.Instance;
            ProblemCatalogSingleton = ProblemCatalogSingleton.Instance;
            ProblemHistoryCatalogSingleton = ProblemHistoryCatalogSingleton.Instance;
            ApartmentHandler = new Handler.ApartmentHandler(this);
            NewApartment =new Apartment();
            NewProblem = new Problem();
            SelectedProblem = ProblemCatalogSingleton.SelectedProblem;
            //SelectedApartment=new Apartment();
            CreateCommand=new RelayCommand(ApartmentHandler.CreateApartment);
            DeleteCommand=new RelayCommand(ApartmentHandler.DeleteApartment);
            UpdateCommand=new RelayCommand(ApartmentHandler.UpdateApartment);
            GoToUpdateCommand = new RelayCommand(ApartmentHandler.GoToUpdatePage);
            CreateProblemCommand = new RelayCommand(ApartmentHandler.ReportAProblem);
            SolveTheProblemCommand = new RelayCommand(ApartmentHandler.DeleteProblem);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
