using web_project_api.app.DTO;
using web_project_api.app.Model;
using web_project_api.app.DbContextInit;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace web_project_api.app.Repositorys;

    public class TradeRepository : ITradeRepository
    {
        private readonly ApplicationDbContext _context;

        public TradeRepository(ApplicationDbContext applicationDbContext) {
            this._context = applicationDbContext;
        }
                
        public TradeDTO Add (TradeDTO tradeRequest) {

            var newTrade = new Trade {
                tradeStatusCode = tradeRequest.tradeStatusCode,
                tradingDate = tradeRequest.tradingDate,
                tradeId = tradeRequest.tradeId,
                buyiOrSell = tradeRequest.buyiOrSell             
            };

            if ( tradeRequest.allocations != null) {
                newTrade.allocations = new List<Allocation>();
                foreach ( var itemAllocation in tradeRequest.allocations) {
                    newTrade.allocations.Add(itemAllocation);
                }
            }
            _context.Trades.Add(newTrade);
            _context.SaveChanges();
            return tradeRequest;
        }

        public TradeDTO? GetTradeById(int tradeId) {
            return _context.Trades
                .Include(t => t.allocations)
                .Where(t => t.tradeId == tradeId)
                .Select(t => new TradeDTO {
                    tradeId = t.tradeId,
                    tradeStatusCode = t.tradeStatusCode,
                    buyiOrSell = t.buyiOrSell,
                    allocations = t.allocations
                }).FirstOrDefault();
        }

        public IEnumerable<TradeDTO> SearchTradeByDate(DateTime dateStart, DateTime endDate) {
            return _context.Trades
            .Include(t => t.allocations) 
             .Where(t => t.tradingDate >= dateStart && t.tradingDate <= endDate)
             .Select(t => new TradeDTO {
                tradeId = t.tradeId,
                tradeStatusCode = t.tradeStatusCode,
                buyiOrSell = t.buyiOrSell,
                allocations = t.allocations
             }).AsEnumerable<TradeDTO>();
        }

        public TradeDTO UpdateTrade(TradeDTO tradeRequest) {
            var tradeSaved = GetTradeById(tradeRequest.tradeId);
            //tradeSaved.TradeStatusCode = tradeRequest.TradeStatusCode;
            //tradeSaved.TradingDate = tradeRequest.TradingDate;
            return tradeSaved;
        }

        public void DeleteTradeById (int tradeId) {
             var tradeSaved = GetTradeById(tradeId);
            
            //Aprender a utilização do automapper
             var newTrade = new Trade {
                  tradeId = tradeSaved.tradeId,
                  tradeStatusCode = tradeSaved.tradeStatusCode,
                  buyiOrSell = tradeSaved.buyiOrSell,
                  allocations = tradeSaved.allocations
             };
             _context.Trades.Remove(newTrade);
        }

        public IEnumerable<TradeDTO> GetAllTrades() {
            return _context.Trades.Include(t => t.allocations)
                .Select(t => new TradeDTO {
                tradeId = t.tradeId,
                tradeStatusCode = t.tradeStatusCode,
                buyiOrSell = t.buyiOrSell,
                allocations = t.allocations
             }).AsEnumerable<TradeDTO>();
        }
    }
