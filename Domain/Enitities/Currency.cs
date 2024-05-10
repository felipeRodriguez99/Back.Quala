namespace Domain.Enitities
{
    public class Currency
    {
        public int Id { get; set; }        
        public string Description { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public ICollection<Branch> Branches { get; set; } = new HashSet<Branch>();
    }
}
