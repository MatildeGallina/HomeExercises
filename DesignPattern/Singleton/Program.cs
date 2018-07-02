using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var config = CreateConfiguration();

            var app = new Application(config);

            app.Start();

            Console.Read();
        }

        private static IConfiguration CreateConfiguration()
        {
            var config = Configuration.Instance;

            config.SetConnectionString(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TrainStationDB;Integrated Security=True;Connect Timeout=10;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            config.LogLevel = "Debug";

            return config;
        }
    }

    class Application
    {
        public Application(IConfiguration config)
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; }

        public void Start()
        {
            try
            {
                using (var conn = Configuration.CreateConnection())
                using (var comm = conn.CreateCommand())
                {
                    conn.Open();

                    if (Configuration.LogLevel == "Debug")
                        Console.WriteLine("Connection open");

                    comm.CommandType = System.Data.CommandType.Text;
                    comm.CommandText = "select count(*) from Companies";

                    if (Configuration.LogLevel == "Debug")
                        Console.WriteLine($"Query executed: '{comm.CommandText}'");

                    using (var reader = comm.ExecuteReader())
                    {
                        reader.Read();
                        int count = reader.GetInt32(0);

                        Console.WriteLine($"Companies count is: {count}");
                    }
                }
            }
            catch (Exception ex)
            {
                if (new List<string> { "Debug", "Warning", "Error" }
                    .Any(x => x == Configuration.LogLevel))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error!");
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }

    interface IConfiguration
    {
        void SetConnectionString(string value);
        SqlConnection CreateConnection();
        string LogLevel { get; }
    }

    class Configuration : IConfiguration
    {
        public void SetConnectionString(string value)
        {
            _connectionString = value;
        }
        private string _connectionString;

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public string LogLevel { get; set; }

        #region Singleton
        private Configuration() { } // deve essere private se no chiunque può fare new Configuration

        public static Configuration Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Configuration();

                return _Instance;
            }
        }

        private static Configuration _Instance;
        #endregion
    }
}
    // @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TrainStationDB;Integrated Security=True;Connect Timeout=10;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
