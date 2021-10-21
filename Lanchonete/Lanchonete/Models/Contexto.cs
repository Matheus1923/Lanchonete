using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lanchonete.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Lanche> Lanches { get; set; }
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {

        }
    }
}
