using System;
using Banking.Models;
namespace Banking.CUI
{
    public class CreateAccountView : View{
       
        public CreateAccountView(string header, IShell shell, IRepository repo,IAccountFactory factory)
        :base(header, shell,repo,factory){
            
        }
        protected override void ShowContent(){
            Shell.Write("Account No:");
            var accountId = Convert.ToInt32(Shell.ReadLine());
            Shell.Write("Balance:");
            var amount = Convert.ToInt32(Shell.ReadLine());            
            var account =Factory.CreateAccount(accountId, amount);
            Repository.Save(account);
            Shell.WriteLine($"Account {accountId} created successfully");
            Shell.WriteLine("Press Enter to continue...");
            Shell.ReadLine();
        }
    }
}