using System;

namespace Banking.Models{
    public class NotEnoughBalanceException:Exception{
        public decimal CurrentBalance{get;set;}
        public NotEnoughBalanceException(decimal balance) => CurrentBalance =balance;
    }
}