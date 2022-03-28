using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Monefy.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.ViewModel
{
    public class MonefyViewModel : ViewModelBase
    {
        private readonly IMessenger Messenger;
        private readonly INavigationService NavigationService;

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }

        private RelayCommand _generalNavCommand;
        public RelayCommand GeneralNavCommand { get => _generalNavCommand ??= new RelayCommand(() =>
        {
            NavigationService.NavigateTo<GeneralViewModel>();
        }); }

        public MonefyViewModel(IMessenger messenger, INavigationService navigationService)
        {
            Messenger = messenger;
            NavigationService = navigationService;
        }
    }
}
