using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
        public ActionResult Login(Utente u)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand("Select * FROM Utenti WHERE Username=@Username And Password=@Password", conn);
                sqlCommand.Parameters.AddWithValue("Username", u.Username);
                sqlCommand.Parameters.AddWithValue("Password", u.Password);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    FormsAuthentication.SetAuthCookie(u.Username, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Errore = "Utente non trovato";
                    return View();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}