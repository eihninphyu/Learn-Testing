using System.Collections.Generic;

namespace Banking.Models
{
    public interface IAccount{
        int Id{get;set;}
        decimal Balance{get; }
        List<Transaction> Transactions{get;set;}
        void Deposit(decimal Amount);
        void WithDrawal(decimal Amount);
    }    
}