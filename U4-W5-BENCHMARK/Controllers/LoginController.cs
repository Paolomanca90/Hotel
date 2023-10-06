using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U4_W5_BENCHMARK.Models;

namespace U4_W5_BENCHMARK.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Utente u)
        {
            if (ModelState.IsValid)
            {
                DB.GetUtente(u);
                if (User.Identity.Name != "")
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.Errore = "Utente non trovato";
            return View();
        }
    }
}