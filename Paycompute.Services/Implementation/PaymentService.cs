using Paycompute.Entity;
using Paycompute.Persistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace Paycompute.Services.Implementation
{
    public class PaymentService : IPayService
    {

        private readonly ApplicationDbContext _context;
        private decimal contractualEarnins;
        private decimal overTimeHours;

        public PaymentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public decimal ContractualEarning(decimal contractualHours, decimal hoursWorked, decimal hourlyRate)
        {
            if (hoursWorked < contractualHours)
            {
                contractualEarnins = hoursWorked * hourlyRate;
            }
            else
            {
                contractualEarnins = contractualHours * hourlyRate;
            }
            return contractualEarnins;
        }

        public async Task CreateAsync(PaymentRecord paymentRecord)
        {
            await _context.PaymentRecords.AddAsync(paymentRecord);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<PaymentRecord> GetAll() => _context.PaymentRecords.OrderBy(p => p.EmployeeId);


        public IEnumerable<SelectListItem> GetAllTaxYear()
        {
            var allTaxYear = _context.TaxYears.Select(taxYears => new SelectListItem
            {
                Text = taxYears.YearOfTax,
                Value = taxYears.Id.ToString()
            });
            return allTaxYear;

        }

        public PaymentRecord GetById(int id) => _context.PaymentRecords.Where(pay => pay.Id == id).FirstOrDefault();

        public decimal NetPay(decimal totalEarnings, decimal totalDeduction) => totalEarnings - totalDeduction;

        public decimal OverTimeEarnings(decimal overTimeRate, decimal overTimeHours) => overTimeHours * overTimeRate;


        public decimal OverTimeHours(decimal hoursWroked, decimal contactualHours)
        {
            if (hoursWroked <= contactualHours)
            {
                overTimeHours = 0.00m;
            }
            else if (hoursWroked > contactualHours)
            {
                overTimeHours = hoursWroked - contactualHours;
            }
            return overTimeHours;
        }

        public decimal OverTimeRate(decimal hourlyRate) => hourlyRate * 1.5m;


        public decimal TotalDeduction(decimal tax, decimal PFCont, decimal studentLoanRepayment, decimal unionFee)
        => tax + PFCont + studentLoanRepayment + unionFee;

        public decimal TotalEarning(decimal overTimeEarning, decimal contractualEarning)
        => overTimeEarning + contractualEarning;
        public TaxYear GetTaxYearById(int id) => _context.TaxYears.Where(year => year.Id == id).FirstOrDefault();
    }
    
    }
