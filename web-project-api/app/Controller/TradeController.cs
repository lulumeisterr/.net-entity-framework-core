using Microsoft.AspNetCore.Mvc;
using web_project_api.app.Model;
using web_project_api.app.Repositorys;
namespace web_project_api.app.Controller;

public class TradeController : ControllerBase
    {
        private readonly ITradeRepository tradeRepository;
        public TradeController(ITradeRepository tradeRepository) {
            this.tradeRepository = tradeRepository;
        }

        [HttpPost("/trades")]
        public IActionResult AddTrade([FromBody] Trade trade) {
            tradeRepository.Add(trade);
            return Created($"/trades/{trade.TradeId}",trade);
        }

        [HttpPut("/trades")]
        public IActionResult UpdateTradeById([FromBody] Trade trade) {
            return tradeRepository.UpdateTrade(trade) != null ? Ok(tradeRepository.UpdateTrade(trade)) : NoContent();
        }
        
        [HttpDelete("/trades/{tradeId}")]
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
        public IActionResult GetTradeById([FromRoute] int tradeId) {
             var result = tradeRepository.GetTradeById(tradeId);
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
