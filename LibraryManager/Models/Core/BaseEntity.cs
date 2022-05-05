using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryManager.Models.Enums;

namespace LibraryManager.Models.Core
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; }

        [NotMapped]
        [DisplayName("Criado em")]
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
                    return "-";
                }
            }
            set { }
        }
        public DateTime? UpdatedDate { get; set; }

        [NotMapped]
        [DisplayName("Atualizado em")]
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
                    return "-";
                }
            }
            set { }
        }
        public DateTime? DeletedDate { get; set; }

        [NotMapped]
        [DisplayName("Deletado em")]
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
                    return "-";
                }
            }
            set { }
        }

        [DisplayName("Ativo")]
        public ActiveStatus IndAtivo { get; set; }
    }
}
