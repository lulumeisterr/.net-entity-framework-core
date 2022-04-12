using web_project_api.app.Model;
namespace web_project_api.app.Repositorys
{
    public interface ITradeRepository
    {
         void Add (Trade trade);
         Trade UpdateTrade(Trade trade);
         void DeleteTradeById (int tradeId);
         Trade GetTradeById(int tradeId);
         IEnumerable<Trade> SearchTradeByDate(DateTime dateStart, DateTime endDate);
         IEnumerable<Trade> GetAllTrades();
    }
}