namespace BusinessLogicWPF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PassengerTicket")]
    public partial class PassengerTicket
    {
        [Key]
        [StringLength(25)]
        public string PassengerNameRecord { get; set; }

        [Required]
        [StringLength(8)]
        public string SourceId { get; set; }

        [Required]
        [StringLength(8)]
        public string DestinationId { get; set; }

        [Required]
        [StringLength(50)]
        public string ClassType { get; set; }

        [Required]
        [StringLength(25)]
        public string ReservationStatus { get; set; }

        public int TrainId { get; set; }

        [StringLength(30)]
        public string BookedBy { get; set; }

        public virtual Train Train { get; set; }
    }
}
