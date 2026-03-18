namespace NexUs.Models.DTO.Marketing
{
    public class MarketingOverviewDto
    {
        public int TotalLeads { get; set; }
        public int TotalCustomers { get; set; }
        public double ConversionRate { get; set; }
        public int TotalCampaigns { get; set; }
        public int TotalEmailsSent { get; set; }
        public int TotalEmailsFailed { get; set; }
        public double SendSuccessRate { get; set; }
    }
}
