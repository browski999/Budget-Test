namespace DotNetAppSqlDb.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Postcode { get; set; }
    }
}