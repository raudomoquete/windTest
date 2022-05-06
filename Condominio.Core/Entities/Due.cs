namespace Condominio.Core.Entities
{
    public class Due : BaseEntity
    {
        public int DueId { get; set; }

        public int ClientId { get; set; }

        public int Number { get; set; }

        public int Value { get; set; }

        public virtual Client Client { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
