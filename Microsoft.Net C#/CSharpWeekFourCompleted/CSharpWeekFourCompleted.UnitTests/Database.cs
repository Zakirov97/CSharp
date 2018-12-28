using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpWeekFourCompleted;
using CSharpWeekFourCompleted.YourCode;
using CSharpWeekFourCompleted.ViewModels;
using CSharpWeekFourCompleted.Models;

namespace CSharpWeekFourCompleted.UnitTests
{
    [TestClass]
    public class LiteDbTests
    {
        [TestMethod]
        public void LiteStorage_Create_ShouldAddItem()
        {
            StorageManager.DropDatabase();

            LiteStorage<ApplicationUser> usersStorage = new LiteStorage<ApplicationUser>();
            ApplicationUser userToAdd = new ApplicationUser("iskander@steam.com", "+77715691115", "12345");
            userToAdd.Id = Guid.NewGuid().ToString();

            usersStorage.Create(userToAdd);

            var allUsers = usersStorage.ReadAll();
            Assert.IsNotNull(allUsers);
        }
    }

    [TestClass]
    public class AccountMangerTests
    {
        [TestMethod]
        public void SignUp_test_method()
        {
            //Arrange
            AccountManager manager = new AccountManager();
            SignUpRequest request = new SignUpRequest()
            {
                Email = "email@gmail.com",
                Password = "1qweiIrty",
                PasswordConfirmation = "1qweiIrty",
                PhoneNumber = "87054774229"
            };
            Assert.IsTrue(manager.SignUpApplicationUser(request));
        }
    }
}
