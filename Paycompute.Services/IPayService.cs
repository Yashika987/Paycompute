using Paycompute.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace Paycompute.Services
{
    public interface IPayService
    {
        Task CreateAsync(PaymentRecord paymentRecord);
        PaymentRecord GetById(int id);
        IEnumerable<PaymentRecord> GetAll();
        TaxYear GetTaxYearById(int id);
        IEnumerable<SelectListItem> GetAllTaxYear();
        decimal OverTimeHours(decimal hoursWroked, decimal contactualHours);
        decimal ContractualEarning(decimal contractualHours, decimal hoursWorked, decimal hourlyRate);
        decimal OverTimeRate(decimal hourlyRate);
        decimal OverTimeEarnings(decimal overTimeRate, decimal overTimeHours);
        decimal TotalEarning(decimal overTimeEarning, decimal contractualEarning);
        decimal TotalDeduction(decimal tax, decimal PFCont, decimal studentLoanRepayment,decimal unionFee);
        decimal NetPay(decimal totalEarnings, decimal totalDeduction);

    }
}
