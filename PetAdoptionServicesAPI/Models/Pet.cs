//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Pet
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> IdType { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> IdSize { get; set; }
        public string Gender { get; set; }
        public Nullable<int> IdActivity { get; set; }
        public string Breed { get; set; }
        public Nullable<bool> Vaccinated { get; set; }
        public Nullable<int> IdCountry { get; set; }
        public Nullable<int> IdCity { get; set; }
        public string Details { get; set; }
        public string PrimaryImage { get; set; }
        public Nullable<long> IdImageGallery { get; set; }
        public Nullable<long> IdPetPublisher { get; set; }
    
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual PetActivity PetActivity { get; set; }
        public virtual PetImageGallery PetImageGallery { get; set; }
        public virtual PetPublisher PetPublisher { get; set; }
        public virtual PetSize PetSize { get; set; }
        public virtual PetType PetType { get; set; }
    }
}
