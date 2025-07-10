using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieDirectorClient.Pages
{
    public class NewDirectorModel : PageModel
    {
        private MovieServices MovieServices { get; set; }


        public void OnGet()
        {
        }
    }
}
