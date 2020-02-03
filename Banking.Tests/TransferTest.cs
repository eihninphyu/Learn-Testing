using System;
using Banking.Models;
using Moq;
using Xunit;
namespace Banking.Tests
{
    public class TransferTest{
       [Fact]
        public void Amount_is_Tansfered_to_Receiver_When_the_Transfer_Made(){           
            
            var senderAccount=new Account(1,3000);
            
            var receiverAccount=new Account(1,3000);

            var transferService=new TransferService();
            transferService.Transfer(senderAccount,receiverAccount,1000);
            Assert.Equal(2000,senderAccount.Balance);
            Assert.Equal(4000,receiverAccount.Balance);           
        }
        [Fact]
        public void Exception_Occured_In_Withdrawal_When_Transfer_Made(){
            Mock<IAccount> accRepo=new Mock<IAccount>();  
            accRepo.Setup(e=>e.WithDrawal(It.IsAny<decimal>())).Throws(new Exception()); 
            var receiverAccount=new Account(1,3000);
            var transferService=new TransferService();

            Assert.ThrowsAny<Exception>(()=> transferService.Transfer(accRepo.Object,receiverAccount,1000));      

        }
        [Fact]
        public void Exception_Occured_In_Deposit_When_Transfer_Made(){
            Mock<IAccount> accRepo=new Mock<IAccount>();           
            accRepo.Setup(e=>e.Deposit(It.IsAny<decimal>())).Throws(new Exception()); 
            
            var senderAccount=new Account(1,3000);

            var transferService=new TransferService();
            Assert.ThrowsAny<Exception>(()=> transferService.Transfer(senderAccount,accRepo.Object,1000));  
        }
        [Fact]
        public void Exception_Occured_In_Deposit_And_WithDrawal_When_Transfer_Made(){
            Mock<IAccount> senderRepo=new Mock<IAccount>();

            Mock<IAccount> receiverRepo=new Mock<IAccount>();

            senderRepo.Setup(e=>e.WithDrawal(It.IsAny<decimal>())).Throws(new Exception());       
            receiverRepo.Setup(e=>e.Deposit(It.IsAny<decimal>())).Throws(new Exception()); 

            var transferService=new TransferService();
            Assert.ThrowsAny<Exception>(()=> transferService.Transfer(senderRepo.Object,receiverRepo.Object,10));  
        }

        [Fact]
        public void Not_Enough_Exception_Test(){
            var exc= new NotEnoughBalanceException(1000);
            Assert.Equal(1000,exc.CurrentBalance);    
        }        

    }
}