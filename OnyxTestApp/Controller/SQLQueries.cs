using Microsoft.Data.SqlClient;

namespace OnyxTestApp.Controller
{
    class SQLQueries
    {
        private readonly string _connectionString;

        public SQLQueries(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<string> GetTravelAgentsWithoutObservations()
        {
            var travelAgents = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                    SELECT * FROM TravelAgent
                    LEFT JOIN Observation ON TravelAgent.TravelAgent = Observation.TravelAgent
                    WHERE Observation.TravelAgent IS NULL";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            travelAgents.Add(reader["TravelAgent"].ToString());
                        }
                    }
                }
            }

            return travelAgents;
        }

        public List<string> GetTravelAgentsWithMoreThanTwoObservations()
        {
            var travelAgents = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                    SELECT TravelAgent.TravelAgent, COUNT(*) as ObservationCount
                    FROM TravelAgent
                    JOIN Observation ON TravelAgent.TravelAgent = Observation.TravelAgent
                    GROUP BY TravelAgent.TravelAgent
                    HAVING COUNT(*) > 2";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            travelAgents.Add(reader["TravelAgent"].ToString());
                        }
                    }
                }
            }

            return travelAgents;
        }
    }
}
