﻿using EDriveRent.Models.Contracts;
using System;
using EDriveRent.Utilities.Messages;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private string drivingLicenseNumber;

        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DrivingLicenseNumber = drivingLicenseNumber;
            Rating = 0;
            IsBlocked = false;
        }

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FirstNameNull);
                }

                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LastNameNull);
                }

                lastName = value;
            }
        }
        public double Rating { get; private set; }
        public string DrivingLicenseNumber
        {
            get => drivingLicenseNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);
                }

                drivingLicenseNumber = value;
            }
        }
        public bool IsBlocked { get; private set; }

        public void DecreaseRating()
        {
            Rating -= 2;

            if (Rating <= 0)
            {
                Rating = 0;

                IsBlocked = true;
            }
        }
        public void IncreaseRating()
        {
            Rating += 0.5;

            if (Rating >= 10)
            {
                Rating = 10;
            }
        }

        public override string ToString()
            => $"{FirstName} {LastName} Driving license: {DrivingLicenseNumber} Rating: {Rating}";
    }
}
