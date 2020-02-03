
using Banking.CUI;
using Banking.Models;
using Moq;
using Xunit;

namespace Banking.Tests{
    public class ViewFactoryTest{
        [Fact]
        public void Options_View_Test(){
            var consoleMock = new Mock<IShell>();
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("0")
            ;
            var repoMock = new Mock<IRepository>(); 
            var factoryMock=new Mock<IAccountFactory>();
            var viewFactory= new ViewFactory(repoMock.Object,consoleMock.Object,factoryMock.Object);    
            var view =viewFactory.CreateView(0);
            Assert.Equal(typeof(OptionsView),view.GetType());
        }

        [Fact]
        public void Create_View_Test(){
            var consoleMock = new Mock<IShell>();
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("1")
            ;
            var repoMock = new Mock<IRepository>(); 
            var factoryMock=new Mock<IAccountFactory>();
            var viewFactory= new ViewFactory(repoMock.Object,consoleMock.Object,factoryMock.Object);    
            var view =viewFactory.CreateView(1);
            Assert.Equal(typeof(CreateAccountView),view.GetType());
        }
        [Fact]
        public void Transfer_View_Test(){
            var consoleMock = new Mock<IShell>();
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("2")
            ;
            var repoMock = new Mock<IRepository>(); 
            var factoryMock=new Mock<IAccountFactory>();
            var TransferMock=new Mock<ITransferService>();
            var viewFactory= new ViewFactory(repoMock.Object,consoleMock.Object,factoryMock.Object,TransferMock.Object);    
            var view =viewFactory.CreateView(2);
            Assert.Equal(typeof(TransferView),view.GetType());
        }
        [Fact]
        public void DEposit_View_Test(){
            var consoleMock = new Mock<IShell>();
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("3")
            ;
            var repoMock = new Mock<IRepository>(); 
            var factoryMock=new Mock<IAccountFactory>();
            var viewFactory= new ViewFactory(repoMock.Object,consoleMock.Object,factoryMock.Object);    
            var view =viewFactory.CreateView(3);
            Assert.Equal(typeof(DepositView),view.GetType());
        }
        [Fact]
        public void Withdraw_View_Test(){
            var consoleMock = new Mock<IShell>();
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("4")
            ;
            var repoMock = new Mock<IRepository>(); 
            var factoryMock=new Mock<IAccountFactory>();
            var viewFactory= new ViewFactory(repoMock.Object,consoleMock.Object,factoryMock.Object);    
            var view =viewFactory.CreateView(4);
            Assert.Equal(typeof(WithdrawalView),view.GetType());
        }
        [Fact]
        public void Invalid_View_Test(){
            var consoleMock = new Mock<IShell>();
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("6")
            ;
            var repoMock = new Mock<IRepository>(); 
            var factoryMock=new Mock<IAccountFactory>();
            var viewFactory= new ViewFactory(repoMock.Object,consoleMock.Object,factoryMock.Object);    
            var view =viewFactory.CreateView(6);
            Assert.Equal(typeof(InvalidView),view.GetType());
        }

    }
}