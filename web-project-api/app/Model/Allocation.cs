namespace web_project_api.app.Model
{
    public class Allocation
    {
        private int _allocationId;
        private string? _allocationName;
        private int _unit;
        private string? _accountNumber;

        private int currentTradeId { get; set; }
        private Trade _trade;

        public int AllocationId {
            get => _allocationId;
            set => _allocationId = value;
        }

        public int CurrentTradeId {
            get => currentTradeId;
            set => currentTradeId = value;
        }

        public string AllocationName {
            get => _allocationName;
            set => _allocationName = value;
        }

        public int Unit {
            get => _unit;
            set => _unit = value;
        }

        public string AccountNumber {
            get => _accountNumber;
            set => _accountNumber = value;
        }

        public Trade Trade {
            get => _trade;
            set => _trade = value;
        }
    }
}
