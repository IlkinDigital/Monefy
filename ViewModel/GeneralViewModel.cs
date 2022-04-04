using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using Monefy.Messages;
using Monefy.Model;
using Monefy.Services;
using Monefy.ViewModel.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.ViewModel
{
    public class GeneralViewModel : ViewModelBase
    {
        private readonly IMessenger Messenger;
        private readonly IUserDataService UserDataService;

        public GeneralViewModel(IMessenger messenger, IUserDataService userDataService)
        {
            Messenger = messenger;
            UserDataService = userDataService;

            Messenger.Register<UpdateUserDataMessage>(this, message =>
            {
                Balance = UserDataService.Data.Balance;
            });

            Balance = UserDataService.Data.Balance;
        }

        private float _balance;
        public float Balance
        {
            get => _balance;
            set => Set(ref _balance, value);
        }

        private RelayCommand? _openIncomeDialogCommand;
        public RelayCommand OpenIncomeDialogCommand
        {
            get => _openIncomeDialogCommand ??= new RelayCommand(async () =>
            {
                await DialogHost.Show(new AddIncomeMenu(Messenger, UserDataService), "RootDialog");
            });
        }

        private RelayCommand? _openExpenseDialogCommand;
        public RelayCommand OpenExpenseDialogCommand
        {
            get => _openExpenseDialogCommand ??= new RelayCommand(async () =>
            {
                await DialogHost.Show(new AddExpenseMenu(Messenger, UserDataService), "RootDialog");
            });
        }
    }
}
