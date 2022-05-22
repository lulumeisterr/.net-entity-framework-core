using web_project_api.app.Business.Logic.Interface;
using web_project_api.app.Model;
using web_project_api.app.Repositorys;

namespace web_project_api.app.Business.Logic
{
    public class TradeBusiness : ITradeBusiness
    {
        private readonly ITradeRepository _tradeRepository;

        public TradeBusiness(ITradeRepository tradeRepository) {
            this._tradeRepository = tradeRepository ?? throw new ArgumentNullException(nameof(_tradeRepository));
        }

        public Task<TradeDTO> Add(TradeDTO trade) => _tradeRepository.Add(trade);

        public void DeleteTradeById(int tradeId) => _tradeRepository.DeleteTradeById(tradeId);

        public IEnumerable<TradeDTO> GetAllTrades() => _tradeRepository.GetAllTrades();

        public Task<TradeDTO> GetTradeById(int tradeId) => _tradeRepository.GetTradeById(tradeId);

        public IEnumerable<TradeDTO> SearchTradeByDate(DateTime dateStart, DateTime endDate) => _tradeRepository.SearchTradeByDate(dateStart,endDate);

        public void UpdateTrade(TradeDTO trade) => _tradeRepository.UpdateTrade(trade);
    }
}