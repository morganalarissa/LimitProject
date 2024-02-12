namespace LimitProject.Web.Models
{
    public class ClientViewModel
    {
        public int ClientId { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public int AgencyNumber { get; set; }
        public int AccountNumber { get; set; }
        public decimal MaximumLimit { get; set; }
        public decimal CurrentLimit { get; set; }
        public DateTime DateTransaction { get; set; } = DateTime.Now;
    }
}
