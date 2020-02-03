using System;
using Banking.Models;
namespace Banking.CUI
{
    public class ProgramApp
    {
        static void Main(string[] args)
        {    
            Console.WriteLine("\nWelcome from Banking CUI !");
            var repo=new Repository(".",new MyFile());
            var shell=new ConsoleShell();
            var accFactory=new AccountFactory();
            var app=new App(new ViewFactory(repo,shell,accFactory),shell);  
            app.Run();
        }       
        
    }
}
