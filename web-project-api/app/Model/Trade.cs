using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace web_project_api.app.Model
{
    [Table("Trade")]
    public class Trade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int tradeId { get; set; }
        public DateTime tradingDate { get; set; }
        public string? tradeStatusCode { get; set; }
        public string? buyiOrSell { get; set; }
        public virtual ICollection<Allocation> allocations { get; set; }


        public override string ToString()
        {
            return tradeId + tradeStatusCode + tradingDate;
        }

    }
}