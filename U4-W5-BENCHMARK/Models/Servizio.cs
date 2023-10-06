using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace U4_W5_BENCHMARK.Models
{
    public class Servizio
    {
        public int IdServizio { get; set; }

        [Display(Name = "Servizio Aggiunto")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string ServizioAggiunto { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public DateTime DataServizio { get; set; }

        [Display(Name = "Quantità")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public int Quantita { get; set; }

        [Display(Name = "Prezzo")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public int PrezzoServizio { get; set; }

        [Display(Name = "N. Prenotazione")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public int IdPrenotazione { get; set; }
    }
}