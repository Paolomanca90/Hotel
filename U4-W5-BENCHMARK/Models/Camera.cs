using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace U4_W5_BENCHMARK.Models
{
    public class Camera
    {
        public int IdCamera { get; set; }

        [Display(Name = "Numero Camera")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public int NumeroCamera { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Descrizione { get; set; }

        [Display(Name = "Doppia")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public bool Tipologia { get; set; }
    }
}