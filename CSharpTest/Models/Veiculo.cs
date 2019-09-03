using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpTest.Models
{
    public class Veiculo
    {
        [Key]
        public int IdVeiculo { get; set; }

        [Required]
        [Display(Name ="Chassi")]
        public string Chassi { get; set; }

        public byte Passageiros { get; set; }

        public string Cor { get; set; }
    }
}