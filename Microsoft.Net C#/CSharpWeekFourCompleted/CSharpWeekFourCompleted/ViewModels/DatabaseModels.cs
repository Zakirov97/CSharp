using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpWeekFourCompleted.Models
{
    #region Database Models
    public abstract class ApplicationObject
    {
        public bool IsDeleted { get; set; }
        public Nullable<DateTime> DeletedDate { get; set; }
    }
    public class ApplicationUser : ApplicationObject, IComparable<ApplicationUser>, IApplicationSerializable, IDatabaseModel
    {
        #region User-Defined Data
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        #endregion

        #region System-Defined Data
        public string PasswordHash { get; set; }
        public string[] OldPasswordsHash { get; private set; }

        public DateTime RegistrationDate { get; set; }
        public string RegistrationIp { get; set; }
        public bool IsActivated { get; set; }
        #endregion

        public ApplicationUser(string email, string phoneNumber, string password, string ipAddress) : this()
        {
            Email = email;
            PhoneNumber = phoneNumber;
            PasswordHash = password.ToSha1Hash();
            RegistrationIp = ipAddress;
        }
        public ApplicationUser(string email, string phoneNumber, string password) :
            this(email, phoneNumber, password, null)
        {
        }
        private ApplicationUser() : base()
        {
            IsDeleted = false;
            IsActivated = false;
            RegistrationDate = DateTime.Now;
            Id = Guid.NewGuid().ToString();
        }

        public int CompareTo(ApplicationUser other)
        {
            return (Id == other.Id ||
                Email == other.Id ||
                PhoneNumber == other.PhoneNumber) ? 0 : 1;
        }
    }

    public class PasswordChangedRecord : IDatabaseModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime ChangedDate { get; set; }
        public string PasswordHash { get; set; }
        public PasswordChangedRecord(string userId, DateTime changedDate, string passwordHash)
        {
            UserId = userId;
            ChangedDate = changedDate;
            PasswordHash = passwordHash;
        }
        public PasswordChangedRecord()
        {

        }
    }
    public class LoginRecord : IDatabaseModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime LoginTime { get; set; }
        public string LoginIpAddress { get; set; }
        public LoginRecord(int id, string userId, DateTime loginTime, string ipAddress)
        {
            LoginIpAddress = ipAddress;
        }
        private LoginRecord()
        {

        }
    }

    public class ChatMessage
    {
        public int Id { get; set; }
        public string SenderUserId { get; set; }
        public string ReceiverUserId { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public ChatMessage(string senderId, string receiverId, string body)
        {
            SenderUserId = senderId;
            ReceiverUserId = receiverId;
            Body = body;
            CreatedDate = DateTime.Now;
        }
    }

    #endregion
}
