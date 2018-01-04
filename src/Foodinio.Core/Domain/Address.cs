using System;
using Foodinio.Core.Exceptions;

namespace Foodinio.Core.Domain
{
    public class Address : BaseEntity
    {
        public Guid UserId { get; protected set; }
        public virtual User User { get; protected set; }
        public virtual Order Order { get; protected set; }
        public string City { get; protected set; }
        public string Street { get; protected set; }
        public string HouseNumber { get; protected set; }
        public string PostalCode { get; protected set; }

        protected Address()
        {

        }
        public Address(Guid id, Guid userId, string city, string street, string houseNumber, string postalCode)
        {
            Id = id;
            SetUserId(userId);
            SetCity(city);
            SetStreet(street);
            SetHouseNumber(houseNumber);
            SetPostalCode(postalCode);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetUserId(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new DomainException(ErrorCodes.InvalidUserId, "Address must be assigned to user.");
            }
            UserId = userId;
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetCity(string city)
        {
            if (String.IsNullOrWhiteSpace(city))
            {
                throw new DomainException(ErrorCodes.InvalidCity, "City can not be empty.");
            }
            if (City == city)
            {
                return;
            }
            City = city;
            UpdatedAt = DateTime.UtcNow;
        }
        private void SetStreet(string street)
        {
            if (String.IsNullOrWhiteSpace(street))
            {
                throw new DomainException(ErrorCodes.InvalidStreet, "Street can not be empty.");
            }
            if (Street == street)
            {
                return;
            }
            Street = street;
            UpdatedAt = DateTime.UtcNow;
        }
        private void SetHouseNumber(string houseNumber)
        {
            if (String.IsNullOrWhiteSpace(houseNumber))
            {
                throw new DomainException(ErrorCodes.InvalidHouseNumber, "House number can not be empty.");
            }
            if (HouseNumber == houseNumber)
            {
                return;
            }
            HouseNumber = houseNumber;
            UpdatedAt = DateTime.UtcNow;
        }
        private void SetPostalCode(string postalCode)
        {
            if (String.IsNullOrWhiteSpace(postalCode))
            {
                throw new DomainException(ErrorCodes.InvalidPostalCode, "Postal code can not be empty.");
            }
            if (PostalCode == postalCode)
            {
                return;
            }
            PostalCode = postalCode;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}