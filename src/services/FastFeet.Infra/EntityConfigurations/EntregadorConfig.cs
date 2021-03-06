using FastFeet.Dominio.AggregatesModel.EntregadorAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFeet.Infra.EntityConfigurations
{
    class EntregadorConfig : IEntityTypeConfiguration<Entregador>
    {
        public void Configure(EntityTypeBuilder<Entregador> builder)
        {
            builder.ToTable("Entregadores");
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Nome).IsRequired().IsUnicode();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.AvatarId);
        }
    }
}
