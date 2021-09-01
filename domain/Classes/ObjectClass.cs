using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    [Table("object", Schema = "public")]
    public class ObjectClass
    {
        public ObjectClass()
        {
            Childrens = new List<ObjectClass>();
            AreaChangings = new List<AreaChanging>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("parent_id")]
        public int? ParentId { get; set; }
        [Column("type_id")]
        public int? TypeId { get; set; }

        [ForeignKey("ParentId")]
        public virtual ICollection<ObjectClass> Childrens { get; set; }
        public virtual ICollection<AreaChanging> AreaChangings{ get; set; }
        [ForeignKey("TypeId")]
        public virtual RefType Type { get; set; }


    }
}
