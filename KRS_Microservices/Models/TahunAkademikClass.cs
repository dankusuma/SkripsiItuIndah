using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.Services.Models
{
    public class TahunAkademikClass
    {
        [Key]
        public Int16 id_tahun_akademik { get; set; }
        public string tahun_akademik { get; set; }
        public bool iscurrent { get; set; }

    }
}
