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
    class LogInHandler
    {
        public ResidentViewModel ResidentViewModel { get; set; }
        public LogInHandler(ResidentViewModel residentViewModel)
        {
            ResidentViewModel = residentViewModel;
        }

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
                       ResidentViewModel.CurrentResident = new PersistencyFacade().GetResident(ResidentViewModel.Account);


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
