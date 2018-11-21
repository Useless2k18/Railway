namespace BusinessLogicWPF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tte")]
    public partial class Tte
    {
        [StringLength(50)]
        public string TteId { get; set; }

        [Required]
        public string EmailId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [StringLength(8)]
        public string Gender { get; set; }

        public int Age { get; set; }

        [Required]
        [StringLength(14)]
        public string Mobile { get; set; }

        [Required]
        [StringLength(20)]
        public string City { get; set; }

        [Required]
        [StringLength(25)]
        public string State { get; set; }

        public long AadharCard { get; set; }

        [Required]
        [StringLength(80)]
        public string SecurityQuestion { get; set; }

        [Required]
        [StringLength(20)]
        public string SecurityAnswer { get; set; }
    }
}
