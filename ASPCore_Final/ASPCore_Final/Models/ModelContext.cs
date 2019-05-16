using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPCore_Final.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseOracle("User Id=nva;Password=123456;Data Source=localhost:1521/db12c;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "NVA");

            modelBuilder.HasSequence("ISEQ$$_78261");

            modelBuilder.HasSequence("ISEQ$$_78264");

            modelBuilder.HasSequence("ISEQ$$_78266");

            modelBuilder.HasSequence("ISEQ$$_78274");

            modelBuilder.HasSequence("ISEQ$$_78279");

            modelBuilder.HasSequence("ISEQ$$_78282");

            modelBuilder.HasSequence("ISEQ$$_78285");

            modelBuilder.HasSequence("ISEQ$$_78288");

            modelBuilder.HasSequence("ISEQ$$_78291");

            modelBuilder.HasSequence("ISEQ$$_78294");

            modelBuilder.HasSequence("ISEQ$$_78301");

            modelBuilder.HasSequence("ISEQ$$_78304");

            modelBuilder.HasSequence("ISEQ$$_78307");

            modelBuilder.HasSequence("ISEQ$$_78310");

            modelBuilder.HasSequence("ISEQ$$_78315");

            modelBuilder.HasSequence("ISEQ$$_78318");

            modelBuilder.HasSequence("ISEQ$$_78330");

            modelBuilder.HasSequence("ISEQ$$_78333");

            modelBuilder.HasSequence("ISEQ$$_78336");

            modelBuilder.HasSequence("ISEQ$$_78339");

            modelBuilder.HasSequence("ISEQ$$_78344");

            modelBuilder.HasSequence("ISEQ$$_78347");

            modelBuilder.HasSequence("ISEQ$$_78355");

            modelBuilder.HasSequence("ISEQ$$_78362");

            modelBuilder.HasSequence("ISEQ$$_78365");

            modelBuilder.HasSequence("ISEQ$$_78368");

            modelBuilder.HasSequence("ISEQ$$_78371");

            modelBuilder.HasSequence("ISEQ$$_78376");

            modelBuilder.HasSequence("ISEQ$$_78379");

            modelBuilder.HasSequence("ISEQ$$_78399");

            modelBuilder.HasSequence("ISEQ$$_78402");

            modelBuilder.HasSequence("ISEQ$$_78405");

            modelBuilder.HasSequence("ISEQ$$_78408");

            modelBuilder.HasSequence("ISEQ$$_78413");

            modelBuilder.HasSequence("ISEQ$$_78416");

            modelBuilder.HasSequence("ISEQ$$_78475");

            modelBuilder.HasSequence("ISEQ$$_78478");

            modelBuilder.HasSequence("ISEQ$$_78481");

            modelBuilder.HasSequence("ISEQ$$_78484");

            modelBuilder.HasSequence("ISEQ$$_78489");

            modelBuilder.HasSequence("ISEQ$$_78492");

            modelBuilder.HasSequence("ISEQ$$_79245");
        }
    }
}
