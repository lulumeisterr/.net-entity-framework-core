namespace web_project_api.app.Model
{
    public class Trade
    {
        private int _tradeId;
        private DateTime _tradingDate;
        private string? _tradeStatusCode;
        public Trade(int tradeId, DateTime tradingDate, string tradeStatusCode) {
            this._tradeId = tradeId;
            this._tradingDate = tradingDate;
            this._tradeStatusCode = tradeStatusCode;
        }
//getset
        public DateTime TradingDate { 
            get => _tradingDate; 
            set => _tradingDate = value; 
        }

        public string? TradeStatusCode { 
            get => _tradeStatusCode; 
            set => _tradeStatusCode = value; 
        }

        public int TradeId { 
            get => _tradeId; 
            set => _tradeId = value; 
        }

        public override string ToString()
        {
            return _tradeId + _tradeStatusCode + _tradingDate;
        }

    }
}