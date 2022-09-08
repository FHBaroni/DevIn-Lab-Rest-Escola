using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escola.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.DataBase.Mappings
{
    public class BoletimMap : IEntityTypeConfiguration<Boletim>
    {
        public void Configure(EntityTypeBuilder<Boletim> builder)
        {
            builder.ToTable("Boletim");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                   .UseIdentityColumn()
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.Faltas)
                   .HasColumnName("Faltas")
                   .HasColumnType("int");

            builder.Property(b => b.Periodo)
                   .HasColumnName("Periodo")
                   .HasColumnType("varchar")
                   .HasMaxLength(50);


            builder.HasOne(a => a.Aluno)
                .WithMany(b => b.Boletins)
                .HasForeignKey(a => a.AlunoId);

            builder.HasMany(n => n.Notas)
                .WithOne(b => b.boletim);
            //como temos uma lista de notas é melhor er só o objeto sem FK notasId
            //Id seria usado se fosse um objeto único
        }
    }
}
