namespace OnyxTestApp.Models
{
    public class InvoiceGroup
    {
        public DateTime IssueDate { get; set; }
        public List<Invoice> Invoices { get; set; }

        public static List<InvoiceGroup> CreateTestData()
        {
            var invoiceGroup = new InvoiceGroup
            {
                IssueDate = new DateTime(2015, 3, 12),
                Invoices = new List<Invoice>
            {
                new Invoice
                {
                    Observations = new List<Observation>
                    {
                        new Observation
                        {
                            TravelAgent = "Travel Agent 1",
                            GuestName = "Guest 1",
                            NumberOfNights = 2
                        },
                        new Observation
                        {
                            TravelAgent = "Travel Agent 2",
                            GuestName = "Guest 2",
                            NumberOfNights = 3
                        }
                    }
                },
                new Invoice
                {
                    Observations = new List<Observation>
                    {
                        new Observation
                        {
                            TravelAgent = "Travel Agent 1",
                            GuestName = "Guest 1",
                            NumberOfNights = 4
                        },
                        new Observation
                        {
                            TravelAgent = "Travel Agent 2",
                            GuestName = "Guest 2",
                            NumberOfNights = 5
                        },
                        new Observation
                        {
                            TravelAgent = "Travel Agent 2",
                            GuestName = "Guest 3",
                            NumberOfNights = 7
                        }
                    }
                }
            }
            };

            List<InvoiceGroup> invoiceGroups = new() { invoiceGroup };

            return invoiceGroups;
        }
    }

}



