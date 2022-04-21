using web_project_api.app.DTO;
using web_project_api.app.Model;
using web_project_api.app.DbContextInit;
using Microsoft.EntityFrameworkCore;

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
                    var newAllocation = new Allocation {
                        accountNumber = itemAllocation.accountNumber,
                        unit = itemAllocation.unit,
                        allocationName = itemAllocation.allocationName
                    };
                    newTrade.allocations.Add(newAllocation);
                }
            }
            _context.Trades.Add(newTrade);
            _context.SaveChanges();
            return tradeRequest;
        }

        public TradeDTO? GetTradeById(int tradeIdRequest) {
            return _context.Trades
                .Include(t => t.allocations)
                .Where(t => t.tradeId == tradeIdRequest)
                .Select(t => new TradeDTO {
                    Id = t.Id,
                    tradeId = t.tradeId,
                    tradeStatusCode = t.tradeStatusCode,
                    buyiOrSell = t.buyiOrSell,
                    allocations = t.allocations.Select(a => new AllocationDTO {
                        accountNumber = a.accountNumber,
                        allocationName = a.allocationName,
                        unit = a.unit,
                    }).ToList()
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
                allocations = t.allocations.Select(a => new AllocationDTO {
                        accountNumber = a.accountNumber,
                        allocationName = a.allocationName,
                        unit = a.unit,
                    }).ToList()
             }).AsEnumerable<TradeDTO>();
        }

        public void UpdateTrade(TradeDTO tradeRequest) {
            
            var tradeSaved = GetTradeById(tradeRequest.tradeId);

            try {
                Console.WriteLine($"TRADE :  {tradeSaved.tradeId}");

                if (tradeSaved != null) {

                    var tradeEntity = new Trade {
                        Id = tradeSaved.Id,
                        tradeId = tradeRequest.tradeId,
                        tradeStatusCode = tradeRequest.tradeStatusCode,
                        buyiOrSell = tradeRequest.buyiOrSell,
                        allocations = new List<Allocation>()
                    };

                    if (tradeRequest.allocations != null) {
                        foreach(var item in tradeRequest.allocations) {
                            var allocations = new Allocation {
                                IdAccount = item.IdAccount,
                                accountNumber = item.accountNumber,
                                unit = item.unit,
                                allocationName = item.allocationName
                            };
                            tradeEntity.allocations.Add(allocations);
                            _context.Update(allocations); 
                        }
                    }
                    _context.Entry(tradeEntity).State = EntityState.Modified;
                    _context.SaveChanges();
                }

            }catch (DbUpdateException){
                throw;
            }
        }

        public void DeleteTradeById (int tradeId) {
             var tradeSaved = _context.Trades.Where(t => t.Id == GetTradeById(tradeId).Id).FirstOrDefault();
            _context.Trades.Remove(tradeSaved);  
            _context.SaveChanges();
        }

        public IEnumerable<TradeDTO> GetAllTrades() {
            return _context.Trades.Include(t => t.allocations)
                .Select(t => new TradeDTO {
                Id = t.Id,
                tradeId = t.tradeId,
                tradeStatusCode = t.tradeStatusCode,
                buyiOrSell = t.buyiOrSell,
                allocations = t.allocations.Select(a => new AllocationDTO {
                        IdAccount = a.IdAccount,
                        accountNumber = a.accountNumber,
                        allocationName = a.allocationName,
                        unit = a.unit,
                    }).ToList()
             }).AsEnumerable<TradeDTO>();
        }
    }
