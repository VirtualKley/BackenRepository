using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendRepository.Models
{
    [Table("TBProducto")]
    public class TBProducto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string descripcion { get; set; }
        public int categoria_id { get; set; }
        public int proveedor_id { get; set; }
        public int marca_id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string medidas { get; set; }
        [Required]
        public decimal precio_unitario { get; set; }


        [ForeignKey("categoria_id")]
        public virtual TBCategoria categoria { get; set; }
        [ForeignKey("marca_id")]
        public virtual TBMarca marca { get; set; }
        [ForeignKey("proveedor_id")]
        public virtual TBProveedor proveedor { get; set; }

    }
}
