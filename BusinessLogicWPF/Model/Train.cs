namespace BusinessLogicWPF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Train")]
    public partial class Train
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Train()
        {
            Passengers = new HashSet<Passenger>();
            PassengerTickets = new HashSet<PassengerTicket>();
            Reservations = new HashSet<Reservation>();
            Routes = new HashSet<Route>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TrainId { get; set; }

        [Required]
        [StringLength(50)]
        public string TrainName { get; set; }

        [Required]
        [StringLength(50)]
        public string TrainType { get; set; }

        [StringLength(30)]
        public string SourceStation { get; set; }

        [StringLength(30)]
        public string DestinationStation { get; set; }

        [StringLength(8)]
        public string SourceId { get; set; }

        [StringLength(8)]
        public string DestinationId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Passenger> Passengers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PassengerTicket> PassengerTickets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Route> Routes { get; set; }

        public virtual Station Station { get; set; }

        public virtual Station Station1 { get; set; }
    }
}
