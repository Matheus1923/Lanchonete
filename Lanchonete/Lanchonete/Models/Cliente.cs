using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lanchonete.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [Column("idcliente")]
        [Required(ErrorMessage = "O campo é obrigatório")]

        public Int32 IdCliente { get; set; }

        [Column("nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é obrigatório")]

        public string Nome { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "O campo deve conter entre 1 á 3 caracteres")]
        [Column("numerodamesa")]

        public string NumeroDaMesa { get; set; }

        [Column("idlanche")]
        [Required(ErrorMessage = "O campo é obrigatório")]

        public int IdLanche { get; set; }

       
    }
}
