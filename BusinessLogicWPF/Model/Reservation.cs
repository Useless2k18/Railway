namespace BusinessLogicWPF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reservation")]
    public partial class Reservation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TrainId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string AvailableDate { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string EmailId { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(25)]
        public string PassengerNameRecord { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string ReservationDate { get; set; }

        [StringLength(20)]
        public string ReservationStatus { get; set; }

        public virtual Train Train { get; set; }

        public virtual User User { get; set; }
    }
}
