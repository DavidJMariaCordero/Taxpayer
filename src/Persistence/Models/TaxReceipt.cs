namespace Persistence.Models
{

    public sealed class TaxReceipt
    {
        public int Id { get; set; }
        public int ContributorId { get; private set; }
        public string RncCedula { get; private set; }
        public string NCF { get; private set; }
        public decimal Monto { get; private set; }
        public decimal Itbis18 { get; private set; }

        public TaxReceipt()
        {

        }
    }
}
