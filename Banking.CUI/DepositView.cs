using System;
using Banking.Models;
namespace Banking.CUI
{
    public class DepositView : View{
       
        public DepositView(string header, IShell shell, IRepository repo,IAccountFactory factory)
        :base(header, shell,repo,factory){
            
        }
        protected override void ShowContent(){
            Shell.Write("Account No:");
            var accountId = Convert.ToInt32(Shell.ReadLine());
            Shell.Write("Amount :");
            var amount = Convert.ToDecimal(Shell.ReadLine());
            var account=Repository.GetAccount(accountId,Factory);
            account.Deposit(amount);  
            Repository.Save(account);
            Shell.WriteLine($"Account Id {accountId} is Deposit successfully");
            Shell.WriteLine("Press Enter to continue...");
            Shell.ReadLine();
        }
    }
}