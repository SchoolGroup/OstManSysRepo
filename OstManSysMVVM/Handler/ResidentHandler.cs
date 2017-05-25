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
    /// <summary>
    /// Controls the functionality regarding residents
    /// </summary>
    class ResidentHandler
    {
        public ResidentViewModel ResidentViewModel { get; set; }

        public ResidentHandler(ResidentViewModel residentViewModel)
        {
            ResidentViewModel = residentViewModel;
        }
        /// <summary>
        /// Gets the ApartmentID and ResidentID in order to create a new contract with current date of creation.
        /// </summary>
        public void AttachResident()
        {
            var contract = new Contract();
            contract.ApartmentID = ApartmentCatalogSingleton.Instance.ApartmentID.ApartmentID;
            contract.ResidentID = ResidentCatalogSingleton.Instance.SelectedResident.ResidentID;
            contract.MoveInDate=DateTime.Now;
            new PersistencyFacade().SaveContract(contract);
        }
        /// <summary>
        /// Creates a new resident with the information the user has provided and send it to the PersistencyFacade.
        /// Than gets all the residents and adds them into the cleared list of residents in order to have the new resident also.
        /// </summary>
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
        }     
        /// <summary>
        /// Converts the resident into residenthistory
        /// </summary>
        /// <returns>ResidentHistory with the details of the resident</returns>
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
        /// <summary>
        /// Gets the converted resident and send it to the PersistencyFacade.
        /// Than gets all the residents and adds them to the cleared list of residents in order update the list.
        /// </summary>
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
        }
        /// <summary>
        /// Creates a new resident with the information provided by the user and send it to the PersistencyFacade.
        /// Than gets all the residents and adds them to the cleared list of residents in order update the list.
        /// </summary>
        public void UpdateResident()
        {
            Resident resident = new Resident();
            resident.ResidentID = ResidentViewModel.NewResident.ResidentID;
            resident.FirstName = ResidentViewModel.NewResident.FirstName;
            resident.LastName = ResidentViewModel.NewResident.LastName;
            resident.EmailAddress = ResidentViewModel.NewResident.EmailAddress;
            resident.PhoneNumber = ResidentViewModel.NewResident.PhoneNumber;
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
        }
    }
}
