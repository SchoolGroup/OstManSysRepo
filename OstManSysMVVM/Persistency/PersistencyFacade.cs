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
using OstManSysMVVM.View;
using OstManSysMVVM.ViewModel;

namespace OstManSysMVVM.Persistency
{
    /// <summary>
    /// Connects the client based programme to the server part(WebApi and than database)
    /// </summary>
    class PersistencyFacade
    {
        const string ServerUrl = "http://localhost:60721";
        HttpClientHandler handler;

        public PersistencyFacade()
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
        }

        public List<Address> GetAddresses()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Addresses").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var addresses = response.Content.ReadAsAsync<IEnumerable<Address>>().Result;
                        return addresses.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }
        public Apartment GetApartment(int apartmentID)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Apartments/"+apartmentID).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var apartment = response.Content.ReadAsAsync<Apartment>().Result;
                        return apartment;
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }
        /// <summary>
        /// Connects to the WebApi and gets all of the apartments with addresses from the database.
        /// </summary>
        /// <returns>A list of all the apartments with addresses</returns>
        public List<ApartmentAddress> GetApartmentAddresses()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/ApartmentAddresses").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var apartmentAddresses = response.Content.ReadAsAsync<IEnumerable<ApartmentAddress>>().Result;
                        return apartmentAddresses.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }
        /// <summary>
        /// Connects to the WebApi and gets all of the downpipes connected with the apartment with address from the database.
        /// </summary>
        /// <returns>A list of all the downpipes</returns>
        public List<DownpipeApartmentAddress> GetDownpipeApartmentAddress()
            {
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(ServerUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    try
                    {
                        var response = client.GetAsync("api/DownpipeApartmentAddresses").Result;

                        if (response.IsSuccessStatusCode)
                        {
                            var downpipeApartmentAddresses =
                                response.Content.ReadAsAsync<IEnumerable<DownpipeApartmentAddress>>().Result;
                            return downpipeApartmentAddresses.ToList();
                        }

                    }
                    catch (Exception ex)
                    {
                        new MessageDialog(ex.Message).ShowAsync();
                    }
                    return null;
                }
            }
        /// <summary>
        /// Connects to the WebApi and gets all of the past residents from the database.
        /// </summary>
        /// <returns>A list of all the past residents</returns>
        public List<ResidentHistory> GetResidentHistories()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/ResidentHistories").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var residentHistories =
                            response.Content.ReadAsAsync<IEnumerable<ResidentHistory>>().Result;
                        return residentHistories.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }
        /// <summary>
        /// Connects to the WebApi and gets all of the resolved problems from the database.
        /// </summary>
        /// <returns>A list of the resolved problems</returns>
        public List<ProblemHistory> GetProblemHistories()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/ProblemHistories").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var problemHistories =
                            response.Content.ReadAsAsync<IEnumerable<ProblemHistory>>().Result;
                        return problemHistories.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }
        /// <summary>
        /// Connects to the WebApi and gets all of the apartments from the database.
        /// </summary>
        /// <returns>Returns all of the apartments</returns>
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
        /// <summary>
        /// Connects to the WebApi and gets all of the problems from the database.
        /// </summary>
        /// <returns>A list of all the problems</returns>
        public List<Problem> GetProblems()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Problems").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var problems = response.Content.ReadAsAsync<IEnumerable<Problem>>().Result;
                        return problems.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }
        /// <summary>
        /// Connects to the WebApi and gets all of the downpipes from the database.
        /// </summary>
        /// <returns>A list of all the downpipes</returns>
        public List<Downpipe> GetDownpipes()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Downpipes").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var downpipes = response.Content.ReadAsAsync<IEnumerable<Downpipe>>().Result;
                        return downpipes.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }
        /// <summary>
        /// Connects to the WebApi and gets all of the accounts from the database.
        /// </summary>
        /// <returns>A list of all the accounts</returns>
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
        /// <summary>
        /// Connects to the WebApi and gets all of the contracts from the database.
        /// </summary>
        /// <returns>A list of the contracts</returns>
        public List<Contract> GetContracts()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Contracts").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var contracts = response.Content.ReadAsAsync<IEnumerable<Contract>>().Result;
                        return contracts.ToList();
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }
        /// <summary>
        /// Connects to the WebApi and gets a resident based on the account`s ResidentID from the database.
        /// </summary>
        /// <param name="resident"></param>
        /// <returns>A single resident who is logged in</returns>
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
        /// <summary>
        /// Connects to the WebApi and gets all of the residents from the database.
        /// </summary>
        /// <returns>A list of all the residents</returns>
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
        /// <summary>
        /// Gets the apartment send from ApartmentHandler and saves it in the database in apartment table
        /// </summary>
        /// <param name="apartment"></param>
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
                    var apartmentsList = client.PostAsync("api/Apartments", content).Result;
                    if (apartmentsList.IsSuccessStatusCode)
                    {
                        new MessageDialog("Successfully created an apartment!").ShowAsync();
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
        /// <summary>
        /// Gets the resident send from ResidentHandler and saves it in the database in resident table
        /// </summary>
        /// <param name="resident"></param>
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
                    if (residentsList.IsSuccessStatusCode)
                    {
                        new MessageDialog("Successfully created a resident!").ShowAsync();
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
        /// <summary>
        /// Gets the problem send from ProblemHandler and saves it in the database problem table
        /// </summary>
        /// <param name="problem"></param>
        public void SaveProblem(Problem problem)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var problem1 = JsonConvert.SerializeObject(problem);
                    var content = new StringContent(problem1, Encoding.UTF8, "Application/json");
                    var problemsList = client.PostAsync("api/Problems", content).Result;
                    if (problemsList.IsSuccessStatusCode)
                    {
                        new MessageDialog("Successfully created a problem!").ShowAsync();
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
        /// <summary>
        /// Gets the problem send from ProblemHandler and saves it in the database in problemHistory table
        /// </summary>
        /// <param name="problemHistory"></param>
        public void MoveProblemToHistory(ProblemHistory problemHistory)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var problemHistory1 = JsonConvert.SerializeObject(problemHistory);
                    var content = new StringContent(problemHistory1, Encoding.UTF8, "Application/json");
                    var problemHistoryList = client.PostAsync("api/ProblemHistories" , content).Result;
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
        /// <summary>
        /// Gets the residnet send from ResidentHandler and saves it in the database in residentHistory table
        /// </summary>
        /// <param name="resident"></param>
        public void MoveResidentToHistory(ResidentHistory resident)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var resident1 = JsonConvert.SerializeObject(resident);
                    var content = new StringContent(resident1, Encoding.UTF8, "Application/json");
                    var residentsList = client.PostAsync("api/ResidentHistories", content).Result;
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
        /// <summary>
        /// Gets the apartment send from ApartmentHandler and deletes it from the database
        /// </summary>
        /// <param name="apartment"></param>
        public void DeleteApartment(ApartmentAddress apartment)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var apartmentsList = client.DeleteAsync("api/Apartments/" + apartment.ApartmentID).Result;
                    if (apartmentsList.IsSuccessStatusCode)
                    {
                        new MessageDialog("Successfully deleted the apartment").ShowAsync();
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
        /// <summary>
        /// Gets the resident send from ResidentHandler and deletes it from the database
        /// </summary>
        /// <param name="resident"></param>
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
                    if (residentsList.IsSuccessStatusCode)
                    {
                        new MessageDialog("Successfully deleted and moved to the history!").ShowAsync();
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
        /// <summary>
        /// Gets the problem send from ProblemHandler and deletes it from the database
        /// </summary>
        /// <param name="problem"></param>
        public void DeleteProblem(Problem problem)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var problemsList = client.DeleteAsync("api/Problems/" + problem.ProblemID).Result;
                    if (problemsList.IsSuccessStatusCode)
                    {
                        new MessageDialog("Successfully deleted and moved to the history!").ShowAsync();
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
        /// <summary>
        /// Gets the contract send from ResidentHandler and saves it in the database in contract table
        /// </summary>
        /// <param name="contract"></param>
        public void SaveContract(Contract contract)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var contract1 = JsonConvert.SerializeObject(contract);
                    var content = new StringContent(contract1, Encoding.UTF8, "Application/json");
                    var contractsList = client.PostAsync("api/Contracts", content).Result;
                    if (contractsList.IsSuccessStatusCode)
                    {
                        new MessageDialog("Succesfylly attached a resident!").ShowAsync();
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
        /// <summary>
        /// Gets the apartment send from ApartmentHandler and updates the values of the apartment by replicing it
        /// </summary>
        /// <param name="apartment"></param>
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
        /// <summary>
        /// Gets the resident send from ResidentHandler and updates the values of the resident by replicing it
        /// </summary>
        /// <param name="resident"></param>
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
