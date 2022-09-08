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
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Boletim> Boletins { get; set; }
        public DbSet<NotasMateria> NotasMaterias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BD_Escola;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new BoletimMap());
            modelBuilder.ApplyConfiguration(new MateriaMap());          
            modelBuilder.ApplyConfiguration(new NotasMateriaMap());
        }
    }
}