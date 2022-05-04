using System;
using LibraryManager.Models.Core;
using LibraryManager.Models.Enums;

namespace LibraryManager.Models
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public UserStatus Status { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? EndPenalizedPeriod { get; set; }

        public User()
        {
        }

        public User(int id, string name, string sex, string telephone, string email, UserStatus status, DateTime birthDate, DateTime? endPenalizedPeriod)
        {
            Id = id;
            Name = name;
            Sex = sex;
            Telephone = telephone;
            Email = email;
            Status = status;
            BirthDate = birthDate;
            EndPenalizedPeriod = endPenalizedPeriod;
        }
    }
}
