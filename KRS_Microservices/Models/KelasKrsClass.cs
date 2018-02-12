using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.Services.Models
{
    public class KelasKrsClass
    {
        [Key]
        public int id_kelas { get; set; }
        public string id_prodi_tawar { get; set; }
        public Int16 id_tahun_akademik { get; set; }
        public byte no_semester { get; set; }
        public Int16 kapasitas_tawar { get; set; }
        public Int16 kapasitas_buka { get; set; }
        public int id_mk_map { get; set; }
        public bool isbayangan { get; set; }
        public int? sisa { get; set; }

        [ForeignKey("id_kelas")]
        public virtual KelasClass kelas { get; set; }
        [ForeignKey("id_tahun_akademik")]
        public virtual TahunAkademikClass tahun_akademik { get; set; }



    }
}
