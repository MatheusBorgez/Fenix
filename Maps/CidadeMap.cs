using Fenix.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fenix.Maps
{
    public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("Cidade");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseSqlServerIdentityColumn();
            builder.Property(c => c.Nome).HasColumnName("nome");
            builder.Property(c => c.UF).HasColumnName("UF");
        }
    }
}
