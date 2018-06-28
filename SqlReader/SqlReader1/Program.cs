using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlReader1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(
                @"Data Source=(localdb)\MSSQLLocalDB;Database=TrainStationDB;Integrated Security=True");

            conn.Open();

            SqlCommand comm = conn.CreateCommand();

            comm.CommandType = System.Data.CommandType.Text;
            comm.CommandText = "select * from Departures";

            SqlDataReader reader = comm.ExecuteReader();

            List<Departure> departures = new List<Departure>();

            if(reader.HasRows)
            {
                // due sistemi per leggere le tabelle 
                while (reader.Read())
                {
                    // lavoro col numero delle colonne
                    // problema: il numero delle colonne può essere invertito
                    Departure d = new Departure
                    {
                        Id = reader.GetInt32(0),
                        Time = reader.GetDateTime(1),
                        Rail = reader.GetInt32(2),
                        Destination = reader.IsDBNull(3)
                            ? null
                            : reader.GetString(3),
                        TrainId = reader.GetInt32(4)
                    };

                    // lavoro col nome delle colonne
                    // indexer method
                    // devo fare io il cast
                    d = new Departure
                    {
                        Id = (int)reader["Id"],
                        Time = (DateTime)reader["Time"],
                        Rail = (int)reader["Rail"],
                        Destination = reader["Destination"] == DBNull.Value
                            ? null
                            : (string)reader["Destination"],
                        TrainId = (int)reader["TrainId"]
                    };

                    departures.Add(d);
                }
            }
            else
                Console.WriteLine("There's no rows.");
        }
    }

    class Departure
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int Rail { get; set; }
        public string Destination { get; set; }
        public int TrainId { get; set; }
    }
}
