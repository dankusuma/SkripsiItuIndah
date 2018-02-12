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

        [Key]
        public String npm { get; set; }
        public string kd_calon { get; set; }
        public byte id_fakultas { get; set; }
        public string id_prodi { get; set; }
        public Int16? id_konsentrasi { get; set; }
        public string nomhs { get; set; }
        public string nama_mhs { get; set; }
        public Int16 thn_masuk { get; set; }
        public string jns_kel { get; set; }
        public string tmp_lahir { get; set; }
        public DateTime tgl_lahir { get; set; }
        public string password { get; set; }
        public string kd_status_mhs { get; set; }
        public string npp_pembimbing_akademik { get; set; }
        public bool ismasukmiddle { get; set; }
        public string alamat { get; set; }
        public string password1 { get; set; }
        public string password2 { get; set; }
        public int? id_program { get; set; }

       
       [ForeignKey("id_prodi")]
        public virtual ProdiClass prodi { get; set; }
        [ForeignKey("id_fakultas")]
        public virtual FakultasClass fakultas { get; set; }
        [ForeignKey("npm")]
        public virtual TranskripClass transkrip { get; set; }
       

    }
}
