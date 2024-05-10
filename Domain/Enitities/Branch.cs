namespace Domain.Enitities
{
    public class Branch
    {        
        public int Code { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Identifications { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public int CurrencyId { get; set; }        

    }
}
