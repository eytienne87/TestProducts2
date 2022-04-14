﻿using TestProducts2.Entities;

namespace TestProducts2.Dtos.Read
{
    public class WarrantyLengthDescriptionReadDto
    {
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
