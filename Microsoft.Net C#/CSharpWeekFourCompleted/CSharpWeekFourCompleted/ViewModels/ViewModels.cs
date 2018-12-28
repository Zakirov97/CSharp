using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpWeekFourCompleted.ViewModels
{
    public abstract class RequestBase
    {
        public string IpAddress { get; set; }
    }
    public class SignUpRequest : RequestBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ChangePasswordRequest : RequestBase
    {
        public string UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class LogInRequest : RequestBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class ActivateAccountRequest : RequestBase
    {
        public string UserId { get; set; }
        public string ActivationCode { get; set; }

    }
}
