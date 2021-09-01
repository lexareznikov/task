using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    [Table("area_changing", Schema = "public")]
    public class AreaChanging
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("val_1")]
        public float? Val1 { get; set; }

        [Column("val_2")]
        public float? Val2 { get; set; }

        [Column("obj_id")]
        public int ObjId { get; set; }
        [Column("changing_dt")]
        public DateTime  ChangingDate{ get; set; }
        [Column("area")]
        public float Area { get; set; }
        [ForeignKey("ObjId")]
        public virtual ObjectClass ObjectClass { get; set; }

    }
}
