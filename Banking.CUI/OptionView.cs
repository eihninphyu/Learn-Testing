using System;
using Banking.Models;
namespace Banking.CUI
{
    public class OptionsView : View{
       
        public OptionsView(string header, IShell shell)
        :base(header, shell){
            
        }
        protected override void ShowContent(){
            Shell.WriteLine("1\tCreate Account");
            Shell.WriteLine("2\tTransfer");
            Shell.WriteLine("3\tDeposit");
            Shell.WriteLine("4\tWithDrawal");
            Shell.WriteLine("5\tExit");
            Shell.WriteLine("-----------------------------------");
            Shell.Write("Enter Choice : ");
        }
    }
}