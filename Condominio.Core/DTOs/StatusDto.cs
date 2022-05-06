using System;

namespace Condominio.Core.DTOs
{
    public class StatusDto
    {
        public int Id { get; set; }

        public int PaymentId { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }
    }
}
