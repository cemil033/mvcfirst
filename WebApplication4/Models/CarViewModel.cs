using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication4.Models
{
    public class CarsVM
    {
        public string Car { get; set; }
        public List<SelectListItem> Cars { get; set; } = new List<SelectListItem>();
       
    }
}
