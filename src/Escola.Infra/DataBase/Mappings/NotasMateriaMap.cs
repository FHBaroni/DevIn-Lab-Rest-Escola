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
    internal class NotasMateriaMap : IEntityTypeConfiguration<NotasMateria>
    {
        public void Configure(EntityTypeBuilder<NotasMateria> builder)
        {
            builder.ToTable("NotasMateria");

            builder.HasKey(n => n.Id);


            builder.Property(n => n.Id)
                   .UseIdentityColumn()
                   .ValueGeneratedOnAdd();

            builder.Property(n => n.Nota)
                   .HasColumnName("NOTAS")
                   .HasColumnType("float");

            builder.HasOne(b => b.boletim)
                   .WithMany(n => n.Notas)
                   .HasForeignKey(b => b.BoletimId);

            builder.HasOne(m => m.materia)
                   .WithMany(n => n.NotasMaterias)
                   .HasForeignKey(m => m.MateriaId);
        }
    }
}
