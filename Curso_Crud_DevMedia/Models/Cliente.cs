using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Curso_Crud_DevMedia.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [ForeignKey("Consultor")]
        public int IdConsultor { get; set; }

        public virtual Consultor Consultor { get; set; }

        public virtual List<Telefone> Telefones { get; set; }
    }
}