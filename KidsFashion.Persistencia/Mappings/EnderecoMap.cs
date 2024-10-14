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
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd(); // Auto-generated ID

            builder.Property(p => p.Logradouro)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(p => p.Numero)
                .HasColumnType("nvarchar(10)");

            builder.Property(p => p.Complemento)
                .HasColumnType("nvarchar(50)");

            builder.Property(p => p.Bairro)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            // Relacionamento N:1 com Municipio
            builder.HasOne(p => p.Municipio)
                .WithMany()
                .HasForeignKey(p => p.Municipio_Id)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }

}
