using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea3.DA.Entidades
{
    [Table("Producto")]
    public class ProductoDA
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int idProducto { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public decimal precio { get; set;}
        public virtual ICollection<ListaDeseadosDA> ListaDeseadosDA { get; set; } = new List<ListaDeseadosDA>();
    }
}
