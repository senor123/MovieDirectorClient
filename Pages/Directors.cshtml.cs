using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieDirectorClient.Models;

namespace MovieDirectorClient.Pages
{
    public class DirectorsModel : PageModel
    {
        private MovieServices _movieServices;

        public DirectorsModel(MovieServices movieServices)
        {
            _movieServices = movieServices;
        }

        public List<Directors> Directors { get; set; }

        public async Task OnGetAsync()
        {
            Directors = await _movieServices.getDirectorNames();
        }

    }
}
