using Banking.Models;
namespace Banking.CUI{
    public class ViewFactory:IViewFactory{
        public IRepository Repository{get;set;}
        public IShell ConsoleShell{get;set;}
        public IAccountFactory AccountFactory{get;set;}
        public ITransferService TransferService{get;set;}
        public ViewFactory(IRepository repository,IShell shell,IAccountFactory factory){
                this.Repository=repository;
                this.ConsoleShell=shell;
                this.AccountFactory=factory;
        }
        public ViewFactory(IRepository repository,IShell shell,IAccountFactory factory,ITransferService transfer){
                this.Repository=repository;
                this.ConsoleShell=shell;
                this.AccountFactory=factory;
                this.TransferService=transfer;
        }
        public View CreateView(int type){
            View view=new InvalidView("Invalid",ConsoleShell);          
            switch (type)
                {
                    case 0:
                            view=new OptionsView("Options!!",ConsoleShell);break;                                               
                    case 1:
                            view=new CreateAccountView("Create Account",ConsoleShell,Repository,AccountFactory);break;
                    case 2:
                            view=new TransferView("Transfer",ConsoleShell,Repository,AccountFactory,TransferService);break;
                    case 3:
                            view=new DepositView("Deposit",ConsoleShell,Repository,AccountFactory);break;
                    case 4:
                            view=new WithdrawalView("WithDrawal",ConsoleShell,Repository,AccountFactory);break;
                    default:
                         view=new InvalidView("Invalid",ConsoleShell);break;
                }
                return view;
        }       
    }
}