using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.DAL.Entities
{
    public class BaseEntity : ICloneable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; } = DateTime.Now;
        public string Remarks { get; set; }
        public RecordStatusType RecordStatus { get; set; } = RecordStatusType.Active;

        public enum RecordStatusType
        {
            Active,
            InActive,
            Deleted
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
