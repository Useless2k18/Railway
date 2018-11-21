namespace BusinessLogicWPF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StationMaster")]
    public partial class StationMaster
    {
        [StringLength(30)]
        public string Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailId { get; set; }

        [Required]
        public string Password { get; set; }

        public long AadharCard { get; set; }

        [Required]
        [StringLength(8)]
        public string Gender { get; set; }

        [Required]
        [StringLength(8)]
        public string StationId { get; set; }

        public virtual Station Station { get; set; }
    }
}
