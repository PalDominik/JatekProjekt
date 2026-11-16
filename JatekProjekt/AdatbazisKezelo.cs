using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace JatekProjekt
{

    public class AdatbazisKezelo
    {
        private readonly string connectionString;


        public AdatbazisKezelo()
        {

            this.connectionString = "server=localhost;userid=root;password=;database=jatekdb";// Irjuk meg a connectionstringet a megfelelő adatbázisra hivatkozva
            AdatokBetoltese();

        }

   
        /// Beolvassa az összes karaktert az adatbázisból egy List<Karakter>-be.
       
        public List<Karakter> AdatokBetoltese()
        {
            var karakterek = new List<Karakter>();

            try {

                using (var conn = new MySqlConnection(connectionString)) { 
                    conn.Open();
                    Console.WriteLine("Adatbázis csatlakoás sikeres\nAdatkezelés elkezdése");
                    string query = "SELECT * FROM karakterek";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn)) {
                        using (MySqlDataReader reader = cmd.ExecuteReader()) { 
                            while(reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                string nev = reader.GetString("Nev");
                                string osztaly = reader.GetString("Osztaly");
                                int szint = reader.GetInt32("Szint");
                                int arany = reader.GetInt32("Arany");
                                string szerver = reader.GetString("Szerver");
                                Karakter seged = new Karakter(id,nev, osztaly, szint, arany,szerver);
                                karakterek.Add(seged);
                            }
                        }
                    
                    }
                }

            }catch (Exception err){
                Console.WriteLine($"Baj van {err}");
            }

            return karakterek;
        }
    }
}
