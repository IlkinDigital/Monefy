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
        private readonly IUserDataService UserDataService;

        public AddIncomeMenu(IUserDataService userDataService)
        {
            UserDataService = userDataService;
        }

        public float Amount { get; set; }
        public string? Note { get; set; }
    }
}
