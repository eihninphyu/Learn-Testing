using System;
using Banking.Models;
namespace Banking.CUI
{
    public class InvalidView : View{
       
        public InvalidView(string header, IShell shell)
        :base(header, shell){
            
        }
        protected override void ShowContent(){
            Shell.WriteLine("Invalid Choice");
            Shell.WriteLine("Press Enter to continue...");
            Shell.ReadLine();
        }
    }
}