using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace U4_W5_BENCHMARK.Models
{
    public static class DB
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
        public static SqlConnection conn = new SqlConnection(connectionString);

        public static Utente GetUtente(Utente u)
        {
            SqlCommand sqlCommand = new SqlCommand("Select * FROM Utenti WHERE Username=@Username And Password=@Password", conn);
            sqlCommand.Parameters.AddWithValue("Username", u.Username);
            sqlCommand.Parameters.AddWithValue("Password", u.Password);
            conn.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                conn.Close();
                return u;
            }
            conn.Close();
            return null;
        }

        public static void AddCliente(Cliente c)
        {
            SqlCommand cmd = new SqlCommand("Insert INTO Clienti Values(@Nome, @Cognome, @CF, @Citta, @Provincia, @Email, @Telefono, @Cellulare)", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("Nome", c.Nome);
            cmd.Parameters.AddWithValue("Cognome", c.Cognome);
            cmd.Parameters.AddWithValue("CF", c.CF);
            cmd.Parameters.AddWithValue("Citta", c.Citta);
            cmd.Parameters.AddWithValue("Provincia", c.Provincia);
            cmd.Parameters.AddWithValue("Email", c.Email);
            cmd.Parameters.AddWithValue("Telefono", c.Telefono);
            cmd.Parameters.AddWithValue("Cellulare", c.Cellulare);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Cliente> getClienti()
        {
            List<Cliente> lista = new List<Cliente>();
            SqlCommand cmd = new SqlCommand("select * from Clienti", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Cliente utente = new Cliente();
                utente.IdCliente = Convert.ToInt32(sqlDataReader["IdCliente"]);
                utente.Nome = sqlDataReader["Nome"].ToString();
                utente.Cognome = sqlDataReader["Cognome"].ToString();
                utente.CF = sqlDataReader["CF"].ToString();
                utente.Citta = sqlDataReader["Citta"].ToString();
                utente.Provincia = sqlDataReader["Provincia"].ToString();
                utente.Email = sqlDataReader["Email"].ToString();
                utente.Telefono = sqlDataReader["Telefono"].ToString();
                utente.Cellulare = sqlDataReader["Cellulare"].ToString();
                lista.Add(utente);
            }
            conn.Close();
            return lista;
        }

        public static void deleteCliente(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete from Clienti where IdCliente = @IdCliente", conn);
            cmd.Parameters.AddWithValue("IdCliente", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void EditCliente(Cliente p)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Clienti SET Nome = @Nome, Cognome = @Cognome, CF = @CF, Citta = @Citta, Provincia = @Provincia, Email = @Email, Telefono = @Telefono, Cellulare = @Cellulare where IdCliente = @IdCliente", conn);
            cmd.Parameters.AddWithValue("IdCliente", p.IdCliente);
            cmd.Parameters.AddWithValue("Nome", p.Nome);
            cmd.Parameters.AddWithValue("Cognome", p.Cognome);
            cmd.Parameters.AddWithValue("CF", p.CF);
            cmd.Parameters.AddWithValue("Citta", p.Citta);
            cmd.Parameters.AddWithValue("Provincia", p.Provincia);
            cmd.Parameters.AddWithValue("Email", p.Email);
            cmd.Parameters.AddWithValue("Telefono", p.Telefono);
            cmd.Parameters.AddWithValue("Cellulare", p.Cellulare);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Camera> getCamere()
        {
            List<Camera> lista = new List<Camera>();
            SqlCommand cmd = new SqlCommand("select * from Camere", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Camera utente = new Camera();
                utente.IdCamera = Convert.ToInt32(sqlDataReader["IdCamera"]);
                utente.NumeroCamera = Convert.ToInt32(sqlDataReader["NumeroCamera"]);
                utente.Descrizione = sqlDataReader["Descrizione"].ToString();
                utente.Tipologia = Convert.ToBoolean(sqlDataReader["Tipologia"]);
                lista.Add(utente);
            }
            conn.Close();
            return lista;
        }

        public static void AddCamera(Camera c)
        {
            SqlCommand cmd = new SqlCommand("Insert INTO Camere Values(@NumeroCamera, @Descrizione, @Tipologia)", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("NumeroCamera", c.NumeroCamera);
            cmd.Parameters.AddWithValue("Descrizione", c.Descrizione);
            cmd.Parameters.AddWithValue("Tipologia", c.Tipologia);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public static void deleteCamera(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete from Camere where IdCamera = @IdCamera", conn);
            cmd.Parameters.AddWithValue("IdCamera", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void EditCamera(Camera p)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Camere SET NumeroCamera = @NumeroCamera, Descrizione = @Descrizione, Tipologia = @Tipologia where IdCamera = @IdCamera", conn);
            cmd.Parameters.AddWithValue("IdCamera", p.IdCamera);
            cmd.Parameters.AddWithValue("NumeroCamera", p.NumeroCamera);
            cmd.Parameters.AddWithValue("Descrizione", p.Descrizione);
            cmd.Parameters.AddWithValue("Tipologia", p.Tipologia);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Prenotazione> getPrenotazioni()
        {
            List<Prenotazione> lista = new List<Prenotazione>();
            SqlCommand cmd = new SqlCommand("select *, Nome, Cognome, NumeroCamera from Prenotazioni Inner JOIN Clienti ON Prenotazioni.IdCliente = Clienti.IdCliente Inner JOIN Camere ON Prenotazioni.IdCamera = Camere.IdCamera", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Prenotazione utente = new Prenotazione();
                utente.IdPrenotazione = Convert.ToInt32(sqlDataReader["IdPrenotazione"]);
                utente.DataPrenotazione = Convert.ToDateTime(sqlDataReader["DataPrenotazione"]);
                utente.Anno = Convert.ToInt32(sqlDataReader["Anno"]);
                utente.InizioSoggiorno = Convert.ToDateTime(sqlDataReader["InizioSoggiorno"]);
                utente.FineSoggiorno = Convert.ToDateTime(sqlDataReader["FineSoggiorno"]);
                utente.Caparra = Convert.ToInt32(sqlDataReader["Caparra"]);
                utente.Tariffa = Convert.ToInt32(sqlDataReader["Tariffa"]);
                utente.TipologiaSoggiorno = sqlDataReader["TipologiaSoggiorno"].ToString();
                utente.IdCliente = $"{sqlDataReader["Cognome"].ToString()}, {sqlDataReader["Nome"].ToString()}";
                utente.IdCamera = sqlDataReader["NumeroCamera"].ToString();
                lista.Add(utente);
            }
            conn.Close();
            return lista;
        }

        public static void AddPrenotazione(Prenotazione c)
        {
            SqlCommand cmd = new SqlCommand("Insert INTO Prenotazioni Values(@DataPrenotazione, @Anno, @InizioSoggiorno, @FineSoggiorno, @Caparra, @Tariffa, @TipologiaSoggiorno, @IdCliente, @IdCamera)", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("DataPrenotazione", c.DataPrenotazione);
            cmd.Parameters.AddWithValue("Anno", c.Anno);
            cmd.Parameters.AddWithValue("InizioSoggiorno", c.InizioSoggiorno);
            cmd.Parameters.AddWithValue("FineSoggiorno", c.FineSoggiorno);
            cmd.Parameters.AddWithValue("Caparra", c.Caparra);
            cmd.Parameters.AddWithValue("Tariffa", c.Tariffa);
            cmd.Parameters.AddWithValue("TipologiaSoggiorno", c.TipologiaSoggiorno);
            cmd.Parameters.AddWithValue("IdCliente", c.IdCliente);
            cmd.Parameters.AddWithValue("IdCamera", c.IdCamera);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void deletePrenotazione(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete from Prenotazioni where IdPrenotazione = @IdPrenotazione", conn);
            cmd.Parameters.AddWithValue("IdPrenotazione", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void EditPrenotazione(Prenotazione p)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Prenotazioni SET DataPrenotazione = @DataPrenotazione, Anno = @Anno, InizioSoggiorno = @InizioSoggiorno, FineSoggiorno = @FineSoggiorno, Caparra = @Caparra, Tariffa = @Tariffa, TipologiaSoggiorno = @TipologiaSoggiorno, IdCliente = @IdCliente, IdCamera = @IdCamera where IdPrenotazione = @IdPrenotazione", conn);
            cmd.Parameters.AddWithValue("IdPrenotazione", p.IdPrenotazione);
            cmd.Parameters.AddWithValue("DataPrenotazione", p.DataPrenotazione);
            cmd.Parameters.AddWithValue("Anno", p.Anno);
            cmd.Parameters.AddWithValue("InizioSoggiorno", p.InizioSoggiorno);
            cmd.Parameters.AddWithValue("FineSoggiorno", p.FineSoggiorno);
            cmd.Parameters.AddWithValue("Caparra", p.Caparra);
            cmd.Parameters.AddWithValue("Tariffa", p.Tariffa);
            cmd.Parameters.AddWithValue("TipologiaSoggiorno", p.TipologiaSoggiorno);
            cmd.Parameters.AddWithValue("IdCliente", p.IdCliente);
            cmd.Parameters.AddWithValue("IdCamera", p.IdCamera);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Servizio> getServizi(int id)
        {
            List<Servizio> lista = new List<Servizio>();
            SqlCommand cmd = new SqlCommand("select * from Servizi where IdPrenotazione=@IdPrenotazione", conn);
            cmd.Parameters.AddWithValue("IdPrenotazione", id);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Servizio utente = new Servizio();
                utente.IdServizio = Convert.ToInt32(sqlDataReader["IdServizio"]);
                utente.DataServizio = Convert.ToDateTime(sqlDataReader["DataServizio"]);
                utente.Quantita = Convert.ToInt32(sqlDataReader["Quantita"]);
                utente.ServizioAggiunto = sqlDataReader["ServizioAggiunto"].ToString();
                utente.PrezzoServizio = Convert.ToInt32(sqlDataReader["PrezzoServizio"]);
                utente.IdPrenotazione = Convert.ToInt32(sqlDataReader["IdPrenotazione"]);
                lista.Add(utente);
            }
            conn.Close();
            return lista;
        }

        public static List<Servizio> getServizio(int id)
        {
            List<Servizio> lista = new List<Servizio>();
            SqlCommand cmd = new SqlCommand("select * from Servizi where IdServizio=@IdServizio", conn);
            cmd.Parameters.AddWithValue("IdServizio", id);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Servizio utente = new Servizio();
                utente.IdServizio = Convert.ToInt32(sqlDataReader["IdServizio"]);
                utente.DataServizio = Convert.ToDateTime(sqlDataReader["DataServizio"]);
                utente.Quantita = Convert.ToInt32(sqlDataReader["Quantita"]);
                utente.ServizioAggiunto = sqlDataReader["ServizioAggiunto"].ToString();
                utente.PrezzoServizio = Convert.ToInt32(sqlDataReader["PrezzoServizio"]);
                utente.IdPrenotazione = Convert.ToInt32(sqlDataReader["IdPrenotazione"]);
                lista.Add(utente);
            }
            conn.Close();
            return lista;
        }

        public static void AddServizio(Servizio c)
        {
            SqlCommand cmd = new SqlCommand("Insert INTO Servizi Values(@ServizioAggiunto, @DataServizio, @Quantita, @PrezzoServizio, @IdPrenotazione)", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("ServizioAggiunto", c.ServizioAggiunto);
            cmd.Parameters.AddWithValue("DataServizio", c.DataServizio);
            cmd.Parameters.AddWithValue("Quantita", c.Quantita);
            cmd.Parameters.AddWithValue("PrezzoServizio", c.PrezzoServizio);
            cmd.Parameters.AddWithValue("IdPrenotazione", c.IdPrenotazione);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void deleteServizio(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete from Servizi where IdServizio = @IdServizio", conn);
            cmd.Parameters.AddWithValue("IdServizio", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void EditServizio(Servizio p)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Servizi SET ServizioAggiunto = @ServizioAggiunto, DataServizio = @DataServizio, Quantita = @Quantita, PrezzoServizio = @PrezzoServizio, IdPrenotazione = @IdPrenotazione where IdServizio = @IdServizio", conn);
            cmd.Parameters.AddWithValue("IdServizio", p.IdServizio);
            cmd.Parameters.AddWithValue("ServizioAggiunto", p.ServizioAggiunto);
            cmd.Parameters.AddWithValue("DataServizio", p.DataServizio);
            cmd.Parameters.AddWithValue("Quantita", p.Quantita);
            cmd.Parameters.AddWithValue("PrezzoServizio", p.PrezzoServizio);
            cmd.Parameters.AddWithValue("IdPrenotazione", p.IdPrenotazione);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Prenotazione> getPrenotazioneByCF(string cf)
        {
            List<Prenotazione> lista = new List<Prenotazione>();
            SqlCommand cmd = new SqlCommand("select *, Nome, Cognome, NumeroCamera from Prenotazioni Inner JOIN Clienti ON Prenotazioni.IdCliente = Clienti.IdCliente Inner JOIN Camere ON Prenotazioni.IdCamera = Camere.IdCamera where Prenotazioni.IdCliente=(select IdCliente from Clienti where CF=@CF)", conn);
            cmd.Parameters.AddWithValue("CF", cf);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Prenotazione utente = new Prenotazione();
                utente.IdPrenotazione = Convert.ToInt32(sqlDataReader["IdPrenotazione"]);
                utente.DataPrenotazione = Convert.ToDateTime(sqlDataReader["DataPrenotazione"]);
                utente.Anno = Convert.ToInt32(sqlDataReader["Anno"]);
                utente.InizioSoggiorno = Convert.ToDateTime(sqlDataReader["InizioSoggiorno"]);
                utente.FineSoggiorno = Convert.ToDateTime(sqlDataReader["FineSoggiorno"]);
                utente.Caparra = Convert.ToInt32(sqlDataReader["Caparra"]);
                utente.Tariffa = Convert.ToInt32(sqlDataReader["Tariffa"]);
                utente.TipologiaSoggiorno = sqlDataReader["TipologiaSoggiorno"].ToString();
                utente.IdCliente = $"{sqlDataReader["Cognome"].ToString()}, {sqlDataReader["Nome"].ToString()}";
                utente.IdCamera = sqlDataReader["NumeroCamera"].ToString();
                lista.Add(utente);
            }
            conn.Close();
            return lista;
        }

        public static List<Prenotazione> getPrenotazionePensioneCompleta()
        {
            List<Prenotazione> lista = new List<Prenotazione>();
            SqlCommand cmd = new SqlCommand("select *, Nome, Cognome, NumeroCamera from Prenotazioni Inner JOIN Clienti ON Prenotazioni.IdCliente = Clienti.IdCliente Inner JOIN Camere ON Prenotazioni.IdCamera = Camere.IdCamera where TipologiaSoggiorno = 'Pensione completa'", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Prenotazione utente = new Prenotazione();
                utente.IdPrenotazione = Convert.ToInt32(sqlDataReader["IdPrenotazione"]);
                utente.DataPrenotazione = Convert.ToDateTime(sqlDataReader["DataPrenotazione"]);
                utente.Anno = Convert.ToInt32(sqlDataReader["Anno"]);
                utente.InizioSoggiorno = Convert.ToDateTime(sqlDataReader["InizioSoggiorno"]);
                utente.FineSoggiorno = Convert.ToDateTime(sqlDataReader["FineSoggiorno"]);
                utente.Caparra = Convert.ToInt32(sqlDataReader["Caparra"]);
                utente.Tariffa = Convert.ToInt32(sqlDataReader["Tariffa"]);
                utente.TipologiaSoggiorno = sqlDataReader["TipologiaSoggiorno"].ToString();
                utente.IdCliente = $"{sqlDataReader["Cognome"].ToString()}, {sqlDataReader["Nome"].ToString()}";
                utente.IdCamera = sqlDataReader["NumeroCamera"].ToString();
                lista.Add(utente);
            }
            conn.Close();
            return lista;
        }
    }
}