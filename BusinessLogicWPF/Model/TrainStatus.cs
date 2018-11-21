namespace BusinessLogicWPF.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TrainStatus
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TrainId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string AvailableDate { get; set; }

        public int? BookedSeats1 { get; set; }

        public int? BookedSeats2 { get; set; }

        public int? BookedSeats3 { get; set; }

        public int? BookedSeats4 { get; set; }

        public int? WaitingSeats1 { get; set; }

        public int? WaitingSeats2 { get; set; }

        public int? WaitingSeats3 { get; set; }

        public int? WaitingSeats4 { get; set; }

        public int? AvailableSeats1 { get; set; }

        public int? AvailableSeats2 { get; set; }

        public int? AvailableSeats3 { get; set; }

        public int? AvailableSeats4 { get; set; }
    }
}
