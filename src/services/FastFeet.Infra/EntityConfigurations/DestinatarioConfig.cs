using FastFeet.Dominio.AggregatesModel.DestinatarioAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFeet.Infra.EntityConfigurations
{
    public class DestinatarioConfig : IEntityTypeConfiguration<Destinatario>
    {
        public void Configure(EntityTypeBuilder<Destinatario> builder)
        {
            builder.ToTable("recipients");

            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Nome).IsRequired().IsUnicode();

            builder.OwnsOne(x => x.Endereco, e =>
            {
                e.Property(x => x.Logradouro).HasMaxLength(250).IsUnicode();  
                e.Property(x => x.Cidade).IsUnicode();
                e.Property(x => x.Estado).IsUnicode();
                e.Property(x => x.Complemento).IsUnicode();
                e.Property(x => x.Numero).IsUnicode();
                e.Property(x => x.Cep);
            });

        }
    }
}
