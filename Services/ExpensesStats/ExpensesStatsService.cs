using Monefy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Services.ExpensesStats
{
    public class ExpensesStatsService : IExpensesStatsService
    {
        public PurchaseCategory<int>[] CalculatePercentageFromTotal(PurchaseCategory<float>[] purchaseExpenses)
        {
            float total = 0.0f;
            foreach (var item in purchaseExpenses)
            {
                total += item.Value;
            }

            PurchaseCategory<int>[] result = new PurchaseCategory<int>[purchaseExpenses.Length];
            for (int i = 0; i < purchaseExpenses.Length; i++)
            {
                result[i].Name = purchaseExpenses[i].Name;
                result[i].Value = (int)Math.Ceiling(Percentage(purchaseExpenses[i].Value, total));
            }

            return result;
        }

        private float Percentage(float num, float total)
        {
            return num * 100.0f / total;
        }
    }
}
