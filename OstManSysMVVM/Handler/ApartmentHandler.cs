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
    class ApartmentHandler
    {
        public ApartmentViewModel ApartmentViewModel { get; set; }
        public ApartmentHandler(ApartmentViewModel apartmentViewModel)
        {
            ApartmentViewModel = apartmentViewModel;
        }

        public void CreateApartment()
        {
            var apartment = new Apartment();
            apartment.ApartmentID = ApartmentViewModel.NewApartment.ApartmentID;
            apartment.Address = ApartmentViewModel.NewApartment.Address;
            apartment.Size = ApartmentViewModel.NewApartment.Size;
            apartment.Condition = ApartmentViewModel.NewApartment.Condition;
            apartment.MonthlyRent = ApartmentViewModel.NewApartment.MonthlyRent;
            apartment.NumberOfRooms = ApartmentViewModel.NewApartment.NumberOfRooms;
            new PersistencyFacade().SaveApartment(apartment);
            var apartments = new PersistencyFacade().GetApartments();
            ApartmentViewModel.ApartmentCatalogSingleton.Apartments.Clear();
            foreach (var apartment1 in apartments)
            {
                ApartmentViewModel.ApartmentCatalogSingleton.Apartments.Add(apartment1);
            }
            ApartmentViewModel.NewApartment.ApartmentID= 0;
            ApartmentViewModel.NewApartment.Address="";
            ApartmentViewModel.NewApartment.Size=0;
            ApartmentViewModel.NewApartment.Condition="";
            ApartmentViewModel.NewApartment.MonthlyRent=0;
            ApartmentViewModel.NewApartment.NumberOfRooms=0;

        }

        public void DeleteApartment()
        {
            new PersistencyFacade().DeleteApartment(ApartmentViewModel.SelectedApartment);
            var apartments = new PersistencyFacade().GetApartments();
            ApartmentViewModel.ApartmentCatalogSingleton.Apartments.Clear();
            foreach (var apartment1 in apartments)
            {
                ApartmentViewModel.ApartmentCatalogSingleton.Apartments.Add(apartment1);
            }
            ApartmentViewModel.NewApartment.ApartmentID = 0;
            ApartmentViewModel.NewApartment.Address = "";
            ApartmentViewModel.NewApartment.Size = 0;
            ApartmentViewModel.NewApartment.Condition = "";
            ApartmentViewModel.NewApartment.MonthlyRent = 0;
            ApartmentViewModel.NewApartment.NumberOfRooms = 0;
        }

        public void UpdateApartment()
        {
            var apartment = new Apartment();
            apartment.ApartmentID = ApartmentViewModel.NewApartment.ApartmentID;
            apartment.Address = ApartmentViewModel.NewApartment.Address;
            apartment.Size = ApartmentViewModel.NewApartment.Size;
            apartment.Condition = ApartmentViewModel.NewApartment.Condition;
            apartment.MonthlyRent = ApartmentViewModel.NewApartment.MonthlyRent;
            apartment.NumberOfRooms = ApartmentViewModel.NewApartment.NumberOfRooms;
            new PersistencyFacade().UpdateApartment(apartment);
            var apartments = new PersistencyFacade().GetApartments();
            ApartmentViewModel.ApartmentCatalogSingleton.Apartments.Clear();
            foreach (var apartment1 in apartments)
            {
                ApartmentViewModel.ApartmentCatalogSingleton.Apartments.Add(apartment1);
            }
            ApartmentViewModel.NewApartment.ApartmentID = 0;
            ApartmentViewModel.NewApartment.Address = "";
            ApartmentViewModel.NewApartment.Size = 0;
            ApartmentViewModel.NewApartment.Condition = "";
            ApartmentViewModel.NewApartment.MonthlyRent = 0;
            ApartmentViewModel.NewApartment.NumberOfRooms = 0;
        }
    }
}
