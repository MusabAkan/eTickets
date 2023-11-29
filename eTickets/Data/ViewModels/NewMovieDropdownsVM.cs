using eTickets.Models;
using System.Collections.Generic;

namespace eTickets.Data.ViewModels
{
    public class NewMovieDropdownsVM
    {
        public List<Producer> Producers { get; set; } = new();
        public List<Cinema> Cinemas { get; set; } = new();
        public List<Actor> Actors { get; set; } = new();
    }
}
