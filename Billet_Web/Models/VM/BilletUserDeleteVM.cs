using Billet_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Billet_Web.Models.VM
{
    public class BilletUserDeleteVM
    {
        public BilletUserDeleteVM()
        {
            BilletUser = new BilletUserDTO();
        }
        public BilletUserDTO BilletUser { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> BilletList { get; set; }
    }
}
