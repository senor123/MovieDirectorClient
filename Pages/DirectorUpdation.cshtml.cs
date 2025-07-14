using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieDirectorClient.Models;

namespace MovieDirectorClient.Pages
{
    public class DirectorUpdationModel : PageModel
    {
        private DirectorServices _directorServices;

        public DirectorUpdationModel(DirectorServices directorServices)
        {
            _directorServices = directorServices;
        }
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]

        public string Name { get; set; } = string.Empty;

        [BindProperty]
        public int Age { get; set; }


        [BindProperty]

        public string MovieIds { get; set; } = string.Empty;
        public void OnGet(int id)
        {
            Id = id;
        }

        public async Task<IActionResult> OnPostEditAsync()
        {
            if (MovieIds == null)
            {
                return Page();
            }
            List<int> movieIds = MovieIds.Split(",").Select(num => Convert.ToInt32(num)).ToList();
            DirectorUpdation d = new DirectorUpdation
            {
                id = Id,
                Name = Name,
                Age=Age,
                MovieIds = movieIds
            };
            HttpResponseMessage message = await _directorServices.updateDirector(d, Id);

            Console.WriteLine(movieIds);
            return RedirectToPage("/Directors");
            
        }

    }
}
