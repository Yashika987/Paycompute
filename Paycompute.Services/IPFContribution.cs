using System;
using System.Collections.Generic;
using System.Text;

namespace Paycompute.Services
{
    public interface IPFContribution
    {
        decimal PFContribution(decimal totalAmount);
    }
}
