using System;
using System.Collections.Generic;
using System.Text;

namespace Paycompute.Services.Implementation
{
    public class TaxService : ITaxService
    {
        private decimal taxRate;
        private decimal tax;
        public decimal TaxAmount(decimal totalAmount)
        {
            if (totalAmount <= (20833))
            {
                //Tax Free Rate
                taxRate = .0m;
                tax = totalAmount * taxRate;
            }
            else if (totalAmount > 20833 && totalAmount <= 41666)
            {
                //Basic tax rate
                taxRate = .5m;
                //Income tax
                tax = (20833 * .0m) + ((totalAmount - 20833) * taxRate);
            }
            else if (totalAmount > 41666 && totalAmount <= 62500)
            {
                //Basic tax rate
                taxRate = .10m;
                //Income tax
                tax = (20833 * .0m) + ((41666 - 20833) * .5m) + ((totalAmount - 41666) * taxRate);
            }
            else if (totalAmount > 62500 && totalAmount <= 83333)
            {
                //Basic tax rate
                taxRate = .15m;
                //Income tax
                tax = (1042 * .0m) + ((41666 - 20833) * .5m) + ((62500 - 41666) * .10m) + ((totalAmount - 62500) * taxRate);
            }
            else if (totalAmount > 83333 && totalAmount <= 104166)
            {
                //Basic tax rate
                taxRate = .20m;
                //Income tax
                tax = (1042 * .0m) + ((41666 - 20833) * .5m) + ((62500 - 41666) * .10m) + ((83333 - 62500) * .15m) + ((totalAmount - 83333) * taxRate);
            }
            else if (totalAmount > 104166 && totalAmount <= 125000)
            {
                //Basic tax rate
                taxRate = .25m;
                //Income tax
                tax = (1042 * .0m) + ((41666 - 20833) * .5m) + ((62500 - 41666) * .10m) + ((83333 - 62500) * .15m) + 
                    ((104166 - 83333) * .20m) + ((totalAmount - 104166) * taxRate);
            }
            else if (totalAmount > 125000)
            {
                //Basic tax rate
                taxRate = .30m;
                //Income tax
                tax = (1042 * .0m) + ((41666 - 20833) * .5m) + ((62500 - 41666) * .10m) + ((83333 - 62500) * .15m) +
                    ((104166 - 83333) * .20m) + ((125000 - 104166) * .25m)+((totalAmount - 125000) * taxRate);
            }
            return tax;
        }
    }
}
