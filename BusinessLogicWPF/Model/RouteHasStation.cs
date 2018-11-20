namespace BusinessLogicWPF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RouteHasStation")]
    public partial class RouteHasStation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TrainId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string StationId { get; set; }

        public int StopNumber { get; set; }
    }
}
