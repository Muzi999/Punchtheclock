namespace HPIT.ClockIn.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CardTable")]
    public partial class CardTable
    {
        public int Id { get; set; }

        [Required]
        [StringLength(16)]
        public string C_Name { get; set; }

        public DateTime? C_AddTime { get; set; }

        public DateTime? C_EndTime { get; set; }

        [StringLength(256)]
        [Required]
        public string C_Task { get; set; }

        [StringLength(1024)]
        public string C_Evaluate { get; set; }
    }
}
