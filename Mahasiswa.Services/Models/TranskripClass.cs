using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mahasiswa.Services.Models
{
    public class TranskripClass
    {
     
        public int ID_TRANSKRIP { get; set; }
        [Key]
        public string NPM { get; set; }
        public double IPK { get; set; }
        public string ID_KURIKULUM { get; set; }
        public double IPS { get; set; }
        public bool ISLAST { get; set; }


    }
}
