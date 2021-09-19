using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDrogueriaFenix.Models
{
    public class Tienda
    {
        [Key]
        public int IdTienda { get; set; }

        [Required]
        [StringLength(50)]
        public String Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public String Rut { get; set; }

        [Required]
        [StringLength(100)]
        public String Direccion { get; set; }
                
        [Required]
        [StringLength(50)]
        public String Telefono { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        /*ER*/
        public ICollection<Cliente> Clientes { get; set; }
        public ProductoTienda ProductoTienda { get; set; }

    }
}
