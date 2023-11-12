namespace OnyxTestApp.Models
{
    public class TravelAgentInfo
    {
        public string TravelAgent { get; set; }
        public int TotalNumberOfNights { get; set; }

        public static List<TravelAgentInfo> CreateTestData()
        {
            var travelAgentInfo1 = new TravelAgentInfo
            {
                TravelAgent = "Travel Agent 1",
                TotalNumberOfNights = 10
            };
            var travelAgentInfo2 = new TravelAgentInfo
            {
                TravelAgent = "Travel Agent 2",
                TotalNumberOfNights = 8
            };

            List<TravelAgentInfo> travelAgentInfos = new() { travelAgentInfo1, travelAgentInfo2 };

            return travelAgentInfos;
        }
    }
}


