using System.Collections.Generic;
namespace Banking.Models{
    public interface IAccountFactory{
        IAccount CreateAccount(AccountDTO accountDTO);
        IAccount CreateAccount(int Id,decimal balance);
    }
}