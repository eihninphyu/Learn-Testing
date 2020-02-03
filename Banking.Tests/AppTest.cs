using Banking.CUI;
using Banking.Models;
using Moq;
using Xunit;

namespace Banking.Tests{
    public class AppTests{
        [Fact]
        public void Get_Choice_Test(){
            var consoleMock = new Mock<IShell>();
            consoleMock.Setup(c => c.ReadLine()).Returns("1");
            var app=new App(consoleMock.Object);         
            var choice = app.GetChoice();
            Assert.Equal(1,choice);
        }
        
        [Fact]
        public void App_Exit_Test(){
            var consoleMock = new Mock<IShell>();  
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns("5")
            ;
            var viewMock=new Mock<View>("test",consoleMock.Object);
            var viewFactoryMock=new Mock<IViewFactory>();
            viewFactoryMock.Setup(a => a.CreateView(0)).Returns(viewMock.Object);
            var app=new App(viewFactoryMock.Object,consoleMock.Object);
            app.Run();
            viewFactoryMock.Verify(v => v.CreateView(0));
            viewMock.Verify(v => v.Show());
            viewFactoryMock.VerifyNoOtherCalls();
        } 


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(6)]
        public void App_Test(int value){
            var consoleMock = new Mock<IShell>();  
            consoleMock.SetupSequence(c => c.ReadLine())
                .Returns(value.ToString()).Returns("5")
            ;
            var optionViewMock=new Mock<View>("test",consoleMock.Object);
            var viewMock=new Mock<View>("test",consoleMock.Object);
            var viewFactoryMock=new Mock<IViewFactory>();

            viewFactoryMock.Setup(a => a.CreateView(0)).Returns(optionViewMock.Object);
            viewFactoryMock.Setup(a => a.CreateView(value)).Returns(viewMock.Object);

            var app=new App(viewFactoryMock.Object,consoleMock.Object);
            app.Run();

            viewFactoryMock.Verify(v => v.CreateView(0));
            viewFactoryMock.Verify(v => v.CreateView(value));
        }
    }
}