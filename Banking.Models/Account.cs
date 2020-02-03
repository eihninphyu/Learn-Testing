using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking.Models
{
    public class Account : IAccount
    {      
        public Account(int id,decimal balance){
            this.Id=id;         
            this.Transactions=new List<Transaction>();
            var transaction=new Transaction(){
                    Date=DateTime.Now,
                    Amount = balance
                };
            this.Transactions.Add(transaction);
        }
        public Account(int id,List<Transaction> t){
            this.Id=id;         
            this.Transactions=new List<Transaction>();            
            this.Transactions=t;
        }
        public int Id {get;set;}
        public decimal Balance { get{return this.Transactions.Sum(t => t.Amount);} }
        public List<Transaction> Transactions{get;set;}
        
        public void WithDrawal(decimal v)
        {
            try{
                var transaction=new Transaction(){
                    Date=DateTime.Now,
                    Amount = -v
                };
                this.Transactions.Add(transaction);      
            }catch(Exception){
                throw new NotEnoughBalanceException(this.Balance);
            }
        }
        public void Deposit(decimal v)
        {
            var transaction=new Transaction(){
                    Date=DateTime.Now,
                    Amount = v
                };
            this.Transactions.Add(transaction);   
        }        
    }    
}