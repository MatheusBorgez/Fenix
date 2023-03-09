using Fenix.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fenix.Maps
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();
            builder.Property(c => c.Nome).HasColumnName("nome");
            builder.Property(c => c.Bairro).HasColumnName("bairro");
            builder.Property(c => c.Telefone).HasColumnName("telefone");
            builder.Property(c => c.Endereco).HasColumnName("endereco");
            builder.Property(c => c.Cidade).HasColumnName("cidade");
        }
    }
}
