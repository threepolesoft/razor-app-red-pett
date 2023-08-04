using System.ComponentModel.DataAnnotations.Schema;

namespace ReDpett_API.Modal
{
    public class ResidentType
    {
        public  int Id { get; set; }
        public string ResidentName { get; set; }
        [ForeignKey("RoleId")]
        public int TypeId { get; set; }    
    }
}
