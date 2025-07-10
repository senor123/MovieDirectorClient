using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MovieDirectorClient.Models;

namespace MovieDirectorClient.Pages
{
    public class MoviesModel : PageModel
    {
        private MovieServices movieServices;

        

        public MoviesModel(MovieServices movieServices)
        {
            this.movieServices = movieServices;
        }

        public List<DirectorMovies> Movies { get; set; }
        public async Task OnGetAsync()
        {
            Movies = await movieServices.getMovies();
        }

        public async Task<IActionResult> OnPostEditAsync(int id)
        {
            Movies = await movieServices.getMovies();
            Console.Write("Updating accessed");
            return RedirectToPage("/MovieUpdate",new { id });
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Movies = await movieServices.getMovies();
            Console.WriteLine("Movie Deleted");
            await movieServices.deleteMovie(id);
            return RedirectToPage("/Movies");
        }
    }
}
