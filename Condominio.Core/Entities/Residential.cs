namespace Condominio.Core.Entities
{
    public class Residential : BaseEntity
    {
        public int ResidentialId { get; set; }

        public int ClientId { get; set; }

        public string Description { get; set; }

        public virtual Client Client { get; set; }
    }
}
