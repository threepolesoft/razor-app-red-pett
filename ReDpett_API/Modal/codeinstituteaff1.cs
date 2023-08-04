using System.ComponentModel.DataAnnotations;

namespace ReDpett_API.Modal
{
    public class codeinstituteaff1
    {
        [Key]
        public int Id { get; set; }
        public string instituteaff { get; set; } = string.Empty;
    }
}
