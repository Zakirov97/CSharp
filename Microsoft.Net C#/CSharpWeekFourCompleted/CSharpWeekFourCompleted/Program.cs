using CSharpWeekFourCompleted.Models;
using CSharpWeekFourCompleted.ViewModels;
using CSharpWeekFourCompleted.YourCode;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

// Use link #1 : https://ipdata.co/
// Use link #2 : http://lite.ip2location.com/kazakhstan-ip-address-ranges

namespace CSharpWeekFourCompleted
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountManager manager = new AccountManager();
            //SignUpRequest request = new SignUpRequest()
            //{
            //    Email = "email@gmail.com",
            //    Password = "1qweiIrty",
            //    PasswordConfirmation = "1qweiIrty",
            //    PhoneNumber = "87054774229"
            //};
            // manager.SignUpApplicationUser(request);


            ApplicationUser user = new ApplicationUser("mail.tu", "88005553535", "qwerty228");

            user.Id = "1";
          

            ChangePasswordRequest pass = new ChangePasswordRequest
            {
                UserId = "1",
                IpAddress = "12",
                NewPassword = "qwerty228",
                OldPassword = "qwerty228"
            };

            Console.WriteLine(manager.ChangePassword(pass));

            Console.WriteLine();
        }
    }
}