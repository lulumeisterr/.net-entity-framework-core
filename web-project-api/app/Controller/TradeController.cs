using Microsoft.AspNetCore.Mvc;
using web_project_api.app.Business.Logic;
using web_project_api.app.Business.Logic.Interface;
using web_project_api.app.Model;
using web_project_api.app.Repositorys;
using web_project_api.app.Utils;

namespace web_project_api.app.Controller;

public class TradeController : ControllerBase
    {
        private readonly ITradeBusiness _tradeBusiness;
        public TradeController(ITradeBusiness tradeBusiness) {
            this._tradeBusiness = tradeBusiness ?? throw new ArgumentNullException(nameof(_tradeBusiness));
        }

        [HttpPost("/trades")]
        public async Task<IActionResult> AddTrade([FromBody] TradeDTO tradeRequest) {

            var tradeValidateConstructor = new Trade(tradeRequest.tradeId,tradeRequest.tradeStatusCode,tradeRequest.buyiOrSell,tradeRequest.tradingDate);

            if(!tradeValidateConstructor.IsValid) {
                return ValidationProblem(new ValidationProblemDetails(tradeValidateConstructor.Notifications.ConvertProblemDetails()));
            }

            TradeDTO trade = await _tradeBusiness.Add(tradeRequest);
            return Created(uri: $"/trades/{trade.Id}",trade);
        }

        [HttpPut("/trades")]
        public IActionResult UpdateTradeById([FromBody] TradeDTO trade) {
            _tradeBusiness.UpdateTrade(trade);
            return Ok();
        }
        
        [HttpDelete("/trades/{tradeId:int}")]
        public IActionResult DeleteTradeById([FromRoute] int tradeId) {
           try {
                _tradeBusiness.DeleteTradeById(tradeId);
                return Ok();
           } catch (Exception e) {
                Console.WriteLine($"Generic Exception Handler: {e}");
            return NotFound();
           }
        }
        
        [HttpGet("/trades/{tradeId}")]
        public async Task<IActionResult> GetTradeById([FromRoute] int tradeId) {
             var result = await _tradeBusiness.GetTradeById(tradeId);
            if (result != null ) {
                return Ok(result);
            } else {
                return NotFound();
            }
        }

        [HttpGet("/tradesByDate")]
        public IActionResult GetTradeByRangeDate([FromQuery] DateTime startDate , [FromQuery] DateTime endDate) {
            var result = _tradeBusiness.SearchTradeByDate(startDate,endDate);
            if ( result == null || !result.Any() ) {
                return NoContent();
            } else {
                return Ok( _tradeBusiness.SearchTradeByDate(startDate,endDate) ); 
            }
        }

        
        [HttpGet("/trades")]
        public IActionResult GetAllTrades(int? page, int? row) {
            var result = _tradeBusiness.GetAllTrades();

            if ( result == null || !result.Any() ) {
                return NoContent();
            } else
        {
            List<TradeDTO> newTradeResults = Pagination(ref page, ref row, result);

            return Ok(newTradeResults);
        }
    }

    private static List<TradeDTO> Pagination(ref int? page, ref int? row, IEnumerable<TradeDTO> result)
    {
        if (page == null)
            page = 1;
        if (row == null)
            row = 1;

        var filter = result.Skip((page.Value - 1) * row.Value).Take(row.Value);
        var newTradeResults = filter.ToList();
        return newTradeResults;
    }

    [HttpGet("/configuration/application")]
        public IActionResult configuration ([FromServices] IConfiguration configuration) {
            return Ok($"{configuration["project:applicationName"]}/{configuration["project:applicationVersion"]}");
        }
    }
