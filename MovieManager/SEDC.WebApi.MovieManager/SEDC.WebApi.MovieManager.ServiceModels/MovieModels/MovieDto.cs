using SEDC.WebApi.MovieManager.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.MovieManager.ServiceModels.MovieModels
{
    public class MovieDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? Year { get; set; }
        public string Genre { get; set; }

    }
}
