﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TruckUp3
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TruckUp3Entities : DbContext
    {
        public TruckUp3Entities()
            : base("name=TruckUp3Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CAMION> CAMION { get; set; }
        public virtual DbSet<CARGA> CARGA { get; set; }
        public virtual DbSet<CASETA_PUERTO> CASETA_PUERTO { get; set; }
        public virtual DbSet<CENTRAL> CENTRAL { get; set; }
        public virtual DbSet<COMUNA> COMUNA { get; set; }
        public virtual DbSet<CONDUCTOR> CONDUCTOR { get; set; }
        public virtual DbSet<HOJA_DE_RUTA> HOJA_DE_RUTA { get; set; }
        public virtual DbSet<PROVINCIA> PROVINCIA { get; set; }
        public virtual DbSet<REGION> REGION { get; set; }
        public virtual DbSet<ROL> ROL { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
    }
}
