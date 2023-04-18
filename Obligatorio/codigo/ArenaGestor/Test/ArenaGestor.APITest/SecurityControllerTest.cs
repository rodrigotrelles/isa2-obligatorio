using ArenaGestor.API.Controllers;
using ArenaGestor.APIContracts.Security;
using ArenaGestor.BusinessInterface;
using ArenaGestor.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace ArenaGestor.APITest
{
    [TestClass]
    public class SecurityControllerTest
    {
        private Mock<ISecurityService> mock;
        private Mock<IUsersService> usersServiceMock;
        private Mock<IMapper> mockMapper;
        private User userOK;
        private SecurityRegisterUserDto insertUserDto;
        private SecurityController api;

        private SecurityLoginDto loginDto;
        private string randomToken;

        [TestInitialize]
        public void InitTest()
        {
            mock = new Mock<ISecurityService>(MockBehavior.Strict);
            usersServiceMock = new Mock<IUsersService>(MockBehavior.Strict);
            userOK = new User()
            {
                UserId = 1,
                Name = "Test",
                Surname = "User",
                Email = "test@user.com",
                Password = "testuser123",
                Roles = new List<UserRole>() {
                    new UserRole()
                    {
                        RoleId = RoleCode.Espectador
                    }
                }
            };
            mockMapper = new Mock<IMapper>(MockBehavior.Strict);
            insertUserDto = new SecurityRegisterUserDto()
            {
                Name = "Test",
                Surname = "User",
                Email = "test@user.com",
                Password = "testuser123",
            };

            api = new SecurityController(mock.Object, usersServiceMock.Object, mockMapper.Object);

            randomToken = BusinessHelpers.StringGenerator.GenerateRandomToken(64);
            loginDto = new SecurityLoginDto()
            {
                Email = "test@test.com",
                Password = "12345"
            };
        }

        [TestMethod]
        public void LoginOk()
        {
            mock.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(randomToken);
            var result = api.Login(loginDto);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;

            mock.VerifyAll();
            Assert.AreEqual(StatusCodes.Status200OK, statusCode);
        }
        [TestMethod]
        public void LogoutOk()
        {
            mock.Setup(x => x.Logout(It.IsAny<string>()));
            var result = api.Logout(randomToken);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;

            mock.VerifyAll();
            Assert.AreEqual(StatusCodes.Status200OK, statusCode);
        }


        [TestMethod]
        public void RegisterOk()
        {
            usersServiceMock.Setup(x => x.InsertUser(userOK)).Returns(userOK);
            mockMapper.Setup(x => x.Map<SecurityRegisterUserDto>(userOK)).Returns(insertUserDto);
            var result = api.Register(insertUserDto);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;

            mock.VerifyAll();
            Assert.AreEqual(StatusCodes.Status200OK, statusCode);
        }
    }
}
