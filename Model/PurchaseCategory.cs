using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Model
{
    public class PurchaseCategory<Ty>
    { 
        public string Name { get; set; }
        public Ty Value { get; set; }
    }
}
