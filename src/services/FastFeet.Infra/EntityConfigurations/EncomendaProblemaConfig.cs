using FastFeet.Dominio.AggregatesModel.EncomendasAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFeet.Infra.EntityConfigurations
{
    class EncomendaProblemaConfig : IEntityTypeConfiguration<EncomedaProblemas>
    {
        public void Configure(EntityTypeBuilder<EncomedaProblemas> builder)
        {
            builder.ToTable("EncomendaProblemas");

            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Descricao).IsRequired().IsUnicode();

            builder.Property(x => x.EncomendaId).IsRequired();
        }
    }
}
