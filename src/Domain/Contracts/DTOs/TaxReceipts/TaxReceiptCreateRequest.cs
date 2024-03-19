using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.DTOs.TaxReceipts
{
    public class TaxReceiptCreateRequest
    {
        public int ContributorId { get; set; }
        public string RncCedula { get; set; }
        public string NCF { get; set; }
        public decimal Monto { get; set; }
        public decimal Itbis18 { get; set; }
    }
}
