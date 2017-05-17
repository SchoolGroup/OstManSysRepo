using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstManSysMVVM.Model;
using OstManSysMVVM.Persistency;
using OstManSysMVVM.ViewModel;

namespace OstManSysMVVM.Handler
{
    class ResidentHandler
    {
        public ResidentViewModel ResidentViewModel { get; set; }

        public ResidentHandler(ResidentViewModel residentViewModel)
        {
            ResidentViewModel = residentViewModel;
        }

        public void CreateResident()
        {
            var resident = new Resident();
            resident.ResidentID = ResidentViewModel.NewResident.ResidentID;
            resident.FirstName = ResidentViewModel.NewResident.FirstName;
            resident.LastName = ResidentViewModel.NewResident.LastName;
            resident.EmailAddress = ResidentViewModel.NewResident.EmailAddress;
            resident.PhoneNumber = ResidentViewModel.NewResident.PhoneNumber;
            resident.DateOfBirth = ResidentViewModel.NewResident.DateOfBirth;
            resident.Type = ResidentViewModel.NewResident.Type;
           // resident.ApartmentID = ResidentViewModel.NewResident.ApartmentID;
            //resident.IsBoardMember = ResidentViewModel.NewResident.IsBoardMember;
            new PersistencyFacade().SaveResident(resident);
            var residents = new PersistencyFacade().GetResidents();
            ResidentViewModel.ResidentCatalogSingleton.Residents.Clear();
            foreach (var resident1 in residents)
            {
                ResidentViewModel.ResidentCatalogSingleton.Residents.Add(resident1);
            }

            ResidentViewModel.NewResident.ResidentID = 0;
            ResidentViewModel.NewResident.FirstName = "";
            ResidentViewModel.NewResident.LastName = "";
            ResidentViewModel.NewResident.EmailAddress="";
            ResidentViewModel.NewResident.PhoneNumber=0;
           // ResidentViewModel.NewResident.ApartmentID=0;
            //ResidentViewModel.NewResident.IsBoardMember=false;
        }

        public void MoveResidentToHistory()
        {
            new PersistencyFacade().SaveResident(ResidentViewModel.SelectedResident);
            var residents = new PersistencyFacade().GetResidentHistories();
        }

        

        public ResidentHistory HistoryConvert()
        {
            Resident res = ResidentViewModel.SelectedResident;
            ResidentHistory newResident = new ResidentHistory()
            {
                DateOfBirth = res.DateOfBirth,
                EmailAddress = res.EmailAddress,
                FirstName = res.FirstName,
                LastName = res.LastName,
                PhoneNumber = (int) res.PhoneNumber,
                Type = res.Type,
                ApartmentID = 2,
                MoveInDate = DateTime.Today,
                MoveOutDate = DateTime.Today,
                ResidentID = res.ResidentID
            };
            return newResident;
        }

        public void DeleteResident()
        {
            ResidentHistory resident = HistoryConvert();
            new PersistencyFacade().MoveResidentToHistory(resident);
            new PersistencyFacade().DeleteResident(ResidentViewModel.SelectedResident);
            var residents = new PersistencyFacade().GetResidents();
            var historyResident = new PersistencyFacade().GetResidentHistories();
            ResidentViewModel.ResidentHistoryCatalogSingleton.ResidentHistories.Clear();
            ResidentViewModel.ResidentCatalogSingleton.Residents.Clear();
            foreach (var resident1 in residents)
            {
                ResidentViewModel.ResidentCatalogSingleton.Residents.Add(resident1);
            }
            foreach (var resident2 in historyResident)
            {
                ResidentViewModel.ResidentHistoryCatalogSingleton.ResidentHistories.Add(resident2);
            }
            
            ResidentViewModel.NewResident.ResidentID = 0;
            ResidentViewModel.NewResident.FirstName = "";
            ResidentViewModel.NewResident.LastName = "";
            ResidentViewModel.NewResident.EmailAddress = "";
            ResidentViewModel.NewResident.PhoneNumber = 0;
            // ResidentViewModel.NewResident.ApartmentID = 0;
            //ResidentViewModel.NewResident.IsBoardMember = false;
        }

        public void UpdateResident()
        {
            Resident resident = new Resident();
            resident.ResidentID = ResidentViewModel.NewResident.ResidentID;
            resident.FirstName = ResidentViewModel.NewResident.FirstName;
            resident.LastName = ResidentViewModel.NewResident.LastName;
            resident.EmailAddress = ResidentViewModel.NewResident.EmailAddress;
            resident.PhoneNumber = ResidentViewModel.NewResident.PhoneNumber;
          //  resident.ApartmentID = ResidentViewModel.NewResident.ApartmentID;
           // resident.IsBoardMember = ResidentViewModel.NewResident.IsBoardMember;
            new PersistencyFacade().UpdateResident(resident);
            var residents = new PersistencyFacade().GetResidents();
            ResidentViewModel.ResidentCatalogSingleton.Residents.Clear();
            foreach (var resident1 in residents)
            {
                ResidentViewModel.ResidentCatalogSingleton.Residents.Add(resident1);
            }

            ResidentViewModel.NewResident.ResidentID = 0;
            ResidentViewModel.NewResident.FirstName = "";
            ResidentViewModel.NewResident.LastName = "";
            ResidentViewModel.NewResident.EmailAddress = "";
            ResidentViewModel.NewResident.PhoneNumber = 0;
           // ResidentViewModel.NewResident.ApartmentID = 0;
            //ResidentViewModel.NewResident.IsBoardMember = false;
        }
    }
}
