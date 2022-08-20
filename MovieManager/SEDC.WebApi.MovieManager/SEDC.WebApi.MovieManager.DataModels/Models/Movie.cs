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
        [Required]
        public string Title { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        [Required]
        public int Year { get; set; }
        [Required]
        public Genre Genre { get; set; }

    }
}
