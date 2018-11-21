namespace BusinessLogicWPF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrainClass")]
    public partial class TrainClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TrainId { get; set; }

        public int FareClass1 { get; set; }

        public int FareClass2 { get; set; }

        public int FareClass3 { get; set; }

        public int SeatClass1 { get; set; }

        public int SeatClass2 { get; set; }

        public int SeatClass3 { get; set; }
    }
}
