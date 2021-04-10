using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class BankPaymentService : IEntity
    {
        public int BankId { get; set; }
        public string BankName { get; set; }
        public int RentalID { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string CreditCardNumber { get; set; }
        public int TransactionAmount { get; set; }
    }
}
