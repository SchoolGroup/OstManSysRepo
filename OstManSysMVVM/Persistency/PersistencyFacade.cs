using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Newtonsoft.Json;
using OstManSysMVVM.Model;

namespace OstManSysMVVM.Persistency
{
    class PersistencyFacade
    {
        const string ServerUrl = "http://localhost:60721";
        HttpClientHandler handler;

        public PersistencyFacade()
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
        }

        public List<Apartment> GetApartments()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Apartments").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var apartments = response.Content.ReadAsAsync<IEnumerable<Apartment>>().Result;
                        return apartments.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }

        public List<Account> GetAccounts()
        {
            using (var client= new HttpClient(handler))
            {
                client.BaseAddress=new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Accounts").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var accounts = response.Content.ReadAsAsync<IEnumerable<Account>>().Result;
                        return accounts.ToList();
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }

        public Resident GetResident(Account resident)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress=new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Residents/" + resident.ResidentID).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var resident1 = response.Content.ReadAsAsync<Resident>().Result;
                        return resident1;
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }
        public List<Resident> GetResidents()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress=new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Residents").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var residents = response.Content.ReadAsAsync<IEnumerable<Resident>>().Result;
                        return residents.ToList();
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }
        public void SaveApartment(Apartment apartment)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var apartment1 = JsonConvert.SerializeObject(apartment);
                    var content = new StringContent(apartment1, Encoding.UTF8, "Application/json");
                    var apartmentsList = client.PostAsync("api/apartments", content).Result;
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public void SaveResident(Resident resident)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress=new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var resident1 = JsonConvert.SerializeObject(resident);
                    var content = new StringContent(resident1,Encoding.UTF8,"Application/json");
                    var residentsList = client.PostAsync("api/Residents", content).Result;
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
        public void DeleteApartment(Apartment apartment)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var apartmentsList = client.DeleteAsync("api/Apartments/" + apartment.ApartmentID).Result;
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public void DeleteResident(Resident resident)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress=new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var residentsList = client.DeleteAsync("api/Residents/" + resident.ResidentID).Result;
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
        public void UpdateApartment(Apartment apartment)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var stringApartment = JsonConvert.SerializeObject(apartment);
                    var content = new StringContent(stringApartment, Encoding.UTF8, "Application/json");
                    var apartmentsList = client.PutAsync("api/Apartments/" + apartment.ApartmentID, content).Result;
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public void UpdateResident(Resident resident)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress=new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var stringResident = JsonConvert.SerializeObject(resident);
                    var content= new StringContent(stringResident,Encoding.UTF8,"Application/json");
                    var residentsList = client.PutAsync("api/Residents/" + resident.ResidentID, content).Result;
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
    }
}
