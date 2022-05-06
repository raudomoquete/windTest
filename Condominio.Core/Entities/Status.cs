using System;

namespace Condominio.Core.Entities
{
    public class Status : BaseEntity
    {
        public int PaymentId { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
