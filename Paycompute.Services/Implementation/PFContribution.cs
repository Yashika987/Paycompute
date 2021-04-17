using System;
using System.Collections.Generic;
using System.Text;

namespace Paycompute.Services.Implementation
{
    public class PFContribution : IPFContribution
    {
        private decimal basicPay;
        private decimal PFRate;
        private decimal PFCont;

        decimal IPFContribution.PFContribution(decimal totalAmount)
        {
            PFRate = .12m;
            basicPay = totalAmount * .45m;
            PFCont = basicPay * PFRate;
            return PFCont;
        }
    }
}
