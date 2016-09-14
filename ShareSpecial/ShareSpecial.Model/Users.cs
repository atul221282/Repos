using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Users : BaseEntity
    {
        //http://lockmedown.com/hash-right-implementing-pbkdf2-net/
        //https://cmatskas.com/-net-password-hashing-using-pbkdf2/

        private string _emailAddress;
        private string _firstName;
        private string _surnName;
        private string _confirmationToken = Guid.NewGuid().ToString();
        private DateTimeOffset? _lastPasswordFailureDate = null;
        private int? _passwordFailuresSinceLastSuccess = 0;
        private string _password;
        private DateTimeOffset? _passwordChangedDate = null;
        private string _passwordVerificationToken = null;
        private DateTimeOffset? _passwordVerificationTokenExpirationDate = null;
        private bool? _isConfirmed = false;

        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string SurName
        {
            get { return _surnName; }
            set { _surnName = value; }
        }
        public string ConfirmationToken
        {
            get { return _confirmationToken; }
            set { _confirmationToken = value; }
        }
        public bool? IsConfirmed
        {
            get { return _isConfirmed; }
            set { _isConfirmed = value; }
        }
        public DateTimeOffset? LastPasswordFailureDate
        {
            get { return _lastPasswordFailureDate; }
            set { _lastPasswordFailureDate = value; }
        }
        public int? PasswordFailuresSinceLastSuccess
        {
            get { return _passwordFailuresSinceLastSuccess; }
            set { _passwordFailuresSinceLastSuccess = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public DateTimeOffset? PasswordChangedDate
        {
            get { return _passwordChangedDate; }
            set { _passwordChangedDate = value; }
        }
        public string PasswordVerificationToken
        {
            get { return _passwordVerificationToken; }
            set { _passwordVerificationToken = value; }
        }
        public DateTimeOffset? PasswordVerificationTokenExpirationDate
        {
            get { return _passwordVerificationTokenExpirationDate; }
            set { _passwordVerificationTokenExpirationDate = value; }
        }

        public string FullName
        {
            get { return $"{FirstName} {SurName}"; }
        }

        public virtual ICollection<UsersUsersType> UsersUsersTypes { get; set; }
    }
}
