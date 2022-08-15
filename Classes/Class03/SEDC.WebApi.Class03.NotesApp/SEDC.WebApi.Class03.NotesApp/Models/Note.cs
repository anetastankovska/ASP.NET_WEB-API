﻿using System.ComponentModel.DataAnnotations;

namespace SEDC.WebApi.Class03.NotesApp.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public int UserId { get; set; }
    }
}
