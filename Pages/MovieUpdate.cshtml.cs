using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieDirectorClient.Models;

namespace MovieDirectorClient.Pages
{
    public class MovieUpdateModel : PageModel
    {
        private MovieServices _movieServices;

        public MovieUpdateModel(MovieServices movieServices)
        {
            _movieServices = movieServices;
        }
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string Name { get; set; }


        public void OnGet(int id)
        {
            Id = id;
        }
        public async Task OnPostAsync(int id)
        {
            MovieCreation m = new MovieCreation
            {
                id = id,
                Title = Name,
                Action = "Action",
                DirectorIds = new List<int>()
            };

            Console.WriteLine(m.Title);
            await _movieServices.updateMovie(m, id);
        }
    }
}
