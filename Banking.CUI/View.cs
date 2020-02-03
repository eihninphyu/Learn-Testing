using Banking.Models;
namespace Banking.CUI{
    public abstract class View{
        public string Header{get; set;}
        public IShell Shell{get; private set;}
        public IRepository Repository{get; private set;}
        public IAccountFactory Factory{get; private set;}
        public ITransferService TransferService{get; private set;}
        public View(string header, IShell shell){
            Header = header;
            Shell = shell;
        }
        public View(string header, IShell shell, IRepository repo,IAccountFactory factory){
            Header = header;
            Shell = shell;
            Repository = repo;
            Factory=factory;
        }
         public View(string header, IShell shell, IRepository repo,IAccountFactory factory,ITransferService transferService){
            Header = header;
            Shell = shell;
            Repository = repo;
            Factory=factory;
            TransferService=transferService;
        }
    
        public virtual void Show(){
            ShowHeader();
            ShowContent();
        }

        protected abstract void ShowContent();

        public virtual void ShowHeader(){
            Shell.WriteLine("--------------------");
            Shell.WriteLine(Header);
            Shell.WriteLine("--------------------");
        }
    }
}