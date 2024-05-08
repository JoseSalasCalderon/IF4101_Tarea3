using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tarea3.DA.Entidades
{
    [Table("ListaDeseados")]
    public class ListaDeseadosDA
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int idListaDeseado { get; set; }
        [Required]
        public long idProducto { get; set; }
        [Required]
        public int cantidad { get; set; }
        [ForeignKey("idProducto")]
        public virtual ProductoDA ProductoVinculado { get; set; } = null!;
    }
}
