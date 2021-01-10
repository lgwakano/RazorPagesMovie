using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }


        public SelectList Genres{ get; set; }

        #region BindProperties on GET Requests
        [BindProperty(SupportsGet=true)]
        public string SearchString { get; set; }


        [BindProperty(SupportsGet=true)]
        public string MovieGenre { get; set; }
        #endregion

        public async Task OnGetAsync()
        {
            var movies = from m in _context.Movie 
                            select m;

            IQueryable<string> genres = from m in movies
                            select m.Genre;

            if(!String.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(m => m.Title.Contains(SearchString));
            }

            if(!String.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(m => m.Genre.Contains(MovieGenre));
            }

            Genres = new SelectList(await genres.Distinct().OrderBy(g => g).ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
