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
        IEnumerable<SelectListItem> GetAllTaxYear();
        decimal OverTimeHours(decimal hoursWroked, decimal contactualHours);
        decimal ContractualEarning(decimal contractualHours, decimal hoursWorked, decimal hourlyRate);
        decimal OvertTimeEarning(decimal hourlyRate);
        decimal OverTimeEarnings(decimal overTimeRate, decimal overTimeHours);
        decimal TotalEarning(decimal overTimeEarning, decimal contractualEarning);
        decimal TotalDeduction(decimal tax, decimal nic, decimal studentLoanRepayment,decimal unionFee);
        decimal NetPay(decimal totalEarnings, decimal totalDeduction);

    }
}
