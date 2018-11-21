namespace BusinessLogicWPF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Route")]
    public partial class Route
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TrainId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StopNumber { get; set; }

        [Required]
        [StringLength(8)]
        public string StationId { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string ArrivalTime { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string DepartureTime { get; set; }

        public int SourceDistance { get; set; }

        public virtual Train Train { get; set; }
    }
}
