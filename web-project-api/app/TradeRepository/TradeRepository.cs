using web_project_api.app.Model;
namespace web_project_api.app.Repositorys;

    public class TradeRepository : ITradeRepository
    {
        public static List<Trade> _trades { get; set;} = _trades = new List<Trade>();
                
        public void Add (Trade trade) {
            _trades.Add(trade);
        }

        public Trade GetTradeById(int tradeId) {
            return _trades.First(t => t.TradeId == tradeId);
        }

        public IEnumerable<Trade> SearchTradeByDate(DateTime dateStart, DateTime endDate) {
            return _trades.Where(t => t.TradingDate >= dateStart && t.TradingDate <= endDate);
        }

        public Trade UpdateTrade(Trade trade) {
            var tradeSaved = GetTradeById(trade.TradeId);
            tradeSaved.TradeStatusCode = trade.TradeStatusCode;
            tradeSaved.TradingDate = trade.TradingDate;
            return tradeSaved;
        }

        public void DeleteTradeById (int tradeId) {
             var tradeSaved = GetTradeById(tradeId);
             _trades.Remove(tradeSaved);
        }

        public IEnumerable<Trade> GetAllTrades() {
            return _trades;
        }
    }
