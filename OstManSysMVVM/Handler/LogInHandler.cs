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
    class LogInHandler
    {
        public ResidentViewModel ResidentViewModel { get; set; }
        public LogInHandler(ResidentViewModel residentViewModel)
        {
            ResidentViewModel = residentViewModel;
        }

        public Resident _resident;


        //public Resident ReturnResident()
        //{
        //    return _resident;
        //}
        public void CheckAccount()
        {
            var data = from account in ResidentViewModel.AccountCatalogSingleton.Accounts
                select account.ResidentID;
            var data1 = from account1 in ResidentViewModel.AccountCatalogSingleton.Accounts
                select account1.Password;

            int s = 0;
            foreach (var i in data)
            {
                
                if (i.Equals(ResidentViewModel.Account.ResidentID))
                {
                    if (data1.ElementAt(s).Equals(ResidentViewModel.Account.Password))
                    {
                        _resident = new PersistencyFacade().GetResident(ResidentViewModel.Account);
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
                else
                {
                    
                }
                s++;
            }
            
        }
    }
}
