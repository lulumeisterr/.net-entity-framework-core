using web_project_api.app.Model;

namespace web_project_api.app.DTO
{
    public class AllocationDTO {

        public int IdAccount { get; set; }
        public string? allocationName { get; set; }
        public int unit { get; set; }
        public string? accountNumber { get; set; }
    }
}