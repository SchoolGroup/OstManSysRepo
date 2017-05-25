using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OstManSysMVVM.Annotations;
using OstManSysMVVM.Common;
using OstManSysMVVM.Handler;
using OstManSysMVVM.Model;

namespace OstManSysMVVM.ViewModel
{
    class LogInViewModel:INotifyPropertyChanged
    {
        private Account _account;
        private Account acc;
        public Account Account
        {
            get { return _account; }
            set
            {
                _account = value;
                OnPropertyChanged(nameof(Account));
            }
        }
        public LogInHandler LogInHandler { get; set; }
        public ICommand LogInCommand { get; set; }
        public AccountCatalogSingleton AccountCatalogSingleton { get; set; }

        public LogInViewModel()
        {
            LogInHandler = new LogInHandler(this);
            AccountCatalogSingleton = AccountCatalogSingleton.Instance;
            Account = new Account();
            LogInCommand = new RelayCommand(LogInHandler.CheckAccount);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
