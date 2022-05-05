using System;
using LibraryManager.Models.Core;
using LibraryManager.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace LibraryManager.Models
{
    public class User : BaseEntity
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Gênero")]
        public string Sex { get; set; }

        [DisplayName("Celular")]
        public string Telephone { get; set; }
        public string Email { get; set; }
        public UserStatus Status { get; set; }
        public DateTime BirthDate { get; set; }

        [NotMapped]
        [DisplayName("Nascido em")]
        public string BirthDateStr
        {
            get
            {
                if (this.BirthDate != null)
                {
                    return this.BirthDate.ToString("dd/MM/yyyy");
                }
                else
                {
                    return "-";
                }
            }
            set { }
        }

        public DateTime? EndPenalizedPeriod { get; set; }

        [NotMapped]
        [DisplayName("Fim da Penalização")]
        public string EndPenalizedPeriodStr
        {
            get
            {
                if (this.EndPenalizedPeriod != null)
                {
                    return this.EndPenalizedPeriod.Value.ToString("dd/MM/yyyy");
                }
                else
                {
                    return "-";
                }
            }
            set { }
        }

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
