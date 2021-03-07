using FastFeet.Dominio.AggregatesModel.EncomendasAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFeet.Infra.EntityConfigurations
{
    public class EncomendaConfig : IEntityTypeConfiguration<Encomenda>
    {
        public void Configure(EntityTypeBuilder<Encomenda> builder)
        {
            builder.ToTable("Encomendas");

            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Descricao).IsRequired().IsUnicode();
            builder.Property(x => x.AssinaturaId);
            builder.Property(x => x.DataFinal);
            builder.Property(x => x.DataInicio);
            builder.Property(x => x.CanceledAt);
            builder.Property(x => x.EntregadorId).IsRequired();
            builder.Property(x => x.DestinatarioId).IsRequired();
            builder.HasOne(x => x.Entregador).WithMany().HasForeignKey(x => x.EntregadorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Destinatario).WithMany().HasForeignKey(x => x.DestinatarioId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Problemas).WithOne().HasForeignKey(x => x.EncomendaId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
