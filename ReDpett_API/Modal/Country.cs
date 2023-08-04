using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReDpett_API.Modal
{
    public class Country
    {
        public int Id { get; set; }
        
        [DisplayName("Country")]
        public string Name { get; set; }

       
    }
}

