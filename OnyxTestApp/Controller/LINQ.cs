using OnyxTestApp.Models;

namespace OnyxTestApp.Controller
{
    class OnyxTestMethods
    {
        public static IEnumerable<string> GetRepeatedGuestNames(List<InvoiceGroup> invoiceGroups)
        {
            IEnumerable<string> repeatedGuestNames = invoiceGroups
                .SelectMany(group => group.Invoices)
                .SelectMany(invoice => invoice.Observations)
                .GroupBy(obs => obs.GuestName)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key);

            return repeatedGuestNames;
        }

        public static IEnumerable<TravelAgentInfo> GetTravelAgentNights(List<InvoiceGroup> invoiceGroups, int issueDateYear)
        {
            IEnumerable<TravelAgentInfo> travelAgentNights = invoiceGroups
                .Where(group => group.IssueDate.Year == issueDateYear)
                .SelectMany(group => group.Invoices)
                .SelectMany(invoice => invoice.Observations)
                .GroupBy(obs => obs.TravelAgent)
                .Select(group => new TravelAgentInfo
                {
                    TravelAgent = group.Key,
                    TotalNumberOfNights = group.Sum(obs => obs.NumberOfNights)
                });

            return travelAgentNights;
        }
    }
    
}




