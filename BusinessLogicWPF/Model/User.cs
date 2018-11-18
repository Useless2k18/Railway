namespace BusinessLogicWPF.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public sealed partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        [StringLength(50)]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Reservation> Reservations { get; set; }
    }
}
