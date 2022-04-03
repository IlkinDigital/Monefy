using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
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
        private readonly IUserDataManagerService UserDataManager;

        public GeneralViewModel(IUserDataManagerService userDataManager)
        {
            UserDataManager = userDataManager;

            Categories = new()
            {
                "Applience",
                "Food",
                "Transportaition"
            };
        }

        private List<string> _categories;
        public List<string> Categories
        {
            get => _categories;
            set => Set(ref _categories, value);
        }

        public float Balance { get; set; } = 0.0f;

        private RelayCommand? _openIncomeDialogCommand;
        public RelayCommand OpenIncomeDialogCommand
        {
            get => _openIncomeDialogCommand ??= new RelayCommand(async () =>
            {
                await DialogHost.Show(new AddIncomeMenu(), "RootDialog");
            });
        }

        private RelayCommand? _openExpenseDialogCommand;
        public RelayCommand OpenExpenseDialogCommand
        {
            get => _openExpenseDialogCommand ??= new RelayCommand(async () =>
            {
                await DialogHost.Show(new AddExpenseMenu(), "RootDialog");
            });
        }
    }
}
