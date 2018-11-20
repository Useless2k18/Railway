namespace BusinessLogicWPF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DaysAvailable")]
    public partial class DaysAvailable
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TrainId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string AvailableDays { get; set; }
    }
}
