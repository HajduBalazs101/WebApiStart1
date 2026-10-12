using MySql.Data.MySqlClient;
using WebApiStart1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace WebApiStart1.Services
{
    public class GyogyszerService : Gyogyszer
    {
        public List<Gyogyszer> GetAllGyogyszer()
        {
            try
            {
                List<Gyogyszer> gyogyszerek = new List<Gyogyszer>();
                string connectionString = "SERVER = localhost;" +
                              "DATABASE= patika;" +
                              "UID = root;" +
                              "PASSWORD =;";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string sql = "SELECT * FROM gyogyszer";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Gyogyszer gyogyszer = new Gyogyszer();
                    gyogyszer.Id = reader.GetInt32("Id");
                    gyogyszer.Nev = reader.GetString("Nev");
                    gyogyszer.Hatoanyag = reader.GetString("Hatoanyag");
                    gyogyszer.Venykoteles = reader.GetBoolean("Venykoteles");
                    gyogyszer.kepnev = reader.GetString("kepnev");
                    gyogyszerek.Add(gyogyszer);
                }
                conn.Close();
                return gyogyszerek;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Gyogyszer GetById(int id)
        {
            try
            {
                Gyogyszer result = null;

                string connectionString = "SERVER = localhost;" +
                                 "DATABASE= patika;" +
                                 "UID = root;" +
                                 "PASSWORD =;";
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string sql = "SELECT * FROM gyogyszer WHERE Id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = new Gyogyszer();
                    result.Id = reader.GetInt32("Id");
                    result.Nev = reader.GetString("Nev");
                    result.Hatoanyag = reader.GetString("Hatoanyag");
                    result.Venykoteles = reader.GetBoolean("Venykoteles");
                    result.kepnev = reader.GetString("kepnev");
                }
                else
                {
                    Console.WriteLine("Nincs ilyen gyógyszer!");
                }
                conn.Close();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
                //Console.WriteLine("Hiba történt az adatok lekérdezése során: " + ex.Message);
                //return null;
            }
        }
    }
}
