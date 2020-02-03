using System.Collections.Generic;

namespace Banking.Models{
    public class AccountFactory:IAccountFactory{
        public IAccount CreateAccount(AccountDTO accountDTO){
            return new Account(accountDTO.Id,accountDTO.Transactions);
        }
        public IAccount CreateAccount(int Id,decimal balance){
            return new Account(Id,balance);
        }
    }
}