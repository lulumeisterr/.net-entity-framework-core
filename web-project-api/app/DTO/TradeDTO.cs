namespace web_project_api.app.DTO
{
    public record TradeDTO(int TradeId, DateTime TradingDate, string TradeStatusCode, ICollection<String> allocations);
}
