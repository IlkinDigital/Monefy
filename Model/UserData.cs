using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Model
{
    public class UserData
    {
        public float Balance { get; set; }
        public PurchaseCategory<float>[]? PurchaseHistory { get; set; }
    }
}
