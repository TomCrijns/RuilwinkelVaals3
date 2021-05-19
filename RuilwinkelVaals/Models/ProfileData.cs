namespace RuilwinkelVaals.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProfileData")]
    public partial class ProfileData
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Voornaam { get; set; }

        [StringLength(50)]
        public string Achternaam { get; set; }

        public int? Balans { get; set; }

        public int? AccountType { get; set; }

        public int? Ledenpas { get; set; }

        [StringLength(50)]
        public string Straat { get; set; }

        [StringLength(10)]
        public string Huisnummer { get; set; }

        [StringLength(50)]
        public string Woonplaats { get; set; }

        [StringLength(10)]
        public string Postcode { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Geboortedatum { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateCreated { get; set; }

        public virtual AccountData AccountData { get; set; }

        public virtual AccountType_LT AccountType_LT { get; set; }

        public virtual Ledenpas_LT Ledenpas_LT { get; set; }
    }
}
