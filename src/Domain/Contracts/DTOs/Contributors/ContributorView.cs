using Persistence.Models;

namespace Domain.Contracts.DTOs.Contributors
{
    public class ContributorView
    {
        public string RncCedula { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Estatus { get; set; }
        public string Active { get; set; }
        public ICollection<TaxReceipt> TaxReceipts { get; set; }
    }
}
