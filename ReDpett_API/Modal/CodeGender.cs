using System.ComponentModel.DataAnnotations;
namespace ReDpett_API.Modal
{
    public class CodeGender
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
