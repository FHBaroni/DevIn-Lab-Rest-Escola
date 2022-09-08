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
    public class NotasMateriaMap : IEntityTypeConfiguration<NotasMateria>
    {
        public void Configure(EntityTypeBuilder<NotasMateria> builder)
        {
            builder.ToTable("NotasMateria");

            builder.HasKey(x => x.Id);


            builder.Property(x => x.Id)
                   .UseIdentityColumn()
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Nota)
                   .HasColumnName("Notas")
                   .HasColumnType("float");

            builder.HasOne(x => x.boletim)
                   .WithMany(x => x.Notas)
                   .HasForeignKey(x => x.BoletimId);

            builder.HasOne(x => x.materia)
                   .WithMany(x => x.NotasMaterias)
                   .HasForeignKey(x => x.MateriaId);
        }
    }
}
