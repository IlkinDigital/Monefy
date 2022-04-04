using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using Monefy.Messages;
using Monefy.Model;
using Monefy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.ViewModel.Components
{
    public class AddIncomeMenu
    {
        private readonly IMessenger Messenger;
        private readonly IUserDataService UserDataService;

        public AddIncomeMenu(IMessenger messenger, IUserDataService userDataService)
        {
            Messenger = messenger;
            UserDataService = userDataService;
        }

        public float Amount { get; set; }

        private RelayCommand? _addIncomeCommand;
        public RelayCommand AddIncomeCommand
        {
            get => _addIncomeCommand ??= new RelayCommand(() =>
            {
                UserDataService.YieldBalance(Amount);
                UserDataService.RecordPurchase(new() { Category = null, Value = Amount });
                DialogHost.Close("RootDialog");

                Messenger.Send<UpdateUserDataMessage>(new());
            });
        }
    }
}
