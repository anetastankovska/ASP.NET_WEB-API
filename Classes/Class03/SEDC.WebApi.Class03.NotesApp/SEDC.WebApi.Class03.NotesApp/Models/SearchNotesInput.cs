using System.ComponentModel.DataAnnotations;

namespace SEDC.WebApi.Class03.NotesApp.Models
{
    public class SearchNotesInput
    {
        public int? Id { get; set; }
        public string? OrderBy { get; set; }
        public string? Color { get; set; }
    }
}
