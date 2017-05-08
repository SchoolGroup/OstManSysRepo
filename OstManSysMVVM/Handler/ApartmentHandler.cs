using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using OstManSysMVVM.Model;
using OstManSysMVVM.Persistency;
using OstManSysMVVM.View;
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
            apartment.Address = ApartmentViewModel.NewApartment.Address;
            apartment.Size = ApartmentViewModel.NewApartment.Size;
            apartment.Condition = ApartmentViewModel.NewApartment.Condition;
            apartment.MonthlyRent = ApartmentViewModel.NewApartment.MonthlyRent;
            apartment.NumberOfRooms = ApartmentViewModel.NewApartment.NumberOfRooms;
          
            apartment.LastCheck = ApartmentViewModel.NewApartment.LastCheck;
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
        }

        public void GoToUpdatePage()
        {
            ApartmentViewModel.NewApartment.Address = ApartmentViewModel.SelectedApartment.Address;
            ApartmentViewModel.NewApartment.Condition = ApartmentViewModel.SelectedApartment.Condition;
            var newFrame = new Frame();
            newFrame.Navigate(typeof(UpdateApartment));
            Window.Current.Content = newFrame;
            Window.Current.Activate();
       }

        public void UpdateApartment()
        {
            //int _id = 0;
            string _address = "";
            int _size = 0;
            string _condition = "";
            decimal _rent = 0;
            int _numberOfRooms = 0;

            //if (ApartmentViewModel.NewApartment.ApartmentID == 0)
            //{
            //    _id = ApartmentViewModel.SelectedApartment.ApartmentID;
            //}
            //else
            //{
            //    _id = ApartmentViewModel.NewApartment.ApartmentID;
            //}

            if (ApartmentViewModel.NewApartment.Address == "")
            {
                _address = ApartmentViewModel.SelectedApartment.Address;
            }
            else
            {
                _address = ApartmentViewModel.NewApartment.Address;
            }

            if (ApartmentViewModel.NewApartment.Size == 0)
            {
                _size = ApartmentViewModel.SelectedApartment.Size;
            }
            else
            {
                _size = ApartmentViewModel.NewApartment.Size;
            }

            if (ApartmentViewModel.NewApartment.Condition == "")
            {
                _condition = ApartmentViewModel.SelectedApartment.Condition;
            }
            else
            {
                _condition = ApartmentViewModel.NewApartment.Condition;
            }

            if (ApartmentViewModel.NewApartment.MonthlyRent == 0)
            {
                _rent = ApartmentViewModel.SelectedApartment.MonthlyRent;
            }
            else
            {
                _rent = ApartmentViewModel.NewApartment.MonthlyRent;
            }

            if (ApartmentViewModel.NewApartment.NumberOfRooms == 0)
            {
                _numberOfRooms = ApartmentViewModel.SelectedApartment.NumberOfRooms;
            }
            else
            {
                _numberOfRooms = ApartmentViewModel.NewApartment.NumberOfRooms;
            }

            var updatedApartment = new Apartment();
            //updatedApartment.ApartmentID = _id;
            updatedApartment.Address = _address;
            updatedApartment.Condition = _condition;
            updatedApartment.MonthlyRent = _rent;
            updatedApartment.NumberOfRooms = _numberOfRooms;
            updatedApartment.Size = _size;


            new PersistencyFacade().UpdateApartment(updatedApartment);
            var apartments = new PersistencyFacade().GetApartments();
            ApartmentViewModel.ApartmentCatalogSingleton.Apartments.Clear();
            foreach (var apartment1 in apartments)
            {
                ApartmentViewModel.ApartmentCatalogSingleton.Apartments.Add(apartment1);
            }
            //ApartmentViewModel.NewApartment.ApartmentID = 0;
            //ApartmentViewModel.NewApartment.Address = "";
            //ApartmentViewModel.NewApartment.Size = 0;
            //ApartmentViewModel.NewApartment.Condition = "";
            //ApartmentViewModel.NewApartment.MonthlyRent = 0;
            //ApartmentViewModel.NewApartment.NumberOfRooms = 0;
        }
    }
}
