﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetAdoptionServicesAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PetAdoptionDBEntities : DbContext
    {
        public PetAdoptionDBEntities()
            : base("name=PetAdoptionDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Pet> Pet { get; set; }
        public virtual DbSet<PetActivity> PetActivity { get; set; }
        public virtual DbSet<PetImageGallery> PetImageGallery { get; set; }
        public virtual DbSet<PetPublisher> PetPublisher { get; set; }
        public virtual DbSet<PetSize> PetSize { get; set; }
        public virtual DbSet<PetType> PetType { get; set; }
    }
}
