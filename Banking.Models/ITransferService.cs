namespace Banking.Models{
    public interface ITransferService
    {
        void Transfer(IAccount senderAccount,IAccount receiverAccount,decimal amount);
    }
}