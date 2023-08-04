using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReDpett_API.Modal
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        [Required(ErrorMessage = "Role Name is required")]
        public string RoleName { get; set; }
       
    }
}
