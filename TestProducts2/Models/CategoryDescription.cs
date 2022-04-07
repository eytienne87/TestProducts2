﻿using TestProducts2.Entities;

namespace TestProducts2.Models
{
    public class CategoryDescription
    {
        public int CategoryId { get; set; } 
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}