using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lanchonete.Models
{
    [Table("Lanche")]
    public class Lanche
    {
        [Key]
        [Column("idlanche")]
        [Required(ErrorMessage = "O campo é obrigatório")]

        public Int32 IdLanche { get; set; }

        [Column("nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é obrigatório")]

        public string Nome { get; set; }

        [Column("preco")]
        [Required(ErrorMessage = "O campo é obrigatório")]

        public double Preco { get; set; }
    }
}
