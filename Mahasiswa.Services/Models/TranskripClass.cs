using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mahasiswa.Services.Models
{
    public class TranskripClass
    {


        public int id_transkrip { get; set; }
        [Key]
        public String npm { get; set; }
        public Decimal? ipk { get; set; }
        public Int16? id_kurikulum { get; set; }
        public Decimal? ips { get; set; }
        public bool islast { get; set; }


    }
}
