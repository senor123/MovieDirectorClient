using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieDirectorClient.Models;

namespace MovieDirectorClient.Pages
{
    public class NewMovieModel : PageModel
    {
        private MovieServices _movieservices;


        [BindProperty]
        public string Title { get; set; }=string.Empty;

        [BindProperty]
        public string Genre { get; set; } = string.Empty;

        [BindProperty]

        public List<int> DirectorIds { get; set; }


        public string errorMessage { get; set; } = string.Empty;
        public NewMovieModel(MovieServices movieservices)
        {
            _movieservices = movieservices;
        }

        public List<Directors> directorNames { get; set; }
       

        public async Task OnGetAsync()
        {
            directorNames = await _movieservices.getDirectorNames();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine(DirectorIds.Count);

            foreach(var id in DirectorIds)
            {
                Console.WriteLine(id is int);
            }
            MovieCreation m = new MovieCreation
            {
                Title = Title,
                Action = Genre,
                DirectorIds = DirectorIds
            };

            directorNames=await _movieservices.getDirectorNames();

            var statusCode = await _movieservices.addMovie(m);

            //if (statusCode != System.Net.HttpStatusCode.OK)
            //{
            //    errorMessage = "Cannot add new movie";
            //    return Page();
            //}

            return Redirect("/Movies");
        }


    }
}
