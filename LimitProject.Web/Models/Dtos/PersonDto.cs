namespace LimitProject.Web.Models.Dtos
{
    public class PersonDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Document {  get; set; }
        public decimal Limit { get; set; }
        public decimal CurrentLimit { get; set; }
    }
}
