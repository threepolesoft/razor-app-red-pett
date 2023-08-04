using System.ComponentModel.DataAnnotations;
namespace ReDpett_API.Modal
{
    public class Codequalifyingdegree1
    {
        [Key]
        public int Id { get; set; }
        public string qualifyingdegree { get; set; } = string.Empty;
    }
}
