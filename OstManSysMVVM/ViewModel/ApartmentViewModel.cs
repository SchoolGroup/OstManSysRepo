using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ApartmentAddress _selectedApartment;
        //private Problem _selectedProblem;
        //private Problem _newProblem;
        //private string _problemNote;
        private ObservableCollection<int> _residentId;
        private DownpipeApartmentAddress _downpipeApartmentAddress;
        
        //public string ProblemNote
        //{
        //    get { return _problemNote; }
        //    set
        //    {
        //        _problemNote = value;
        //        OnPropertyChanged(nameof(ProblemNote));
        //    }
        //}

        //public Problem NewProblem
        //{
        //    get { return _newProblem; }
        //    set
        //    {
        //        _newProblem = value;
        //        OnPropertyChanged(nameof(NewProblem));
        //    }
        //}

        //public Apartment ApartmentID { get; set; }
        public Apartment NewApartment
        {
            get { return _newApartment; }
            set
            {
                _newApartment = value;
                OnPropertyChanged(nameof(NewApartment));
            }
        }

        public ApartmentAddress SelectedApartment
        {
            get
            {
                if (ApartmentAddressCatalogSingleton.SelectedApartmentAddress!=null)
                {
                    _selectedApartment = ApartmentAddressCatalogSingleton.SelectedApartmentAddress;
                }
                return _selectedApartment;
            }
            set
            {
                _selectedApartment = value;
                OnPropertyChanged(nameof(SelectedApartment));
            }
        }

        public DownpipeApartmentAddress DownpipeApartmentAddress
        {
            get
            {
                var apartmentID = SelectedApartment.ApartmentID;
                var downpipeApartment = DownpipeApartmentAddressCatalogSingleton.DownpipeApartmentAddresses;
                foreach (var downpipeApartmentAddress in downpipeApartment)
                {
                    if (downpipeApartmentAddress.ApartmentID==apartmentID)
                    {
                        _downpipeApartmentAddress = downpipeApartmentAddress;
                        return _downpipeApartmentAddress;
                    }
                }
                return null;
            }
            set { _downpipeApartmentAddress = value; }
        }

        public ObservableCollection<int> ResidentID
        {
            get
            {
                var apartmentID = SelectedApartment.ApartmentID;
                // var residentID = ResidentCatalogSingleton.Instance.SelectedResident.ResidentID;
                var contracts = ContractCatalogSingleton.Instance.Contracts;
                foreach (var contract in contracts)
                {
                    if (contract.ApartmentID == apartmentID)
                    {
                        _residentId.Add(contract.ResidentID);
                        //return _residentId;
                    }
                    
                }
                return _residentId;
            }
            set { _residentId = value; }
        }

        //public Problem SelectedProblem
        //{
        //    get { return _selectedProblem; }
        //    set
        //    {
        //        _selectedProblem = value;
        //        OnPropertyChanged(nameof(SelectedApartment));
        //    }
        //}

        public ContractCatalogSingleton ContractCatalogSingleton { get; set; }
        public ApartmentCatalogSingleton ApartmentCatalogSingleton { get; set; }
        public ApartmentAddressCatalogSingleton ApartmentAddressCatalogSingleton { get; set; }
        public DownpipeApartmentAddressCatalogSingleton DownpipeApartmentAddressCatalogSingleton { get; set; }
        public DownpipeCatalogSingleton DownpipeCatalogSingleton { get; set; }
        public AddressCatalogSingleton AddressCatalogSingleton { get; set; }
        //public ProblemCatalogSingleton ProblemCatalogSingleton { get; set; }
        public Handler.ApartmentHandler ApartmentHandler { get; set; }
        //public ProblemHistoryCatalogSingleton ProblemHistoryCatalogSingleton { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand GoToUpdateCommand { get; set; }
        //public ICommand CreateProblemCommand { get; set; }
        //public ICommand SolveTheProblemCommand { get; set; }
        //  public int GetResidentID()
        //{
        //    var apartmentID = SelectedApartment.ApartmentID;
        //    var residentID = ResidentCatalogSingleton.Instance.SelectedResident.ResidentID;
        //    var contracts = ContractCatalogSingleton.Instance.Contracts;
        //    foreach (var contract in contracts)
        //    {
        //        if (contract.ApartmentID==apartmentID&&contract.ResidentID==residentID)
        //        {
        //            return contract.ResidentID;
        //        }
        //        return 0;
        //    }
        //    return 0;
        //}

        public ApartmentViewModel()
        {
            ContractCatalogSingleton=ContractCatalogSingleton.Instance;
            DownpipeApartmentAddressCatalogSingleton = DownpipeApartmentAddressCatalogSingleton.Instance;
            ApartmentAddressCatalogSingleton = ApartmentAddressCatalogSingleton.Instance;
            ApartmentCatalogSingleton = ApartmentCatalogSingleton.Instance;
            DownpipeCatalogSingleton = DownpipeCatalogSingleton.Instance;
            AddressCatalogSingleton=AddressCatalogSingleton.Instance;
            //ProblemCatalogSingleton = ProblemCatalogSingleton.Instance;
            //ProblemHistoryCatalogSingleton = ProblemHistoryCatalogSingleton.Instance;
            ApartmentHandler = new Handler.ApartmentHandler(this);
            NewApartment =new Apartment();
            ResidentID= new ObservableCollection<int>();
            //NewProblem = new Problem();
            //ResidentID = GetResidentID();
           // ResidentID = ContractCatalogSingleton.ResidentID;
            //SelectedProblem = ProblemCatalogSingleton.SelectedProblem;
            SelectedApartment = ApartmentAddressCatalogSingleton.SelectedApartmentAddress;
            CreateCommand=new RelayCommand(ApartmentHandler.CreateApartment);
            DeleteCommand=new RelayCommand(ApartmentHandler.DeleteApartment);
            UpdateCommand=new RelayCommand(ApartmentHandler.UpdateApartment);
            GoToUpdateCommand = new RelayCommand(ApartmentHandler.GoToUpdatePage);
            //CreateProblemCommand = new RelayCommand(ApartmentHandler.ReportAProblem);
            //SolveTheProblemCommand = new RelayCommand(ApartmentHandler.DeleteProblem);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
