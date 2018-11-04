using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogicWPF
{
    [Table("tbl_Person")]
    class Person
    {
        public string EmailId { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
