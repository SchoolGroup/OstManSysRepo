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
            resident.FirstName = ResidentViewModel.NewResident.FirstName;
            resident.LastName = ResidentViewModel.NewResident.LastName;
            resident.EmailAddress = ResidentViewModel.NewResident.EmailAddress;
            resident.PhoneNumber = ResidentViewModel.NewResident.PhoneNumber;
            resident.Type = ResidentViewModel.NewResident.Type;
            resident.DateOfBirth = ResidentViewModel.NewResident.DateOfBirth;
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

        public void DeleteResident()
        {
            new PersistencyFacade().DeleteResident(ResidentViewModel.SelectedResident);
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

        public void UpdateResident()
        {
            Resident resident = new Resident();
            resident.FirstName = ResidentViewModel.NewResident.FirstName;
            resident.LastName = ResidentViewModel.NewResident.LastName;
            resident.EmailAddress = ResidentViewModel.NewResident.EmailAddress;
            resident.PhoneNumber = ResidentViewModel.NewResident.PhoneNumber;
            resident.Type = ResidentViewModel.NewResident.Type;
            resident.DateOfBirth = ResidentViewModel.NewResident.DateOfBirth;
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
