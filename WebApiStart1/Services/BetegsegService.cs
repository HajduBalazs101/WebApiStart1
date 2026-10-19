using MySql.Data.MySqlClient;
using WebApiStart1.Models;

namespace WebApiStart1.Services
{
    public class BetegsegService
    {
        #region GetallBetegseg
        public List<Betegseg> GetAllBetegseg()
        {
            try
            {
                List<Betegseg> betegsegek = new List<Betegseg>();
                string connectionString = "SERVER = localhost;" +
                              "DATABASE= patika;" +
                              "UID = root;" +
                              "PASSWORD =;";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string sql = "SELECT * FROM betegseg";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Betegseg betegseg = new Betegseg();
                    betegseg.Id = reader.GetInt32("Id");
                    betegseg.Megnevezes = reader.GetString("Megnevezes");
                    betegseg.Leiras = reader.GetString("Leiras");
                    betegsegek.Add(betegseg);
                }
                conn.Close();
                return betegsegek;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion

        #region GetById
        public Betegseg GetById(int id)
        {
            try
            {
                Betegseg result = null;

                string connectionString = "SERVER = localhost;" +
                                 "DATABASE= patika;" +
                                 "UID = root;" +
                                 "PASSWORD =;";
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string sql = "SELECT * FROM betegseg WHERE Id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = new Betegseg();
                    result.Id = reader.GetInt32("Id");
                    result.Megnevezes = reader.GetString("Megnevezes");
                    result.Leiras = reader.GetString("Leiras");
                }
                else
                {
                    Console.WriteLine("Nincs ilyen betegség!");
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
            #endregion
    }
}
