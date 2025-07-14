using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieDirectorClient.Models;

namespace MovieDirectorClient.Pages
{
    public class DirectorsModel : PageModel
    {
        private DirectorServices _directorServices;

        public DirectorsModel(DirectorServices directorServices)
        {
            _directorServices = directorServices;
        }

        public List<Directors> Directors { get; set; }

        public async Task OnGetAsync()
        {
            Directors = await _directorServices.getDirectorNames();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            
            Directors = await _directorServices.getDirectorNames();

            HttpResponseMessage message=await _directorServices.deleteDirector(id);

            return RedirectToPage("/Directors");
        }

        public async Task<IActionResult> OnPostEditAsync(int id)
        {
            Directors = await _directorServices.getDirectorNames();


            Console.WriteLine("Updating accessed");
            return RedirectToPage("/DirectorUpdation", new { id });
        }

    }
}
