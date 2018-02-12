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
        public Byte id_fakultas { get; set; }
        public string fakultas { get; set; }
        public string alamat_fakultas { get; set; }
        public string telp_fakultas { get; set; }
        public string fax_fakultas { get; set; }

      
        
    }
}
