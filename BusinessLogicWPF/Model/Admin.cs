namespace BusinessLogicWPF.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        [StringLength(20)]
        public string UserId { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
