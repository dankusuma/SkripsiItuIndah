using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Services.Models
{

    public class MahasiswaClass
    {

        [Key]
        public string npm { get; set; }
        public string password2 { get; set; }




    }
}
