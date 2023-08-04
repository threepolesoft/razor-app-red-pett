using System.ComponentModel.DataAnnotations;

namespace ReDpett_API.Modal
{
    public class Codeorganizationtype1
    {
        [Key]
        public int Id { get; set; }
        public string organizationtype { get; set; } = string.Empty;
    }
}
