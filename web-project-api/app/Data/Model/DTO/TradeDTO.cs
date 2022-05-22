using web_project_api.app.DTO;
namespace web_project_api.app.Model;

    public class TradeDTO {
        public int Id { get; set; }
        public int tradeId { get; set; }
        public DateTime tradingDate { get; set; }
        public string? tradeStatusCode { get; set; }
        public string buyiOrSell { get; set; }
        public ICollection<AllocationDTO> allocations { get; set; }

}

