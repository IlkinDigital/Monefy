using Monefy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Services.ExpensesStats
{
    public interface IExpensesStatsService
    {
        PurchaseCategory<int>[] CalculatePercentageFromTotal(PurchaseCategory<float>[] purchaseExpenses);
    }
}
