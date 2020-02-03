using Banking.Models;
namespace Banking.CUI{
    public interface IViewFactory{
        IRepository Repository{get;set;}
        IShell ConsoleShell{get;set;}
        IAccountFactory AccountFactory{get;set;}
        View CreateView(int type);        
    }
}