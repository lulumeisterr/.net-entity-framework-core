using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace web_project_api.app.Model
{
    [Table("Trade")]
    public class Trade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tradeId { get; set; }
        public DateTime tradingDate { get; set; }
        public string? tradeStatusCode { get; set; }
        public virtual ICollection<Allocation> allocations { get; set; }

        public Trade() {}
        public Trade(int tradeId, DateTime tradingDate, string tradeStatusCode) {
            this.tradeId = tradeId;
            this.tradingDate = tradingDate;
            this.tradeStatusCode = tradeStatusCode;
        }

        public override string ToString()
        {
            return tradeId + tradeStatusCode + tradingDate;
        }

    }
}