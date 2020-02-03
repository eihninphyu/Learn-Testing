using Banking.Models;
namespace Banking.CUI{
    public class App{
        public IShell Shell;
        public IViewFactory ViewFactory;
        public App(IViewFactory viewFactory,IShell shell){
            Shell=shell;
            ViewFactory=viewFactory;
        }
        public App(IShell shell){
            Shell=shell;
        }
        public int GetChoice(){           
            var cmd=int.Parse(Shell.ReadLine());
            return cmd;            
        } 
        public void Run(){            
            int choice=0;   
            do
            {                
                ViewFactory.CreateView(0).Show();                               
                choice = GetChoice(); 
                if(choice==5)return; 
                ViewFactory.CreateView(choice).Show();                 
            } while (choice!=5);    
        }        
    }
}