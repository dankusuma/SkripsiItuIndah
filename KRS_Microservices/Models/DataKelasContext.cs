using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.Services.Models
{
    public class DataKelasContext:DbContext
    {

        public DataKelasContext(DbContextOptions<DataKelasContext> options) : base(options)
        {

        }

        public DbSet<KelasClass> Kelas { get; set; }
        public DbSet<KelasKrsClass> KelasKRS { get; set; }
        public DbSet<DosenClass> KelasDosen { get; set; }
        public DbSet<TahunAkademikClass> TahunAkademik { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KelasClass>().ToTable("TBL_KELAS");
            modelBuilder.Entity<KelasKrsClass>().ToTable("TBL_KELAS_KRS");
            modelBuilder.Entity<DosenClass>().ToTable("MST_DOSEN");
            modelBuilder.Entity<TahunAkademikClass>().ToTable("TBL_TAHUN_AKADEMIK");
            modelBuilder.Entity<KelasKrsClass>(entity =>
            {
                entity.HasOne(c => c.kelas);
                entity.HasOne(c=>c.tahun_akademik);
            });
            modelBuilder.Entity<KelasClass>(entity =>
            {
                entity.HasOne(c => c.dosen1);
                entity.HasOne(c => c.dosen2);
                entity.HasOne(c => c.dosen3);
                entity.HasOne(c => c.dosen4);
            });
        }

       

    }
}
