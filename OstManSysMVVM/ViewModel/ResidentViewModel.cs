﻿using System;
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
        private Problem _selectedProblem;
       
        public ResidentCatalogSingleton ResidentCatalogSingleton { get; set; }
        public ResidentHistoryCatalogSingleton ResidentHistoryCatalogSingleton { get; set; }
        public DownpipeCatalogSingleton DownpipeCatalogSingleton { get; set; }
      
        public Problem SelectedProblem
        {
            get { return _selectedProblem; }
            set
            {
                _selectedProblem = value;
                OnPropertyChanged(nameof(SelectedProblem));
            }
        }

        public Resident Resident { get; set; }

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
        

        public Handler.ResidentHandler ResidentHandler { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand AttachCommand { get; set; }
        public ICommand ResidentRefreshCommand { get; set; }
        public ResidentViewModel()
        {
            ResidentHandler=new Handler.ResidentHandler(this);
            ResidentCatalogSingleton = ResidentCatalogSingleton.Instance;
            ResidentHistoryCatalogSingleton = ResidentHistoryCatalogSingleton.Instance;
            DownpipeCatalogSingleton=DownpipeCatalogSingleton.Instance;
     
            NewResident = new Resident();
            SelectedResident= ResidentCatalogSingleton.SelectedResident;
            CurrentResident = ResidentCatalogSingleton.CurrentResident;
            CreateCommand = new RelayCommand(ResidentHandler.CreateResident);
            DeleteCommand = new RelayCommand(ResidentHandler.DeleteResident);
            UpdateCommand=new RelayCommand(ResidentHandler.UpdateResident);
            ResidentRefreshCommand = new RelayCommand(ResidentHandler.Refresh);
           AttachCommand=new RelayCommand(ResidentHandler.AttachResident);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
