using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDrogueriaFenix.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Required]
        [StringLength(100)]
        public String Codigo { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorCodigo { get; set; }

        [Required]
        [StringLength(100)]
        public String Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public String Descripcion { get; set; }

        [Required]
        public int Stock { get; set; }
        
        [Required]
        public int IdCategoria { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }

        /*ER*/

        public ProductoTienda ProductoTienda { get; set; }
    }
}
