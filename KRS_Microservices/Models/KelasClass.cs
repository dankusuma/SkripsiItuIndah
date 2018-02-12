using Kelas.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.Services.Models
{
    public class KelasClass
    {
        [Key]
        public int id_kelas { set; get; }
        public string id_prodi_buat { set; get; }
        public int id_mk { set; get; }
        public string kelas { set; get; }
        public string bhs { set; get; }
        public Int16 id_tahun_akademik { set; get; }
        public byte no_semester { set; get; }
        public string kode_mk { set; get; }
        public string nama_mk { set; get; }
        public string nama_mk_eng { set; get; }
        public byte sks { set; get; }
        public string npp_dosen1 { set; get; }
        public string npp_dosen2 { set; get; }
        public string npp_dosen3 { set; get; }
        public string npp_dosen4 { set; get; }
        public byte? id_hari1 { set; get; }
        public byte? id_hari2 { set; get; }
        public byte? id_hari3 { set; get; }
        public byte? id_hari4 { set; get; }
        public Int16? id_sesi_kuliah1 { set; get; }
        public Int16? id_sesi_kuliah2 { set; get; }
        public Int16? id_sesi_kuliah3 { set; get; }
        public Int16? id_sesi_kuliah4 { set; get; }
        public DateTime? tanggal_uts { set; get; }
        public DateTime? tanggal_uas { set; get; }
        public string ruang1 { set; get; }
        public string ruang2 { set; get; }
        public string ruang3 { set; get; }
        public string ruang4 { set; get; }
        public Int16 kapasitas_kelas { set; get; }
        public bool? iscurrent { set; get; }
        public bool? isbatal { set; get; }

        [ForeignKey("npp_dosen1")]
        public virtual DosenClass dosen1 { get; set; }
        [ForeignKey("npp_dosen2")]
        public virtual DosenClass dosen2 { get; set; }
        [ForeignKey("npp_dosen3")]
        public virtual DosenClass dosen3 { get; set; }
        [ForeignKey("npp_dosen4")]
        public virtual DosenClass dosen4 { get; set; }





    }
}
