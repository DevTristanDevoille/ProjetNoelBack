﻿using ProjetNoelAPI.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetNoelAPI.Models
{
    public class Idea : BaseModel
    {
        [Required]
        public string? Name { get; set; }
        public float? Price { get; set; }
        public string? UrlIdea { get; set; }
        public int Position { get; set; }
        public string? Commentaire { get; set; }
        [Required]
        public bool? IsTake { get; set; }
        [JsonIgnore]
        public Liste? Liste { get; set; }
        public int IdListe { get; set; }
    }
}
