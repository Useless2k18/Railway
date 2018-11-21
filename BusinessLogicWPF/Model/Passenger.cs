namespace BusinessLogicWPF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Passenger")]
    public partial class Passenger
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(25)]
        public string PassengerNameRecord { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SeatNumber { get; set; }

        [Required]
        [StringLength(8)]
        public string CoachNumber { get; set; }

        [Required]
        public string PassengerName { get; set; }

        public int Age { get; set; }

        [Required]
        [StringLength(8)]
        public string Gender { get; set; }

        public int TrainId { get; set; }

        [StringLength(30)]
        public string BookedBy { get; set; }

        public virtual Train Train { get; set; }
    }
}
