using System;
using LibraryManager.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Models.Core
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedDateStr 
        {
            get
            {
                if (this.CreatedDate != null)
                {
                    return this.CreatedDate.ToString("dd/MM/yyyy");
                }
                else
                {
                    return "";
                }
            }
            set { }
        }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedDateStr
        {
            get
            {
                if (this.UpdatedDate != null)
                {
                    return this.UpdatedDate.Value.ToString("dd/MM/yyyy");
                }
                else
                {
                    return "";
                }
            }
            set { }
        }
        public DateTime? DeletedDate { get; set; }
        public string DeletedDateStr
        {
            get
            {
                if (this.DeletedDate != null)
                {
                    return this.DeletedDate.Value.ToString("dd/MM/yyyy");
                }
                else
                {
                    return "";
                }
            }
            set { }
        }
        public ActiveStatus IndAtivo { get; set; }
    }
}
