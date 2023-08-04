using System.ComponentModel.DataAnnotations;

namespace ReDpett_API.Modal
{
    public class Codecurrentprofession1
    {
        [Key]
        public int Id { get; set; }
        public string currentprofession { get; set; } = string.Empty;
    }
}
