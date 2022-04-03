using Monefy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Services
{
    public class ExpensesStatsService : IExpensesStatsService
    {
        public PurchaseRecord<int>[] CalculatePercentageFromTotal(PurchaseRecord<float>[] purchaseExpenses)
        {
            float total = 0.0f;
            foreach (var item in purchaseExpenses)
            {
                total += item.Value;
            }

            PurchaseRecord<int>[] result = new PurchaseRecord<int>[purchaseExpenses.Length];
            for (int i = 0; i < purchaseExpenses.Length; i++)
            {
                result[i].Category = purchaseExpenses[i].Category;
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
