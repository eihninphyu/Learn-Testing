using System;

namespace Banking.Models
{
    public class TransferService:ITransferService
    {             
        public void Transfer(IAccount senderAccount,IAccount receiverAccount,decimal amount){
            var sender=senderAccount;
                sender.WithDrawal(amount);
                var receiver=receiverAccount;
                receiver.Deposit(amount);
        }
    }
}