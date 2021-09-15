using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendRepository.Models
{
    [Table("TBProveedor")]
    public class TBProveedor
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string nombre { get; set; }
    }
}
