using CSharpWeekFourCompleted.Models;
using CSharpWeekFourCompleted.ViewModels;
using CSharpWeekFourCompleted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace CSharpWeekFourCompleted.YourCode
{
    public class AccountManager
    {
        private LiteStorage<ApplicationUser> _userStorage;
        private LiteStorage<PasswordChangedRecord> _passwordStorage
        {
            new PasswordChangedRecord()

        
        }

        private bool ApplicationUserExists(string email, string phoneNumber)
        {
            return _userStorage.ReadAll()
                .ToList()
                .Exists(
                p => p.Email == email || 
                p.PhoneNumber == phoneNumber);
        }
        private bool ValidPassword(string password)
        {
            bool upper = false, digit = false;

            foreach (var item in password)
            {
                if (char.IsDigit(item))
                    digit = true;
                if (char.IsUpper(item))
                    upper = true;
            }

            return (password.Length >= 8) && upper && digit;
        }
        private int CheckCode()
        {
            return (new Random()).Next(1, 9999);
        }
        public bool SignUpApplicationUser(SignUpRequest request)
        {
            if (ApplicationUserExists(request.Email, request.PhoneNumber))
                return false;
            if (request.Password != request.PasswordConfirmation)
                return false;
            if (!ValidPassword(request.Password))
                return false;

            var newUser = new ApplicationUser(request.Email, request.PhoneNumber, request.Password.ToSha1Hash());

            var newPasswordChange = new PasswordChangedRecord(newUser.Id, DateTime.Now, request.Password.ToSha1Hash());

            _passwordStorage.Create(newPasswordChange);
            _userStorage.Create(newUser);

            return true;
        }

        public string[] GetOldPasswordsById(string id)
        {
            return _passwordStorage.ReadAll().ToList().FindAll(p => p.UserId == id).Select(p => p.PasswordHash).ToArray();
        }
        public bool ChangePassword(ChangePasswordRequest request)
        {
           // if(request.NewPassword == request.OldPassword)
             //   return true;

           // if (ValidPassword(request.NewPassword) == false)
             //   return false;



            var arr = GetOldPasswordsById(request.UserId);
            foreach (var item in arr)
            {
                if (item == request.NewPassword)
                    return false;
            }

            return true;
        }
        public bool ActivateAccount(ActivateAccountRequest request)
        {
            return false;
        }

        public void SendActivationCode()
        {

        }

        public bool LoginToAccount(LogInRequest request)
        {
            // Check for suspicious login here...
            return false;
        }

        public AccountManager()
        {
            _userStorage = new LiteStorage<ApplicationUser>();
            _passwordStorage = new LiteStorage<PasswordChangedRecord>();
        }

    }
}
