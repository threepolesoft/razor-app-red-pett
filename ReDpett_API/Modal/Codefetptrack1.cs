using System.ComponentModel.DataAnnotations;
namespace ReDpett_API.Modal
{
    public class Codefetptrack1
    {
        [Key]
        public int Id { get; set; }

        public string fetptrack { get; set; } = string.Empty;
    }
}
