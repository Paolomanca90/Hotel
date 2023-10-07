using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U4_W5_BENCHMARK.Models;

namespace U4_W5_BENCHMARK.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public List<SelectListItem> AnagraficaCliente
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                List<Cliente> lista = new List<Cliente>();
                lista = DB.getClienti();
                foreach (Cliente p in lista)
                {
                    SelectListItem item = new SelectListItem { Text = $"{p.Cognome}, {p.Nome}", Value = $"{p.IdCliente}" };
                    list.Add(item);
                }
                return list;
            }
        }

        public List<SelectListItem> ListaCamere
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                List<Camera> lista = new List<Camera>();
                lista = DB.getCamere();
                foreach (Camera a in lista)
                {
                    SelectListItem item = new SelectListItem { Text = $"{a.NumeroCamera}", Value = $"{a.IdCamera}" };
                    list.Add(item);
                }
                return list;
            }
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetClienti()
        {
            List<Cliente> lista = new List<Cliente>();
            lista = DB.getClienti();
            return View(lista);
        }

        public ActionResult AddCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCliente(Cliente c)
        {
            if (ModelState.IsValid)
            {
                DB.AddCliente(c);
                TempData["Successo"] = "Cliente aggiunto con successo";
                return RedirectToAction("GetClienti");
            }
            ViewBag.Errore = "Errore durante la procedura";
            return View();
        }

        public ActionResult DeleteCliente(int id)
        {
            DB.deleteCliente(id);
            TempData["Eliminazione"] = "Utente eliminato con successo.";
            return RedirectToAction("GetClienti");
        }

        public ActionResult EditCliente(int id)
        {
            List<Cliente> lista = new List<Cliente>();
            lista = DB.getClienti();
            Cliente selected = new Cliente();
            foreach (Cliente p in lista)
            {
                if (p.IdCliente == id)
                {
                    selected = p;
                    break;
                }
            }
            return View(selected);
        }

        [HttpPost]
        public ActionResult EditCliente(Cliente p)
        {
            int idC = Convert.ToInt16(TempData["IdCliente"]);
            List<Cliente> lista = new List<Cliente>();
            lista = DB.getClienti();
            foreach (Cliente cliente in lista)
            {
                if (cliente.IdCliente == idC)
                {
                    p.IdCliente = cliente.IdCliente;
                    break;
                }
            }
            if (ModelState.IsValid)
            {
                DB.EditCliente(p);
                TempData["Salvataggio"] = "Modifica effettuata";
                return RedirectToAction("GetClienti");
            }
            else
            {
                ViewBag.MessaggioErrore = "Modifica non riuscita";
                return View();
            }
        }

        public ActionResult GetCamere()
        {
            List<Camera> lista = new List<Camera>();
            lista = DB.getCamere();
            return View(lista);
        }

        public ActionResult AddCamera()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCamera(Camera c)
        {
            if (ModelState.IsValid)
            {
                DB.AddCamera(c);
                TempData["Successo"] = "Cliente aggiunto con successo";
                return RedirectToAction("GetCamere");
            }
            ViewBag.Errore = "Errore durante la procedura";
            return View();
        }

        public ActionResult DeleteCamera(int id)
        {
            DB.deleteCamera(id);
            TempData["Eliminazione"] = "Utente eliminato con successo.";
            return RedirectToAction("GetCamere");
        }

        public ActionResult EditCamera(int id)
        {
            List<Camera> lista = new List<Camera>();
            lista = DB.getCamere();
            Camera selected = new Camera();
            foreach (Camera p in lista)
            {
                if (p.IdCamera == id)
                {
                    selected = p;
                    break;
                }
            }
            return View(selected);
        }

        [HttpPost]
        public ActionResult EditCamera(Camera p)
        {
            int idC = Convert.ToInt16(TempData["IdCamera"]);
            List<Camera> lista = new List<Camera>();
            lista = DB.getCamere();
            foreach (Camera camera in lista)
            {
                if (camera.IdCamera == idC)
                {
                    p.IdCamera = camera.IdCamera;
                    break;
                }
            }
            if (ModelState.IsValid)
            {
                DB.EditCamera(p);
                TempData["Salvataggio"] = "Modifica effettuata";
                return RedirectToAction("GetCamere");
            }
            else
            {
                ViewBag.MessaggioErrore = "Modifica non riuscita";
                return View();
            }
        }

        public ActionResult GetPrenotazioni()
        {
            List<Prenotazione> lista = new List<Prenotazione>();
            lista = DB.getPrenotazioni();
            return View(lista);
        }

        public ActionResult AddPrenotazione()
        {
            ViewBag.AnagraficaCliente = AnagraficaCliente;
            ViewBag.ListaCamere = ListaCamere;
            return View();
        }

        [HttpPost]
        public ActionResult AddPrenotazione(Prenotazione c)
        {
            if (ModelState.IsValid)
            {
                DB.AddPrenotazione(c);
                TempData["Successo"] = "Prenotazione aggiunta con successo";
                return RedirectToAction("GetPrenotazioni");
            }
            ViewBag.Errore = "Errore durante la procedura";
            return View();
        }

        public ActionResult DeletePrenotazione(int id)
        {
            DB.deletePrenotazione(id);
            TempData["Eliminazione"] = "Prenotazione eliminata con successo.";
            return RedirectToAction("GetPrenotazioni");
        }

        public ActionResult EditPrenotazione(int id)
        {
            ViewBag.AnagraficaCliente = AnagraficaCliente;
            ViewBag.ListaCamere = ListaCamere;
            List<Prenotazione> lista = new List<Prenotazione>();
            lista = DB.getPrenotazioni();
            Prenotazione selected = new Prenotazione();
            foreach (Prenotazione p in lista)
            {
                if (p.IdPrenotazione == id)
                {
                    selected = p;
                    break;
                }
            }
            return View(selected);
        }

        [HttpPost]
        public ActionResult EditPrenotazione(Prenotazione p)
        {
            int idC = Convert.ToInt16(TempData["IdPrenotazione"]);
            List<Prenotazione> lista = new List<Prenotazione>();
            lista = DB.getPrenotazioni();
            foreach (Prenotazione pren in lista)
            {
                if (pren.IdPrenotazione == idC)
                {
                    p.IdPrenotazione = pren.IdPrenotazione;
                    break;
                }
            }
            if (ModelState.IsValid)
            {
                DB.EditPrenotazione(p);
                TempData["Salvataggio"] = "Modifica effettuata";
                return RedirectToAction("GetPrenotazioni");
            }
            else
            {
                ViewBag.MessaggioErrore = "Modifica non riuscita";
                return View();
            }
        }

        public ActionResult GetServizi(int id)
        {
            List<Servizio> lista = new List<Servizio>();
            lista = DB.getServizi(id);
            return View(lista);
        }

        public ActionResult AddServizio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddServizio(Servizio c)
        {
            if (ModelState.IsValid)
            {
                DB.AddServizio(c);
                TempData["Successo"] = "Servizio aggiunto con successo";
                return RedirectToAction("GetPrenotazioni");
            }
            ViewBag.Errore = "Errore durante la procedura";
            return View();
        }

        public ActionResult DeleteServizio(int id)
        {
            DB.deleteServizio(id);
            TempData["Eliminazione"] = "Servizio eliminato con successo.";
            return RedirectToAction("GetPrenotazioni");
        }

        public ActionResult EditServizio(int id)
        {
            List<Servizio> lista = new List<Servizio>();
            lista = DB.getServizio(id);
            Servizio selected = new Servizio();
            foreach (Servizio p in lista)
            {
                if (p.IdServizio == id)
                {
                    selected = p;
                    break;
                }
            }
            return View(selected);
        }

        [HttpPost]
        public ActionResult EditServizio(Servizio p)
        {
            int idC = Convert.ToInt16(TempData["IdServizio"]);
            List<Servizio> lista = new List<Servizio>();
            lista = DB.getServizio(idC);
            foreach (Servizio pren in lista)
            {
                if (pren.IdServizio == idC)
                {
                    p.IdServizio = pren.IdServizio;
                    break;
                }
            }
            if (ModelState.IsValid)
            {
                DB.EditServizio(p);
                TempData["Salvataggio"] = "Modifica effettuata";
                return RedirectToAction("GetPrenotazioni");
            }
            else
            {
                ViewBag.MessaggioErrore = "Modifica non riuscita";
                return View();
            }
        }

        public ActionResult Checkout(int id)
        {
            List<Prenotazione> lista = new List<Prenotazione>();
            lista = DB.getPrenotazioni();
            Prenotazione selected = new Prenotazione();
            foreach(Prenotazione p in lista)
            {
                if(p.IdPrenotazione == id)
                {
                    selected = p;
                    break;
                }
            }
            ViewBag.Info = selected;
            List<Servizio> lista1 = new List<Servizio>();
            lista1 = DB.getServizi(id);
            int totaleServizi = 0;
            foreach(Servizio s in lista1)
            {
                totaleServizi += s.PrezzoServizio;
            }
            ViewBag.Servizi = lista1;
            ViewBag.CostoServizi = totaleServizi;
            ViewBag.Totale = selected.Tariffa - selected.Caparra + totaleServizi;
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult getPrenotazioneByCF(string cf)
        {
            List<Prenotazione> lista = DB.getPrenotazioneByCF(cf);
            return Json(lista);
        }

        public ActionResult getPrenotazionePensioneCompleta()
        {
            List<Prenotazione> lista = DB.getPrenotazionePensioneCompleta();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}