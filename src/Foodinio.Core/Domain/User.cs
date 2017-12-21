using System;
using System.Collections.Generic;

namespace Foodinio.Core.Domain
{
    public class User : BaseEntity
    {
        public string Email { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string FullName => GetFullName();
        public string Salt { get; protected set; }
        public string Password { get; protected set; }
        public string Role { get; set; }
        public virtual IEnumerable<DeliveryAddress> Addresses { get; protected set; }
        public virtual IEnumerable<Order> Orders { get; protected set; }

        protected User()
        {

        }

        public User(Guid userId, string email, string firstName, string lastName, string password, string salt, string role)
        {
            Id = userId;
            SetEmail(email);
            SetFirstName(firstName);
            SetLastName(lastName);
            SetRole(role);
            SetPassword(password, salt);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
            {
                throw new Exception();
            }
            if (Email == email)
            {
                return;
            }
            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetFirstName(string firstName)
        {
            if (String.IsNullOrWhiteSpace(firstName))
            {
                throw new Exception();
            }
            if (FirstName == firstName)
            {
                return;
            }
            FirstName = firstName;
            UpdatedAt = DateTime.UtcNow;
        }
        private void SetLastName(string lastName)
        {
            if (String.IsNullOrWhiteSpace(lastName))
            {
                throw new Exception();
            }
            if (LastName == lastName)
            {
                return;
            }
            LastName = lastName;
            UpdatedAt = DateTime.UtcNow;
        }

        private string GetFullName() => FirstName + " " + LastName;

        private void SetRole(string role)
        {
            if (String.IsNullOrWhiteSpace(role))
            {
                throw new Exception();
            }
            if (Role == role)
            {
                return;
            }
            Role = role;
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetPassword(string password, string salt)
        {
            if (String.IsNullOrWhiteSpace(password))
            {
                throw new Exception();
            }
            if (String.IsNullOrWhiteSpace(salt))
            {
                throw new Exception();
            }
            if (password.Length < 4)
            {
                throw new Exception();
            }
            if (password.Length > 100)
            {
                throw new Exception();
            }
            if (Password == password)
            {
                return;
            }
            Password = password;
            Salt = salt;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}