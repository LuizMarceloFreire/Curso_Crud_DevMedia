using Curso_Crud_DevMedia.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Curso_Crud_DevMedia.Models
{
    public class Telefone
    {
        public int Id { get; set; }
        public int DDD { get; set; }
        public string Numero { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
    }
}