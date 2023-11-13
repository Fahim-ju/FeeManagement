namespace firstApi.Models
{
    public class Fine
    {
        public Guid Id { get; set; }

        // reference to Law
        public Guid LawId { get; set; }
        public Law Law { get; set; }
    }
}
