using Monefy.Model;
using Monefy.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.ViewModel.Components
{
    public class AddExpenseMenu
    {
        private readonly IUserDataService UserDataService;

        public AddExpenseMenu(IUserDataService userDataService)
        {
            UserDataService = userDataService;
        }

        public List<CategoryModel>? Categories { get; } = new()
        {
            new CategoryModel { IconPath = "", Name = "Food" },
            new CategoryModel { IconPath = "", Name = "Transport" },
            new CategoryModel { IconPath = "", Name = "Entertainment" }
        };

        public float Amount { get; set; } // User input

    }
}
