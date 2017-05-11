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

namespace OstManSysMVVM.ViewModel
{
    class ApartmentViewModel:INotifyPropertyChanged
    {
        private Apartment _newApartment;
        private Apartment _selectedApartment;
        private Problem _selectedProblem;
        
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

        public string CurrentTime = DateTime.Now.ToString("h:mm:ss tt");
        public ApartmentCatalogSingleton ApartmentCatalogSingleton { get; set; }
        public DownpipeCatalogSingleton DownpipeCatalogSingleton { get; set; }
        public ProblemCatalogSingleton ProblemCatalogSingleton { get; set; }
        public Handler.ApartmentHandler ApartmentHandler { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand GoToUpdateCommand { get; set; }
        public ApartmentViewModel()
        {
            ApartmentCatalogSingleton = ApartmentCatalogSingleton.Instance;
            DownpipeCatalogSingleton = DownpipeCatalogSingleton.Instance;
            ProblemCatalogSingleton = ProblemCatalogSingleton.Instance;
            ApartmentHandler = new Handler.ApartmentHandler(this);
            NewApartment =new Apartment();
            //SelectedApartment=new Apartment();
            CreateCommand=new RelayCommand(ApartmentHandler.CreateApartment);
            DeleteCommand=new RelayCommand(ApartmentHandler.DeleteApartment);
            UpdateCommand=new RelayCommand(ApartmentHandler.UpdateApartment);
            GoToUpdateCommand = new RelayCommand(ApartmentHandler.GoToUpdatePage);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
