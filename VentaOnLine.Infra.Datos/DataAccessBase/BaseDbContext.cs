using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;
using VentaOnLine.Domain.Entities;

namespace VentaOnLine.Infra.Datos.DataAccessBase
{
    public abstract class BaseDbContext: DbContext
    {
        public BaseDbContext(string connectionString): base(connectionString)
        {
            Database.SetInitializer<BaseDbContext>(null);

            this.Configuration.LazyLoadingEnabled = false;

            this.Configuration.ProxyCreationEnabled = false;

            this.Configuration.AutoDetectChangesEnabled = false;

            this.Configuration.ValidateOnSaveEnabled = false;

           
        }

        public virtual DbSet<Categoria> Categoria { get; set; }

        public virtual DbSet<Producto> Producto { get; set; }

        public virtual DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }


    }
}
