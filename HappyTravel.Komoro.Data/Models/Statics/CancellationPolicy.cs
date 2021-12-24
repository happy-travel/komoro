using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTravel.Komoro.Data.Models.Statics
{
    public class CancellationPolicy
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
        public string? SeasonalityOrEvent { get; set; }
        public int Cxl { get; set; }
        public NoShowPolicies NoShow { get; set; }
    }
}
