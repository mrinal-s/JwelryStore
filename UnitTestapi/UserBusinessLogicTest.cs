using jewelrystoreAPI;
using Moq;
using Xunit;

namespace UnitTestapi
{
    public class UserBusinessLogicTest
    {
        public UserBusinessLogic Service;
        Mock<IUserDataAccess> _userDataAccessMock;
        
        public  UserBusinessLogicTest()
        {
            _userDataAccessMock = new Mock<IUserDataAccess>();
            var service = new Mock<UserBusinessLogic>(_userDataAccessMock.Object)
            {
                CallBase = true
            };
            this.Service = service.Object;
           
            
        }
        [Fact]
        public void UserBusinessLogic_GetUser_IfUserIsNotNull()
        {
            //arrange
            _userDataAccessMock.Setup(m => m.GetUserData(It.IsAny<User>()))
                .Returns(new User() { UserId=1,UserName="xyz",IsPriviledgedUser=true});

            //act
            var result = this.Service.GetUser(new User() { UserName = "xyz", Password = "abc" });

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.User);
            Assert.Equal("xyz", result.User.UserName);
            Assert.Equal(2, result.Discount);
            Assert.True(result.User.IsPriviledgedUser);
        }

        [Fact]
        public void UserBusinessLogic_GetUser_IfUserIsNull()
        {
            User response = null;
            //arrange
            _userDataAccessMock.Setup(m => m.GetUserData(It.IsAny<User>()))
                .Returns(response);

            //act
            var result = this.Service.GetUser(new User() { UserName = "xyz", Password = "abc" });

            //assert
            Assert.Null(result);            
        }

        [Fact]
        public void UserBusinessLogic_PrintUser_IfIsFilePrintTrue()
        {
           
            //act
            var result = this.Service.PrintUser(new JwelleryCost() { GoldPrice=2,GoldWeight=1,IsFilePrint=true,TotalPrice=1.78 });

            //assert                       
            Assert.True(result);
        }

        [Fact]
        public void UserBusinessLogic_PrintUser_IfIsFilePrintFalse()
        {
            //act
            var result = this.Service.PrintUser(new JwelleryCost() { GoldPrice = 2, GoldWeight = 1, IsFilePrint = false, TotalPrice = 1.78 });

            //assert           
            Assert.True(result);
        }
    }
}
