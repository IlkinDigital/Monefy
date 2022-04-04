using GalaSoft.MvvmLight.Command;
using Monefy.Model;
using Monefy.Services;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monefy.Messages;
using GalaSoft.MvvmLight.Messaging;

namespace Monefy.ViewModel.Components
{
    public class AddExpenseMenu
    {
        private readonly IMessenger Messenger;
        private readonly IUserDataService UserDataService;

        public AddExpenseMenu(IMessenger messenger, IUserDataService userDataService)
        {
            Messenger = messenger;
            UserDataService = userDataService;

            Categories = new(UserDataService.Data.Categories);
        }

        public List<CategoryModel>? Categories { get; init; }
        public CategoryModel? SelectedCategory { get; set; }

        public float Amount { get; set; }

        private RelayCommand? _addExpenseCommand;
        public RelayCommand AddExpenseCommand
        {
            get => _addExpenseCommand ??= new RelayCommand(() =>
            {
                UserDataService.YieldBalance(-1 * Amount);
                UserDataService.RecordPurchase(new() { Category = SelectedCategory, Value = Amount });
                DialogHost.Close("RootDialog");

                Messenger.Send<UpdateUserDataMessage>(new());
            });
        }
    }
}
