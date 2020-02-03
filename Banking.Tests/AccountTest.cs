using System;
using System.Collections.Generic;
using Banking.Models;
using Moq;
using Xunit;

namespace Banking.Tests
{
    public class AccountTest{       
        
        [Fact]
        public void Balance_Is_Updated_When_Deposite_Is_Made(){            
            var account=new Account(1,3000);
            account.Deposit(1000);
            Assert.Equal(4000,account.Balance); 
        }
        [Fact]        
        public void Balance_Is_Updated_When_WithDrawal_Is_Made(){            
            var newAccount=new Account(1,3000);
            newAccount.WithDrawal(1000);
            Assert.Equal(2000,newAccount.Balance);
        }
        [Fact]
        public void Account_Factory_Create_Account_For_Existing_Transaction_Test()
        {
            var accFactory = new AccountFactory();
            var list=new List<Transaction>();
            var transaction =new Transaction(){
                Amount=3000,
                Date=DateTime.Now
            };
            list.Add(transaction);
            var accDto=new AccountDTO(){Id=1,Transactions=list};
            var acc = accFactory.CreateAccount(accDto);
            Assert.Equal(3000, acc.Balance);
        }
        [Fact]
        public void Account_Factory_Create_Account_Test()
        {
            var accFactory = new AccountFactory();            
            var acc = accFactory.CreateAccount(1,3000);
            Assert.Equal(3000, acc.Balance);
        }
        // [Fact]
        // public void Exception_Must_Be_Throw_When_Deposit_Is_Made_And_Save_Fails(){
        //     var newAccount=new Account(1,3000);
        //     Assert.ThrowsAny<Exception>(()=> newAccount.Deposit(1000));
        // }
        // [Fact]
        // public void Exception_Must_Be_Throw_When_WithDrawal_Is_Made_And_Save_Fails(){        
        //     var newAccount=new Account(1,3000);
        //     Assert.ThrowsAny<Exception>(()=> newAccount.WithDrawal(1000));
        // }

        
    }
}