﻿using Domain.Shared;

namespace API.Dtos.Create
{
    public class WarrantyTitleDescriptionCreateDto
    {
        public LanguageClass Language { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
