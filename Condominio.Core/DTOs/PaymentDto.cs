namespace Condominio.Core.DTOs
{
    public class PaymentDto
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int DueId { get; set; }

        public string Currency { get; set; }

        public int Value { get; set; }
    }
}
