using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mahasiswa.Services.Models
{
 
    public class MahasiswaClass
    {

        [Key] public string NPM { get; set; }
       public string KD_CALON { get; set; }
        public string ID_FAKULTAS { get; set; }
        public string ID_PRODI { get; set; }
       public string ID_KONSENTRASI { get; set; }
       public string NOMHS { get; set; }
       public string NAMA_MHS { get; set; }
       public string THN_MASUK { get; set; }
       public string JNS_KEL { get; set; }
       public string TMP_LAHIR { get; set; }
       public string PASSWORD { get; set; }
       public string KD_STATUS_MHS { get; set; }
       public string NPP_PEMBIMBING_AKADEMIK { get; set; }
       public bool ISMASUKMIDDLE { get; set; }
       public string ALAMAT { get; set; }
       public string PASSWORD1 { get; set; }
       public string PASSWORD2 { get; set; }
       public string ID_PROGRAM { get; set; }
       public string ID_ORTU { get; set; }
       public string PASSWORD_ORTU { get; set; }
       public bool IS_SUDAH_KIRIM { get; set; }


        [ForeignKey("ID_Prodi")]
        public virtual ProdiClass PRODI { get; set; }

        [ForeignKey("ID_Fakultas")]
        public virtual FakultasClass FAKULTAS { get; set; }
        [ForeignKey("NPM")]
        public virtual TranskripClass TRANSKRIP { get; set; }

    }
}
