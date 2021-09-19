using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDrogueriaFenix.Models
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50)]
        public String Ruc { get; set; }

        [Required]
        [StringLength(100)]
        public String RazonSocial { get; set; }

        [Required]
        [StringLength(50)]
        public String Telefono { get; set; }

        [Required]
        [StringLength(50)]
        public String Correo { get; set; }

        [Required]
        [StringLength(50)]
        public String Direccion { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true) ]
        public DateTime FechaRegistro { get; set; }


        public ICollection<Producto> Productos { get; set; }

    }
}
