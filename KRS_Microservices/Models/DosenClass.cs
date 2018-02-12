using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.Services.Models
{
    public class DosenClass
    {
        [Key]
        public string npp { set; get; }
        public byte? id_jenis_dosen { set; get; }
        public string id_prodi { set; get; }
        public byte id_fakultas { set; get; }
        public string nama_unit { set; get; }
        public string nama_dosen { set; get; }
        public string nama_dosen_lengkap { set; get; }
        public string no_ktp { set; get; }
        public string tempat_lahir { set; get; }
        public DateTime? tgl_lahir { set; get; }
        public string jns_kel { set; get; }
        public string nip_pns { get; set; }
        public string gelar_s1 { set; get; }
        public string gelar_s2 { set; get; }
        public string gelar_s3 { set; get; }
        public string inisial { set; get; }
        public string golongan { set; get; }
        public string jabatan_akademik { set; get; }
        public string kd_status_dosen { set; get; }


    }
}
