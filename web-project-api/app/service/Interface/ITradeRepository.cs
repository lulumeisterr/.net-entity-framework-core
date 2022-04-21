using web_project_api.app.DTO;
namespace web_project_api.app.Repositorys
{
    public interface ITradeRepository
    {
         TradeDTO Add (TradeDTO trade);
         TradeDTO UpdateTrade(TradeDTO trade);
         void DeleteTradeById (int tradeId);
         TradeDTO GetTradeById(int tradeId);
         IEnumerable<TradeDTO> SearchTradeByDate(DateTime dateStart, DateTime endDate);
         IEnumerable<TradeDTO> GetAllTrades();
    }
}