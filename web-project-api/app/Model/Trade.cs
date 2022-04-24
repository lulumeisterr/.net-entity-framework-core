using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Notifications;
using Flunt.Validations;

namespace web_project_api.app.Model
{
    [Table("Trade")]
    public class Trade : Notifiable<Notification>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int tradeId { get; set; }
        public DateTime tradingDate { get; set; }
        public string? tradeStatusCode { get; set; }
        public string buyiOrSell { get; set; }
        public virtual ICollection<Allocation> allocations { get; set; }

        public Trade() {}
        public Trade (int tradeId, string tradeStatusCode, string buyiOrSell, DateTime tradingDate) {

            this.tradeId = tradeId;
            this.tradeStatusCode = tradeStatusCode;
            this.tradingDate = tradingDate;
            this.buyiOrSell = buyiOrSell;

            var contract = new Contract<Trade>()
            .IsNotNullOrEmpty(this.tradeStatusCode , "O Campo tradeStatusCode não pode ser nulo")
            .IsNotNullOrEmpty(this.buyiOrSell , "O Campo buyiOrSell não pode ser nulo");


            if(this.tradeId.GetHashCode() == 0) {
                AddNotification("tradeId", "O Campo tradeId não pode ser nulo");
            }

            if(this.tradingDate.GetHashCode() == 0) {
                AddNotification("tradingDate", "O Campo tradeId não pode ser nulo");
            }

            AddNotifications(contract);
        }

        public override string ToString()
        {
            return tradeId + tradeStatusCode + tradingDate;
        }
    }
}