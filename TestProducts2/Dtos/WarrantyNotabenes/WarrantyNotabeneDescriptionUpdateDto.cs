﻿using TestProducts2.Entities;

namespace TestProducts2.Dtos
{
    public class WarrantyNotabeneDescriptionUpdateDto
    {
        public LanguageClass Language { get; set; }   
        public string Description { get; set; } = string.Empty;   
    }
}