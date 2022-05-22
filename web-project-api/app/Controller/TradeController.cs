using Microsoft.AspNetCore.Mvc;
using web_project_api.app.Model;
using web_project_api.app.Repositorys;
using web_project_api.app.Utils;

namespace web_project_api.app.Controller;

public class TradeController : ControllerBase
    {
        private readonly ITradeRepository tradeRepository;
        public TradeController(ITradeRepository tradeRepository) {
            this.tradeRepository = tradeRepository;
        }

        [HttpPost("/trades")]
        public async Task<IActionResult> AddTrade([FromBody] TradeDTO tradeRequest) {

            var tradeValidateConstructor = new Trade(tradeRequest.tradeId,tradeRequest.tradeStatusCode,tradeRequest.buyiOrSell,tradeRequest.tradingDate);

            if(!tradeValidateConstructor.IsValid) {
                return ValidationProblem(new ValidationProblemDetails(tradeValidateConstructor.Notifications.ConvertProblemDetails()));
            }

            TradeDTO trade = await tradeRepository.Add(tradeRequest);
            return Created(uri: $"/trades/{trade.Id}",trade);
        }

        [HttpPut("/trades")]
        public IActionResult UpdateTradeById([FromBody] TradeDTO trade) {
            tradeRepository.UpdateTrade(trade);
            return Ok();
        }
        
        [HttpDelete("/trades/{tradeId:int}")]
        public IActionResult DeleteTradeById([FromRoute] int tradeId) {
           try {
                tradeRepository.DeleteTradeById(tradeId);
                return Ok();
           } catch (Exception e) {
                Console.WriteLine($"Generic Exception Handler: {e}");
            return NotFound();
           }
        }
        
        [HttpGet("/trades/{tradeId}")]
        public async Task<IActionResult> GetTradeById([FromRoute] int tradeId) {
             var result = await tradeRepository.GetTradeById(tradeId);
            if (result != null ) {
                return Ok(result);
            } else {
                return NotFound();
            }
        }

        [HttpGet("/tradesByDate")]
        public IActionResult GetTradeByRangeDate([FromQuery] DateTime startDate , [FromQuery] DateTime endDate) {
            var result = tradeRepository.SearchTradeByDate(startDate,endDate);
            if ( result == null || !result.Any() ) {
                return NoContent();
            } else {
                return Ok( tradeRepository.SearchTradeByDate(startDate,endDate) ); 
            }
        }

        
        [HttpGet("/trades")]
        public IActionResult GetAllTrades() {
            var result = tradeRepository.GetAllTrades();
            if ( result == null || !result.Any() ) {
                return NoContent();
            } else {
                return Ok( tradeRepository.GetAllTrades() ); 
            }
        }

        [HttpGet("/configuration/application")]
        public IActionResult configuration ([FromServices] IConfiguration configuration) {
            return Ok($"{configuration["project:applicationName"]}/{configuration["project:applicationVersion"]}");
        }
    }
