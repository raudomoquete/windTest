using System.Collections.Generic;

namespace Condominio.Core.Entities
{
    public class Payment : BaseEntity
    {
        public int PaymentId { get; set; }

        public int ClientId { get; set; }

        public int DueId { get; set; }

        public string Currency { get; set; }

        public int Value { get; set; }

        public virtual Status Status{ get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<Due> Dues { get; set; }
    }
}
