

namespace Domain.Contracts.DTOs.TaxReceipts
{
    public class TaxReceiptView
    {
        public string RncCedula { get; set; }
        public string NCF { get; set; }
        public decimal Monto { get; set; }
        public decimal Itbis18 { get; set; }
    }
}
