using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mahasiswa.Services.Models
{
    public class ProdiClass
    {
        [Key]
        public string id_prodi { get; set; }
        public byte id_fakultas { get; set; }
        public string prodi { get; set; }
        public string prodi_ing { get; set; }
        public string kdprodidikti { get; set; }
        public string jenjang { get; set; }
        public string bhs { get; set; }
    }
}
