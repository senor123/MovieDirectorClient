using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieDirectorClient.Models;
using System.Net;

namespace MovieDirectorClient.Pages
{
    public class NewDirectorModel : PageModel
    {
        private DirectorServices _directorServices { get; set; }

        [BindProperty]

        public int Id { get; set; }

        [BindProperty]

        public string DirectorName { get; set; }


        public NewDirectorModel(DirectorServices directorServices)
        {
            _directorServices = directorServices;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Directors d = new Directors
            {
                Name = DirectorName,
                Movies = new List<MovieCreation>()
            };
            HttpResponseMessage m=await _directorServices.addDirector(d);
            Console.WriteLine(m.StatusCode==HttpStatusCode.Created);
            if (m.StatusCode==HttpStatusCode.Created)
            {
                return RedirectToPage("/Directors");
            }
            return RedirectToPage("/NewDirector");
        }
    }
}
