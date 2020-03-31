using Curso_Crud_DevMedia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Curso_Crud_DevMedia.Context
{
    public class LojaContext : DbContext
    {
        public LojaContext():base("Loja")
        {
            Database.Log = instrucao => System.Diagnostics.Debug.WriteLine(instrucao);      
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Consultor> Consultores { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
    }
}