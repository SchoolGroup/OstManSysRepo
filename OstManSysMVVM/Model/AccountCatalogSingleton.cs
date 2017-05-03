using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstManSysMVVM.Persistency;

namespace OstManSysMVVM.Model
{
    class AccountCatalogSingleton
    {
        private static AccountCatalogSingleton _instance = new AccountCatalogSingleton();

        public static AccountCatalogSingleton Instance
        {
            get { return _instance; }
        }

        public ObservableCollection<Account> Accounts { get; set; }
        private AccountCatalogSingleton()
        {
            Accounts = new ObservableCollection<Account>(new PersistencyFacade().GetAccounts());
        }
    }
}
