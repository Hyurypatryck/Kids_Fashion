using KidsFashion.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFashion.Persistencia.Mappings
{
    public class MunicipioMap : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Municipio> builder)
        {
            builder.ToTable("Municipio");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd(); // Auto-generated ID

            builder.Property(p => p.Nome)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(p => p.UF)
                .HasColumnType("nvarchar(2)")
                .IsRequired();
        }
    }

}
