using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mahasiswa.Services.Models
{
    public class FakultasClass
    {

        [Key]
        public string ID_FAKULTAS { get; set; }
        public string FAKULTAS { get; set; }
        public string ALAMAT_FAKULTAS { get; set; }
        public string TELP_FAKULTAS { get; set; }
        public string FAX_FAKULTAS { get; set; }

      
        
    }
}
