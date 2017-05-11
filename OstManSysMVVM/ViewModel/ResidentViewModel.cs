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
using OstManSysMVVM.Persistency;

namespace OstManSysMVVM.ViewModel
{
    class ResidentViewModel:INotifyPropertyChanged
    {
        private Resident _newResident;
        private Resident _selectedResident;
        private Resident _currentResident;
        private Account _account;
        private Account acc;

        public ResidentCatalogSingleton ResidentCatalogSingleton { get; set; }

        public Account Account
        {
            get { return _account; }
            set
            {
                _account = value;
                OnPropertyChanged(nameof(Account));
            }
        }

        public Resident Resident { get; set; }

        //public void IdentifyResident()
        //{
        //    _currentResident = LogInHandler.ReturnResident();
        //}
        public Resident CurrentResident
        {
            get { return _currentResident; }
            set
            {
                _currentResident = value;
                OnPropertyChanged(nameof(CurrentResident));
            }
        }

        public Resident NewResident
        {
            get { return _newResident; }
            set
            {
                _newResident = value;
                OnPropertyChanged(nameof(NewResident));
            }
        }

        public Resident SelectedResident
        {
            get { return _selectedResident; }
            set
            {
                _selectedResident = value;
                OnPropertyChanged(nameof(SelectedResident));
            }
        }
        

        public AccountCatalogSingleton AccountCatalogSingleton { get; set; }
        public Handler.ResidentHandler ResidentHandler { get; set; }
        public LogInHandler LogInHandler { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand LogInCommand { get; set; }
        public ResidentViewModel()
        {
            ResidentHandler=new Handler.ResidentHandler(this);
            ResidentCatalogSingleton = ResidentCatalogSingleton.Instance;
            LogInHandler = new LogInHandler(this);
            NewResident = new Resident();
            SelectedResident=new Resident();
            AccountCatalogSingleton = AccountCatalogSingleton.Instance;
            Account = new Account();
            _currentResident = LogInHandler._resident;
            //CurrentResident = new PersistencyFacade().GetResident(acc);
           
            //CurrentResident = new Resident() {ApartmentID = 2,EmailAddress = "sadasd@asdasd.com",FirstName = "Michael",LastName = "Bech", IsBoardMember = true,PhoneNumber =02546878,ResidentID = 1};
            CreateCommand = new RelayCommand(ResidentHandler.CreateResident);
            DeleteCommand = new RelayCommand(ResidentHandler.DeleteResident);
            UpdateCommand=new RelayCommand(ResidentHandler.UpdateResident);
            LogInCommand=new RelayCommand(LogInHandler.CheckAccount);
        }

        //public void Save()
        //{
        //    acc = Account;
        //}
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
