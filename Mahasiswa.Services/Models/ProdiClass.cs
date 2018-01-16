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
        public string ID_PRODI { get; set; }
        public string ID_FAKULTAS { get; set; }
        public string PRODI { get; set; }
        public string PRODI_ING { get; set; }
        public string KDPRODIDIKTI { get; set; }
        public string JENJANG { get; set; }
        public string BHS { get; set; }
    }
}
