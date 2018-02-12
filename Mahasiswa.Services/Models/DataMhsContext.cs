using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahasiswa.Services.Models
{
    public class DataMhsContext : DbContext
    {

        public DataMhsContext(DbContextOptions<DataMhsContext> options) : base(options)
        {


        }

        public DbSet<MahasiswaClass> Mahasiswa { get; set; }
        public DbSet<ProdiClass> Prodi { get; set; }
        public DbSet<FakultasClass> Fakultas { get; set; }
        public DbSet<TranskripClass> Transkrip { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {




           
            modelBuilder.Entity<MahasiswaClass>().ToTable("MST_MHS_AKTIF");
            modelBuilder.Entity<ProdiClass>().ToTable("REF_PRODI");
            modelBuilder.Entity<FakultasClass>().ToTable("REF_FAKULTAS");
            modelBuilder.Entity<TranskripClass>().ToTable("TBL_TRANSKRIP");

            modelBuilder.Entity<MahasiswaClass>(entity =>
            {
                entity.HasOne(c => c.prodi);
                entity.HasOne(d => d.fakultas);
                entity.HasOne(e => e.transkrip);
            

            });


        }


    }
}
