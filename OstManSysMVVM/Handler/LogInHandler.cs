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
    /// <summary>
    /// Controls the functionality regarding loging in
    /// </summary>
    class LogInHandler
    {
        public LogInViewModel LogInViewModel { get; set; }
        public ResidentCatalogSingleton ResidentCatalogSingleton { get; set; }
        public LogInHandler(LogInViewModel logInViewModel)
        {
            LogInViewModel = logInViewModel;
            ResidentCatalogSingleton = ResidentCatalogSingleton.Instance;
        }

        public Resident _resident;
        /// <summary>
        /// Gets the ResidentIDs and Passwords from the database and checks if they match with the values entered by the user.
        /// If they match - checks wether the user is a Resident or a BoardMember and redirect him to the respective page
        /// </summary>
        public void CheckAccount()
        {
            var data = from account in LogInViewModel.AccountCatalogSingleton.Accounts
                select account.ResidentID;
            var data1 = from account1 in LogInViewModel.AccountCatalogSingleton.Accounts
                select account1.Password;

            int s = 0;
            foreach (var i in data)
            {
                
                if (i.Equals(LogInViewModel.Account.ResidentID))
                {
                    if (data1.ElementAt(s).Equals(LogInViewModel.Account.Password))
                    {
                        _resident = new PersistencyFacade().GetResident(LogInViewModel.Account);
                        ResidentCatalogSingleton.CurrentResident = _resident;
                        //ResidentViewModel.Save();
                        if (_resident.Type == "Resident")
                        {
                            var newFrame = new Frame();
                            newFrame.Navigate(typeof(ResidentView));
                            Window.Current.Content = newFrame;
                            Window.Current.Activate();
                        }
                        else if (_resident.Type == "BoardMember")
                        {
                            var newFrame = new Frame();
                            newFrame.Navigate(typeof(BoardMemberView));
                            Window.Current.Content = newFrame;
                            Window.Current.Activate();
                        }

                    }
                }
                s++;
            }
            
        }
    }
}
