using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.Workshop.Notes.DataModels.Models
{
    public class Note : BaseEntity
    {
        public string? Text { get; set; }
        public string? Color { get; set; }
        public int? Tag { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
