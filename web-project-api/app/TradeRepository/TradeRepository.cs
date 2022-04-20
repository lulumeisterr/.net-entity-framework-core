using web_project_api.app.DTO;
using web_project_api.app.Model;
using web_project_api.app.DbContextInit;
namespace web_project_api.app.Repositorys;

    public class TradeRepository : ITradeRepository
    {
        private readonly ApplicationDbContext _context;

        public TradeRepository(ApplicationDbContext applicationDbContext) {
            this._context = applicationDbContext;
        }

        public static List<TradeDTO> _trades { get; set;} = _trades = new List<TradeDTO>();
                
        public TradeDTO Add (TradeDTO tradeRequest) {

            var newTrade = new Trade {
                tradeStatusCode = tradeRequest.tradeStatusCode,
                tradingDate = tradeRequest.tradingDate,
            };
            _context.Trades.Add(newTrade);
            _context.SaveChanges();

            tradeRequest.tradeId = _context.Trades.First().tradeId;
            return tradeRequest;
        }

        public TradeDTO GetTradeById(int tradeId) {
            return _trades.First(t => t.tradeId == tradeId);
        }

        public IEnumerable<TradeDTO> SearchTradeByDate(DateTime dateStart, DateTime endDate) {
            return _trades.Where(t => t.tradingDate >= dateStart && t.tradingDate <= endDate);
        }

        public TradeDTO UpdateTrade(TradeDTO tradeRequest) {
            var tradeSaved = GetTradeById(tradeRequest.tradeId);
            //tradeSaved.TradeStatusCode = tradeRequest.TradeStatusCode;
            //tradeSaved.TradingDate = tradeRequest.TradingDate;
            return tradeSaved;
        }

        public void DeleteTradeById (int tradeId) {
             var tradeSaved = GetTradeById(tradeId);
             _trades.Remove(tradeSaved);
        }

        public IEnumerable<TradeDTO> GetAllTrades() {
            return _trades;
        }
    }
