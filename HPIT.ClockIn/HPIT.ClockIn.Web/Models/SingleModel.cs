namespace HPIT.ClockIn.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SingleModel : DbContext
    {
        public SingleModel()
            : base("name=SingleModel1")
        {
        }

        public virtual DbSet<CardTable> CardTable { get; set; }
        public virtual DbSet<LoinTable> LoinTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardTable>()
                .Property(e => e.C_Task)
                .IsUnicode(false);

            modelBuilder.Entity<CardTable>()
                .Property(e => e.C_Evaluate)
                .IsUnicode(false);

            modelBuilder.Entity<LoinTable>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<LoinTable>()
                .Property(e => e.Pwd)
                .IsUnicode(false);
        }
    }
}
