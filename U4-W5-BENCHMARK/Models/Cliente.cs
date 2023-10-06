using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace U4_W5_BENCHMARK.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string CF { get; set; }

        [Display(Name = "Città")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Citta { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Cellulare { get; set; }
        
    }
}