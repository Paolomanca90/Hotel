using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace U4_W5_BENCHMARK.Models
{
    public class Prenotazione
    {
        public int IdPrenotazione { get; set; }

        [Display(Name = "Data Prenotazione")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public DateTime DataPrenotazione { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public int Anno { get; set; }

        [Display(Name = "Inizio Soggiorno")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public DateTime InizioSoggiorno { get; set; }

        [Display(Name = "Fine Soggiorno")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public DateTime FineSoggiorno { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public int Caparra { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public int Tariffa { get; set; }

        [Display(Name = "Tipologia Soggiorno")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string TipologiaSoggiorno { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string IdCliente { get; set; }

        [Display(Name = "Camera")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string IdCamera { get; set; }
    }
}