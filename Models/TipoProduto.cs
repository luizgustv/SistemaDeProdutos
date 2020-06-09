using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeProdutos.Models
{
    public class TipoProduto
    {
        [Key]
        public int IdTipo {get; set;}

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string DescricaoTipo { get; set; }

        [Column("comercializado")]
        public string StringToBool { get; set; }

        [NotMapped]
        public bool Comercializado
        {
            get { return StringToBool == "T"; }
            set { StringToBool = value ? "T": "F"; }
        }

    }
}
