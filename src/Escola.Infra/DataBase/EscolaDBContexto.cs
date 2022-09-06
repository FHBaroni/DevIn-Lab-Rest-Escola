using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escola.Domain.Models;
using Escola.Infra.DataBase.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Escola.Infra.DataBase
{
    public class EscolaDBContexto : DbContext
    {
        /* private IConfiguration _configuration;
         public EscolaDBContexto(IConfiguration configuration)
         {
             _configuration = configuration;

         }*/

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // optionsBuilder.UseSqlServer(_configuration.GetConnectionString("CONEXAO_BANCO"));
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BD_DevIn-Lab-Rest2-Escola;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
        }
    }
}