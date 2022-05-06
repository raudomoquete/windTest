using System.Collections.Generic;

namespace Condominio.Core.Entities
{
    public class Client : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Residential> Residentials { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Due> Dues { get; set; }

    }
}
