using System.Collections.Generic;

namespace Banking.Models{
    public class AccountDTO{
        public int Id{get;set;}
        public decimal Balance{get; }
        public List<Transaction> Transactions{get;set;}
    }
}