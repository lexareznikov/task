﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    [Table("ref_type", Schema = "public")]
    public class RefType
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [ Column("name")]
        public string Name { get; set; }


    }

}