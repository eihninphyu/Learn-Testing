using Moq;
using Banking.CUI;
using Banking.Models;
using Xunit;

namespace Banking.Tests{
    public class ViewTest{
        [Fact]
        public void Option_Test(){
            var consoleMock = new Mock<IShell>();
            consoleMock.Setup(c => c.WriteLine("1\tCreate Account"));
            consoleMock.Setup(c => c.WriteLine("2\tTransfer"));             
            consoleMock.Setup(c => c.WriteLine("3\tDeposit"));
            consoleMock.Setup(c => c.WriteLine("4\tWithDrawal"));
            consoleMock.Setup(c => c.WriteLine("5\tExit"));            
            consoleMock.Setup(c => c.WriteLine("-----------------------------------"));
            consoleMock.Setup(c => c.Write("Enter Choice : "));
            var optionsView = new OptionsView("fool", consoleMock.Object);
            optionsView.Show();
            consoleMock.VerifyAll();
        }
        [Fact]
        public void Invalid_Test(){
            var consoleMock = new Mock<IShell>();
            consoleMock.Setup(c => c.WriteLine("Invalid Choice"));
            var invalidView = new InvalidView("fool", consoleMock.Object);
            invalidView.Show();
            consoleMock.VerifyAll();
        }
        [Fact]
        public void Create_Account_Test(){
            var consoleMock = new Mock<IShell>();
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("1111")
                .Returns("2000");
            var repoMock = new Mock<IRepository>();
            var factoryMock=new Mock<IAccountFactory>();  
            var accMock=new Mock<IAccount>();                 

            factoryMock.Setup(f => f.CreateAccount(1111,2000)).Returns(accMock.Object);
            repoMock.Setup(r => r.Save(accMock.Object));        
            var createAccView = new CreateAccountView("fool", consoleMock.Object, repoMock.Object,factoryMock.Object);
            createAccView.Show();
            factoryMock.VerifyAll();
            repoMock.VerifyAll();
        }
        [Fact]
        public void Deposit_Test(){       

            var consoleMock = new Mock<IShell>();
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("1111")
                .Returns("2000");
            var repoMock = new Mock<IRepository>();
            var accMock=new Mock<IAccount>();
            var factoryMock=new Mock<IAccountFactory>();
            
            
            repoMock.Setup(r => r.GetAccount(1111,factoryMock.Object)).Returns(accMock.Object);            

            var depositView = new DepositView("fool", consoleMock.Object, repoMock.Object,factoryMock.Object);
            depositView.Show();

            accMock.Verify(r => r.Deposit(2000));

            repoMock.VerifyAll();
          
        }
        [Fact]
        public void Withdrwal_Test(){       

        var consoleMock = new Mock<IShell>();
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("1111")
                .Returns("2000");
            var repoMock = new Mock<IRepository>();
            var accMock=new Mock<IAccount>();
            var factoryMock=new Mock<IAccountFactory>();
            
            
            repoMock.Setup(r => r.GetAccount(1111,factoryMock.Object)).Returns(accMock.Object);            

            var withdrawalView = new WithdrawalView("fool", consoleMock.Object, repoMock.Object,factoryMock.Object);
            withdrawalView.Show();
            accMock.Verify(r => r.WithDrawal(2000));

            repoMock.VerifyAll();       
        }

        [Fact]
        public void Transfer_Test(){       

            var consoleMock = new Mock<IShell>();
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("1111")
                .Returns("2222")
                .Returns("2000");
            var repoMock = new Mock<IRepository>();
            var senderAccMock=new Mock<IAccount>();
            var receiverAccMock=new Mock<IAccount>();
            var factoryMock=new Mock<IAccountFactory>();
            var trasferMock=new Mock<ITransferService>();
            
            repoMock.Setup(r => r.GetAccount(1111,factoryMock.Object)).Returns(senderAccMock.Object); 
            repoMock.Setup(r => r.GetAccount(2222,factoryMock.Object)).Returns(receiverAccMock.Object); 
            trasferMock.Setup(t => t.Transfer(senderAccMock.Object,receiverAccMock.Object,2000));                       

            var transferView = new TransferView("fool", consoleMock.Object, repoMock.Object,factoryMock.Object,trasferMock.Object);
            transferView.Show();
            
            repoMock.VerifyAll();
            trasferMock.VerifyAll();
            
        }
         
    }
}