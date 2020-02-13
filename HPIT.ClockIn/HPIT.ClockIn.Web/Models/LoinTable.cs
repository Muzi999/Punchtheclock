namespace HPIT.ClockIn.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoinTable")]
    public partial class LoinTable
    {
        public int ID { get; set; }

        [Required]
        [StringLength(16)]
        public string Mobile { get; set; }

        [Required]
        [StringLength(16)]
        public string Name { get; set; }

        [Required]
        [StringLength(32)]
        public string Pwd { get; set; }
    }
}
