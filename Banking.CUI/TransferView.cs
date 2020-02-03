using System;
using Banking.Models;
namespace Banking.CUI
{
    public class TransferView : View{
       
        public TransferView(string header, IShell shell, IRepository repo,IAccountFactory factory,ITransferService transfer)
        :base(header, shell,repo,factory,transfer){
            
        }
        protected override void ShowContent(){
            Shell.Write("Your Account No:\t");
            var senderId = Convert.ToInt32(Shell.ReadLine());
            Shell.Write("Receiver Account No:\t");
            var receiverId = Convert.ToInt32(Shell.ReadLine());
            Shell.Write("Amount :\t");
            var amount = Convert.ToDecimal(Shell.ReadLine());

            var sender=Repository.GetAccount(senderId,Factory);
            var receiver=Repository.GetAccount(receiverId,Factory);            
            
            TransferService.Transfer(sender,receiver,amount);
            Repository.Save(sender)  ;
            Repository.Save(receiver);
                        
            Shell.WriteLine($"Transfer amount {amount } from Account Id {senderId} to Account Id {receiver} successfully");
            Shell.WriteLine("Press Enter to continue...");
            Shell.ReadLine();
        }
    }
}