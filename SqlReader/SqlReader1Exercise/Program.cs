using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlReader1Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeTableHandler();

            Console.WriteLine();

            DayResearch();

            Console.Read();
        }

        private static void TimeTableHandler()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(
                            @"Data Source=(localdb)\MSSQLLocalDB;Database=TrainStationDB;Integrated Security=True");
                conn.Open();

                SqlCommand comm = conn.CreateCommand();

                comm.CommandType = System.Data.CommandType.Text;
                comm.CommandText =
                    "select d.Time, t.Name, d.Rail " +
                    "from Departures as d " +
                    "join Trains as t on d.TrainId = t.Id";

                SqlDataReader reader = comm.ExecuteReader();
                List<TimeTable> timeTables = new List<TimeTable>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TimeTable t = new TimeTable
                        {
                            Time = (DateTime)reader["Time"],
                            TrainName = (string)reader["Name"],
                            Rail = (int)reader["Rail"]
                        };

                        timeTables.Add(t);
                    }

                    Console.WriteLine("DEPARTURES");
                    foreach (TimeTable t in timeTables)
                        Console.WriteLine($"Time: {t.Time,10} \t TrainName: {t.TrainName,-22} \t Rail: {t.Rail,3}");
                }
                else
                    Console.WriteLine("There's no trains");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! " + ex.Message);
                throw;
            }
            finally
            {
                conn?.Dispose();
            }
        }

        private static void DayResearch()
        {
            SqlConnection conn = new SqlConnection(
                            @"Data Source=(localdb)\MSSQLLocalDB;Database=TrainStationDB;Integrated Security=True");

            Console.WriteLine("Di quale giorno vuoi fare la ricerca?");

            DateTime d = DayConversion();

            SqlCommand comm1 = conn.CreateCommand();

            comm1.CommandType = System.Data.CommandType.Text;
            comm1.CommandText =
                "select c.Name, inner_result.Count " +
                "from " +
                    "(select CompanyId, count(*) as Count " +
                    "from Trains as t, Departures as d " +
                    $"where cast(d.[Time] as date) = '{d.ToString("yyyy/MM/dd")}' AND d.TrainId = t.Id " +
                    "group by CompanyId) inner_result, " +
                    "Companies as c " +
                    "where c.Id = inner_result.CompanyId ";

            SqlDataReader reader1 = comm1.ExecuteReader();

            List<companyDeparture> companyDepartures = new List<companyDeparture>();

            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    companyDeparture cd = new companyDeparture
                    {
                        Name = (string)reader1["Name"],
                        Count = (int)reader1["Count"]
                    };

                    companyDepartures.Add(cd);
                }

                Console.WriteLine("COMPANY DEPARTURES");
                Console.WriteLine($"{"COMPANY",-35} \t {"DEPARTURES COUNT"}");
                foreach (companyDeparture cd in companyDepartures)
                    Console.WriteLine($"{cd.Name,35} \t {cd.Count,-10}");
            }
            else
                Console.WriteLine("Non ci sono partenze per quel giorno");
        }

        public static DateTime DayConversion()
        {
            DateTime date;
            bool canConvert;

            do
            {
                string input = Console.ReadLine();
                canConvert = DateTime.TryParse(input, out date);

                if (canConvert)
                    break;

                Console.WriteLine("Inserisci una data valida! [AAAA/MM/GG]");
            }
            while (!canConvert);

            return date.Date;
        }
    }

    class TimeTable
    {
        public DateTime Time { get; set; }
        public string TrainName { get; set; }
        public int Rail { get; set; }
    }

    class companyDeparture
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
