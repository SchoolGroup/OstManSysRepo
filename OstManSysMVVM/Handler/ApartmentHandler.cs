using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using OstManSysMVVM.Model;
using OstManSysMVVM.Persistency;
using OstManSysMVVM.View;
using OstManSysMVVM.ViewModel;

namespace OstManSysMVVM.Handler
{
    /// <summary>
    /// Controls the functionality regarding apartments
    /// </summary>
    class ApartmentHandler
    {
        public ApartmentViewModel ApartmentViewModel { get; set; }
        public ApartmentHandler(ApartmentViewModel apartmentViewModel)
        {
            ApartmentViewModel = apartmentViewModel;
        }

        public void RefreshApartments()
        {
            var apartments = new PersistencyFacade().GetApartments();
            ApartmentCatalogSingleton.Instance.Apartments.Clear();
            foreach (var apartmentAddress in apartments)
            {
                ApartmentCatalogSingleton.Instance.Apartments.Add(apartmentAddress);
            }
        }
        /// <summary>
        /// Creates an apartment with the values entered by the user and saving it into the database through PersistencyFacade
        /// </summary>
        public void CreateApartment()
        {
            if (ApartmentViewModel.NewApartment.AddressID==0 || ApartmentViewModel.NewApartment.Size==0 || ApartmentViewModel.NewApartment.Condition == null || ApartmentViewModel.NewApartment.MonthlyRent==0.00 || ApartmentViewModel.NewApartment.NumberOfRooms==0)
            {
                new MessageDialog("You must fill out all forms!").ShowAsync();
            }
            else
            {
                var apartment = new Apartment();
                apartment.AddressID = ApartmentViewModel.NewApartment.AddressID;
                apartment.Size = ApartmentViewModel.NewApartment.Size;
                apartment.Condition = ApartmentViewModel.NewApartment.Condition;
                apartment.MonthlyRent = ApartmentViewModel.NewApartment.MonthlyRent;
                apartment.NumberOfRooms = ApartmentViewModel.NewApartment.NumberOfRooms;
                apartment.DownpipeID = 2;
                apartment.IsRented = true;
                apartment.WindowID = 1;
                apartment.LastCheck = ApartmentViewModel.NewApartment.LastCheck;
                new PersistencyFacade().SaveApartment(apartment);
                var apartments = new PersistencyFacade().GetApartmentAddresses();
                ApartmentViewModel.ApartmentAddressCatalogSingleton.ApartmentAddresses.Clear();
                foreach (var apartment1 in apartments)
                {
                    ApartmentViewModel.ApartmentAddressCatalogSingleton.ApartmentAddresses.Add(apartment1);
                }
                ApartmentViewModel.NewApartment.ApartmentID = 0;
                ApartmentViewModel.NewApartment.AddressID = 0;
                ApartmentViewModel.NewApartment.Size = 0;
                ApartmentViewModel.NewApartment.Condition = "";
                ApartmentViewModel.NewApartment.MonthlyRent = 0;
                ApartmentViewModel.NewApartment.NumberOfRooms = 0;
            }
           

        }
        /// <summary>
        /// Gets the the apartment that the user has selected and sends it to the PersistnecyFacade where it will be deleted
        /// and than gets all the apartments left in the database and add them again to the cleared apartmentaddresses list
        /// </summary>
        public void DeleteApartment()
        {
            if (ApartmentViewModel.SelectedApartment==null)
            {
                new MessageDialog("You haven`t selected an apartment").ShowAsync();
            }
            else
            {
                new PersistencyFacade().DeleteApartment(ApartmentViewModel.SelectedApartment);
                var apartments = new PersistencyFacade().GetApartmentAddresses();
                ApartmentViewModel.ApartmentAddressCatalogSingleton.ApartmentAddresses.Clear();
                foreach (var apartment1 in apartments)
                {
                    ApartmentViewModel.ApartmentAddressCatalogSingleton.ApartmentAddresses.Add(apartment1);
                }
            }
            
        }

        public void GoToUpdatePage()
        {

            if (ApartmentViewModel.SelectedApartment == null)
            {
                new MessageDialog("You haven`t selected an apartment").ShowAsync();
                
            }
            else
            {
                var newFrame = new Frame();
                newFrame.Navigate(typeof(UpdateApartment));
                Window.Current.Content = newFrame;
                Window.Current.Activate();
            }
           
       }
        /// <summary>
        /// Creates a new apartment where the values the user has entered in order to update the apartment
        /// than send it to the PersistencyFacade.And gets all the apartments in the database
        ///  and add them again to the cleared apartmentaddresses list
        /// </summary>
        public void UpdateApartment()
        {
            int _address = 0;
            int _size = 0;
            string _condition = "";
            double _rent = 0;
            int _numberOfRooms = 0;

           
                _address = ApartmentViewModel.NewApartment.AddressID;
          
                _size = ApartmentViewModel.NewApartment.Size;
         
                _condition = ApartmentViewModel.NewApartment.Condition;
           
                _rent = ApartmentViewModel.NewApartment.MonthlyRent;
         
                _numberOfRooms = ApartmentViewModel.NewApartment.NumberOfRooms;
          

            var updatedApartment = new Apartment();
            updatedApartment.ApartmentID = ApartmentViewModel.SelectedApartment.ApartmentID;
            updatedApartment.AddressID = _address;
            updatedApartment.Condition = _condition;
            updatedApartment.MonthlyRent = _rent;
            updatedApartment.NumberOfRooms = _numberOfRooms;
            updatedApartment.Size = _size;
            updatedApartment.DownpipeID = 2;
            updatedApartment.WindowID = 1;


            new PersistencyFacade().UpdateApartment(updatedApartment);
            var apartments = new PersistencyFacade().GetApartmentAddresses();
            ApartmentViewModel.ApartmentAddressCatalogSingleton.ApartmentAddresses.Clear();
            foreach (var apartment1 in apartments)
            {
                ApartmentViewModel.ApartmentAddressCatalogSingleton.ApartmentAddresses.Add(apartment1);
            }
            
        }
    }
}
