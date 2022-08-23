using SEDC.WebApi.MovieManager.DataModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.MovieManager.DataModels.Models
{
    public class Movie : BaseEntity
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public int? Year { get; set; }
        public Genre Genre { get; set; }

    }
}
