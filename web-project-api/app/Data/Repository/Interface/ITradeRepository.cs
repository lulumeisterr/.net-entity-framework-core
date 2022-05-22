using web_project_api.app.Model;

namespace web_project_api.app.Repositorys
{
    public interface ITradeRepository
    {
         Task<TradeDTO> Add (TradeDTO trade);
         void UpdateTrade(TradeDTO trade);
         void DeleteTradeById (int tradeId);
         Task<TradeDTO> GetTradeById(int tradeId);
         IEnumerable<TradeDTO> SearchTradeByDate(DateTime dateStart, DateTime endDate);
         IEnumerable<TradeDTO> GetAllTrades();
    }
}