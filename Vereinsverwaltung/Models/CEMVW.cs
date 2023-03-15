using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Vereinsverwaltung.Models
{
    public class CEMVW
    {
        public List<SelectListItem> Items { get; set; }
        public int SelectedItemId { get; set; }
    }
}
