namespace MF2024API_2.Models
{
    public class NotReservation
    {
        public int NotReservationId { get; set; }
        public string NotReservationName { get; set; }
        public string NotReservationRequirement { get; set; }
        public string? NotReservationCompanyName { get; set; }

        public virtual ICollection<Nfc> Nfcs { get; set; } = new List<Nfc>();
    }
}
