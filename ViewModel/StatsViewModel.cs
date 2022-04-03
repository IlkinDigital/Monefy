using GalaSoft.MvvmLight;
using Monefy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.ViewModel
{
    public class StatsViewModel : ViewModelBase
    {
        private readonly IUserDataService UserDataService;

        public StatsViewModel(IUserDataService userDataService)
        {
            UserDataService = userDataService;
        }
    }
}
