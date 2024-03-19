

namespace Persistence.Models
{

    public sealed class Contributor
    {
        public int Id { get; set; }
        public string RncCedula { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Estatus { get; set; }
        public string Active { get; set; }
        public ICollection<TaxReceipt> TaxReceipts { get; set; }

        public Contributor()
        {

        }

    }
}
