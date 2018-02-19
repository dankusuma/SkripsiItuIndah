using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Services.Models
{
    public class DataMhsContext : DbContext
    {

        public DataMhsContext(DbContextOptions<DataMhsContext> options) : base(options)
        {


        }

        public DbSet<MahasiswaClass> Mahasiswa { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MahasiswaClass>().ToTable("MST_MHS_AKTIF");
        }


    }
}
