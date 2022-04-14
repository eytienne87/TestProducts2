﻿using TestProducts2.Entities;

namespace TestProducts2.Dtos.Update
{
    public class WarrantyLengthDescriptionUpdateDto
    {
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
