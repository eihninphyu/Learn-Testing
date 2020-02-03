namespace Banking.Models
{
    public interface IRepository{   
        void Save(IAccount account);   
        IAccount GetAccount(int AccountId,IAccountFactory factory);
        
    }
}