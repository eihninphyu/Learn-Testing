using Banking.Models;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Banking.Tests{
    public class RepoTest{
        [Fact]
        public void File_Repo_Save_Test(){
            var fileMock=new Mock<IFile>();
            fileMock.Setup(f => f.WriteAllText(It.IsAny<string>(),It.IsAny<string>()));
            var account=new Account(1,3000);  
            var repo=new Repository(".",fileMock.Object);
            repo.Save(account);
            fileMock.VerifyAll();      
        }
        [Fact]
        public void Repo_Get_Account_Test(){
            var fileMock=new Mock<IFile>();
            var accMock=new Mock<IAccount>();
            var accFactoryMock=new Mock<IAccountFactory>();
            fileMock.Setup(f => f.Exists(It.IsAny<string>()));
            var repo=new Repository(".",fileMock.Object);
            var account=repo.GetAccount(1,accFactoryMock.Object);
            fileMock.VerifyAll();      
        }      
              
    }
}