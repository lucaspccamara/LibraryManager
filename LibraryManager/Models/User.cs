using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
