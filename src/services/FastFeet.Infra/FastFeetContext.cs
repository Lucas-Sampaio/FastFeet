﻿using FastFeet.Dominio.AggregatesModel.DestinatarioAggregate;
using FastFeet.Dominio.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FastFeet.Infra
{
    public class FastFeetContext : DbContext, IUnitOfWork
    {
        public FastFeetContext(DbContextOptions<FastFeetContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;  
        }
        public DbSet<Destinatario> Destinatarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            var propriedades = modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetProperties().Where(y => y.ClrType == typeof(string)));
            foreach (var property in propriedades)
            {
                property.SetColumnType("varchar(100)");
            }
           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FastFeetContext).Assembly);   
            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;
            return sucesso;
        }
    }

}
