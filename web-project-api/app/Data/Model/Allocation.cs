using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_project_api.app.Model
{
    [Table("Allocation")]
    public class Allocation
    {
        [Key]
        public int IdAccount { get; set; }
        public string? allocationName { get; set; }
        public int unit { get; set; }
        public string? accountNumber { get; set; }

        [ForeignKey("Trade")]
        public virtual Trade trade { get; set; }

    }
}
