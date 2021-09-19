using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDrogueriaFenix.Models
{
    public class ProductoTienda
    {
        [Key]
        public int IdProductoTienda { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Required]
        public int IdTienda { get; set; }

        /*ER*/

        public ICollection<Producto> Productos { get; set; }

        public ICollection<Tienda> Tiendas { get; set; }
        
    }
}
